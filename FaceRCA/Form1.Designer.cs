namespace FaceRCA
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrabarVideo = new System.Windows.Forms.Button();
            this.DetenerVideo = new System.Windows.Forms.Button();
            this.Estadistica = new System.Windows.Forms.Button();
            this.NombreV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.procesosEN = new System.Windows.Forms.ComboBox();
            this.Refresco = new System.Windows.Forms.Button();
            this.VideoV = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.VideoV)).BeginInit();
            this.SuspendLayout();
            // 
            // GrabarVideo
            // 
            this.GrabarVideo.Location = new System.Drawing.Point(591, 90);
            this.GrabarVideo.Name = "GrabarVideo";
            this.GrabarVideo.Size = new System.Drawing.Size(109, 23);
            this.GrabarVideo.TabIndex = 0;
            this.GrabarVideo.Text = "Grabar video";
            this.GrabarVideo.UseVisualStyleBackColor = true;
            this.GrabarVideo.Click += new System.EventHandler(this.GrabarVideo_Click);
            // 
            // DetenerVideo
            // 
            this.DetenerVideo.Location = new System.Drawing.Point(591, 119);
            this.DetenerVideo.Name = "DetenerVideo";
            this.DetenerVideo.Size = new System.Drawing.Size(109, 23);
            this.DetenerVideo.TabIndex = 1;
            this.DetenerVideo.Text = "Detener Grabacion ";
            this.DetenerVideo.UseVisualStyleBackColor = true;
            this.DetenerVideo.Click += new System.EventHandler(this.DetenerVideo_Click);
            // 
            // Estadistica
            // 
            this.Estadistica.Location = new System.Drawing.Point(706, 90);
            this.Estadistica.Name = "Estadistica";
            this.Estadistica.Size = new System.Drawing.Size(105, 43);
            this.Estadistica.TabIndex = 2;
            this.Estadistica.Text = "Ver estadisticas de las Grabacion";
            this.Estadistica.UseVisualStyleBackColor = true;
            this.Estadistica.Click += new System.EventHandler(this.Estadistica_Click);
            // 
            // NombreV
            // 
            this.NombreV.Location = new System.Drawing.Point(591, 56);
            this.NombreV.Name = "NombreV";
            this.NombreV.Size = new System.Drawing.Size(220, 20);
            this.NombreV.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre de la grabacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Analisis del video ";
            // 
            // procesosEN
            // 
            this.procesosEN.FormattingEnabled = true;
            this.procesosEN.Location = new System.Drawing.Point(595, 13);
            this.procesosEN.Name = "procesosEN";
            this.procesosEN.Size = new System.Drawing.Size(121, 21);
            this.procesosEN.TabIndex = 9;
            this.procesosEN.SelectedIndexChanged += new System.EventHandler(this.procesosEN_SelectedIndexChanged);
            // 
            // Refresco
            // 
            this.Refresco.Image = global::FaceRCA.Properties.Resources.re2;
            this.Refresco.Location = new System.Drawing.Point(731, 3);
            this.Refresco.Name = "Refresco";
            this.Refresco.Size = new System.Drawing.Size(41, 38);
            this.Refresco.TabIndex = 10;
            this.Refresco.UseVisualStyleBackColor = true;
            this.Refresco.Click += new System.EventHandler(this.Refresco_Click);
            // 
            // VideoV
            // 
            this.VideoV.Location = new System.Drawing.Point(1, 2);
            this.VideoV.Name = "VideoV";
            this.VideoV.Size = new System.Drawing.Size(584, 448);
            this.VideoV.TabIndex = 4;
            this.VideoV.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(595, 162);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 288);
            this.textBox1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 466);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Refresco);
            this.Controls.Add(this.procesosEN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NombreV);
            this.Controls.Add(this.VideoV);
            this.Controls.Add(this.Estadistica);
            this.Controls.Add(this.DetenerVideo);
            this.Controls.Add(this.GrabarVideo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GrabarVideo;
        private System.Windows.Forms.Button DetenerVideo;
        private System.Windows.Forms.Button Estadistica;
        private System.Windows.Forms.PictureBox VideoV;
        private System.Windows.Forms.TextBox NombreV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox procesosEN;
        private System.Windows.Forms.Button Refresco;
        private System.Windows.Forms.TextBox textBox1;
    }
}

