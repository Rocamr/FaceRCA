using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Threading.Tasks;
using System.Linq;

namespace FaceRCA
{

    public partial class Form1 : Form
    {// Importa las funciones de la Windows API necesarias

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        // Estructura para almacenar las coordenadas de la ventana
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        Dictionary<string, Process> rutas = new Dictionary<string, Process>();
        Process[] allRunningPrograms;
        Boolean continuar = true;
        Boolean respuesta = false;
        // Configuración de la API de Face de Azure
        string endpoint = "https://apirf.cognitiveservices.azure.com/";
        string subscriptionKey = "42d7ce1aa2e1405c823a57fc148ee358";
        public Form1()
        {
            InitializeComponent();
            ProgramasE();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ProgramasE()
        {
            allRunningPrograms = Process.GetProcessesByName("Zoom");
            if (allRunningPrograms.Length > 0) {
                procesosEN.Items.Add(allRunningPrograms[0].ProcessName);
                rutas.Add(allRunningPrograms[0].ProcessName, allRunningPrograms[0]);
            }
            allRunningPrograms = Process.GetProcessesByName("Discord");
            if (allRunningPrograms.Length > 0)
            {
                procesosEN.Items.Add(allRunningPrograms[0].ProcessName);
                rutas.Add(allRunningPrograms[0].ProcessName, allRunningPrograms[0]);
            }
            allRunningPrograms = Process.GetProcessesByName("msteams");
            if (allRunningPrograms.Length > 0)
            {
                procesosEN.Items.Add("Teams");
                rutas.Add("Teams", allRunningPrograms[0]);
            }
        }
        private Boolean Colocar()
        {
            if (procesosEN.Text == "Zoom")
            {
                Foto("Zoom Reunión");
                return respuesta;
            }
            else if (procesosEN.Text == "Discord")
            {
                Foto("Discord");
                return respuesta;
            }
            else if (procesosEN.Text == "Teams")
            {
                Foto("msteams");
                return respuesta;
            }
            return respuesta;
        }
        private void GrabarVideo_Click(object sender, EventArgs e)
        {
            Boolean data = Colocar();
            while (continuar || data)
            {
                AnalisisAsync();
                data = Colocar();
                Thread.Sleep(3500);
            }
        }
        private void Refresco_Click(object sender, EventArgs e)
        {
            procesosEN.Items.Clear();
            rutas.Clear();
            ProgramasE();
        }
        static Bitmap ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        static IntPtr FindWindowByTitle(string title)
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process process in Process.GetProcesses())
            {
                if (process.MainWindowTitle.Contains(title)|| process.MainWindowTitle.Contains("Controles de reunión"))
                {
                    hWnd = process.MainWindowHandle;
                    break;
                }
            }
            return hWnd;
        }
        // Importa la función de la Windows API para buscar una ventana por su clase y nombre de ventana
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private void procesosEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean data = Colocar();
        }
        private Boolean Foto (string x)
        {
            IntPtr hWnd = FindWindowByTitle(x);

            if (hWnd != IntPtr.Zero)
            {
                // Obtiene el tamaño de la ventana de llamada
                Rectangle windowRect;
                GetWindowRect(hWnd, out windowRect);
                int width = windowRect.Width;
                int height = windowRect.Height;

                // Captura la pantalla en un bitmap
                Bitmap bitmap = new Bitmap(width, height);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(width, height));
                }

                // Redimensiona la imagen para que se ajuste al tamaño del PictureBox
                Bitmap resizedBitmap = ResizeImage(bitmap, VideoV.Width, VideoV.Height);

                // Asigna la imagen redimensionada al PictureBox
                VideoV.Image = resizedBitmap;

                Console.ReadLine();
                respuesta = true;
                return respuesta;
            }
            else
            {
                MessageBox.Show("NO hay una llamada activa");  
            }
            return respuesta;
        }
        private void DetenerVideo_Click(object sender, EventArgs e)
        {
            continuar = false;
        }
        static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
        private async Task AnalisisAsync()
        {
            // Convierte la imagen en un arreglo de bytes
            byte[] imageBytes = ImageToByteArray(VideoV.Image);
            FaceClient faceClient = new FaceClient(new ApiKeyServiceClientCredentials(subscriptionKey));
            faceClient.Endpoint = endpoint;

            // Realiza la llamada a la API para analizar la imagen
            try
            {
                IList<DetectedFace> detectedFaces = await faceClient.Face.DetectWithStreamAsync(new MemoryStream(imageBytes), returnFaceAttributes: new List<FaceAttributeType?> { FaceAttributeType.Age, FaceAttributeType.Gender, FaceAttributeType.Emotion });

                // Muestra la información de cada rostro detectado
                foreach (DetectedFace face in detectedFaces)
                {
                    textBox1.AppendText($"ID del rostro: {face.FaceId}");
                    textBox1.AppendText($"Género: {face.FaceAttributes.Gender}");
                    textBox1.AppendText($"Edad: {face.FaceAttributes.Age}");

                    // Muestra las emociones del rostro
                    Console.WriteLine("Emociones:");
                    foreach (KeyValuePair<string, double> emotion in face.FaceAttributes.Emotion.ToRankedList())
                    {
                        textBox1.AppendText($"{emotion.Key}: {emotion.Value}");
                    }
                }
            }
            catch (APIErrorException ex)
            {
                MessageBox.Show($"Error al llamar a la API de Face: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Estadistica_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollo");
        }
    }
}
