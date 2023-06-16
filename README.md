# FaceRCA
Este proyecto contiene código e interacción con el servidor de Azure. Con el cual puede enviar imágenes y estas son analizadas para después devolver la información capturada de cada imagen 
## Requisitos
- C# 
- Cuenta de Azure
- Instalar AForge.Video
-  Microsoft.Azure.CognitiveServices.Vision.Face

Se deben instalar dos bibliotecas: AForge.Video y Microsoft.Azure.CognitiveServices.Vision.Face. Estas librería se instalan con el controlador de nugets del proyecto una vez descargado. La primera permite grabar las aplicaciones, mientras que la segunda establece la conexión con Azure.
Es importante mencionar que el endpoint y la clave deben actualizarse, ya que es posible que la licencia se suspenda por inactividad. Además, la frecuencia con la que se toman las imágenes puede variar según las limitaciones de la licencia.

### Nota
Se recomienda utilizar NET de la vercion 6 en adelante 
