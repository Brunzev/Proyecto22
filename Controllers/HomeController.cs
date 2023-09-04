using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Python.Runtime;
using System.Diagnostics;
using System.Net.Mail;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EnviarExcel()
        {
            return View();
        }

        public IActionResult Servicio()
        {
            return View();
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Prueba(IFormFile archivoExcel) {
            if (archivoExcel != null && archivoExcel.Length > 0)
            {
                // Guardar el archivo en el servidor (opcional)
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await archivoExcel.CopyToAsync(stream);
                }

                // Obtén la ruta completa al script Python
                //Runtime.PythonDLL = @"C:\Users\teres\AppData\Local\Programs\Python\Python311\python311.dll"; // Ruta a la carpeta de instalación de Python
                PythonEngine.Initialize();
                try
                {
                    // Ejecuta tu script Python
                    using (Py.GIL())
                    {
                        Console.WriteLine("Ejecutando Script desde el Controller");
                        dynamic ScriptIA = Py.Import("ScriptIA");
                        dynamic archivoExcelGenerado = ScriptIA.UsarModelo(filePath);
                        if (archivoExcelGenerado != null)
                        {
                            ScriptIA.Enviar(archivoExcelGenerado);
                        }
                        else
                        {
                            Console.WriteLine("Error al generar el archivo Excel");
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir durante la ejecución del script
                    Console.WriteLine("Error al ejecutar el script Python: " + ex.Message);
                }
                // Puedes redirigir a una vista o realizar cualquier otra acción aquí*/
                //return RedirectToAction("Index");

           // }
            //return View();  
       // }
        

        [HttpPost]
        public async Task<IActionResult> EnviarExcel(IFormFile archivoExcel)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("atencio_zevallos@outlook.com");// el correo que se usara para enviar los mensajes
                //correo.To.Add(cliente.Email); el  correo para enviar el mensaje
                correo.To.Add("brunzev98@gmail.com");
                //correo.To.Add("bryan.castillo@birlik.com.pe");//Con copia a 
                //correo.To.Add("jonathan.chero@birlik.com.pe");//Con copia a 
                correo.Subject = "CONFIRMACIÓN DE ENVÍO";

                string MensajeCorreo = "Hola " +
                "<br/><br/>El excel ha sido enviado correctamente" +
                "<br/>. Gracias" +
                "<br/><br/>Atte." +
                "<br/>Equipo de Soporte";
                correo.Body = MensajeCorreo;

                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                // si deseas adjuntar un archivo arriba al costado de mensaje corereo (, string HttpPostedFileBase fichero)
                //string ruta = Server.mapPath("../Temporal");
                //fichero.SaveAs(ruta + "// pero invertido" + fichero.filename);
                //attachment adjunto = new Attachment (ruta + "// al revez" + fichero.FileName);
                //correo.Attachments.Add(adjunto);

                //Configurando el servidor SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com";
                smtp.Port = 587;//25
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                string sCuentaCorreo = "atencio_zevallos@outlook.com";
                string sPasswordCorreo = "4485695Bruno.";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);

                if (archivoExcel != null && archivoExcel.Length > 0)
                {
                    // Guardar el archivo en el servidor (opcional)
                    var filePath = Path.GetTempFileName();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await archivoExcel.CopyToAsync(stream);
                    }

                    // Obtén la ruta completa al script Python
                    //Runtime.PythonDLL = @"C:\Users\teres\AppData\Local\Programs\Python\Python311\python311.dll"; // Ruta a la carpeta de instalación de Python
                    PythonEngine.Initialize();
                    try
                    {
                        // Ejecuta tu script Python
                        using (Py.GIL())
                        {
                            Console.WriteLine("Ejecutando Script desde el Controller");
                            dynamic ScriptIA = Py.Import("ScriptIA");
                            dynamic archivoExcelGenerado = ScriptIA.UsarModelo(filePath);
                            if (archivoExcelGenerado != null)
                            {
                                ScriptIA.Enviar(archivoExcelGenerado);
                            }
                            else
                            {
                                Console.WriteLine("Error al generar el archivo Excel");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        // Maneja cualquier excepción que pueda ocurrir durante la ejecución del script
                        Console.WriteLine("Error al ejecutar el script Python: " + ex.Message);
                    }
                    // Puedes redirigir a una vista o realizar cualquier otra acción aquí*/
                    return RedirectToAction("Index");

                }







                return View();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string msj = "0";

                return View();
            }

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}