using ConexionDGII;
using Microsoft.AspNetCore.Mvc;
using MVCAppCRUDRazorCodeFirst.Models;
using Newtonsoft.Json.Linq;

namespace MVCAppCRUDRazorCodeFirst.Controllers
{
    public class FacturacionDGII : Controller
    {
        [HttpGet]
        public IActionResult verFactura()
        {
            // Datos necesarios
            string urlSemilla = "https://ecf.dgii.gov.do/certecf/autenticacion/api/Autenticacion/Semilla";
            string passCert = "LD271167";
            string jsonInvoiceFO = "{ \"facturaDesdeF&O\": \"datos\" }";

            string urlValidarSemilla = "https://ecf.dgii.gov.do/certecf/autenticacion/api/Autenticacion/ValidarSemilla";
            string urlRecepcionFactura = "https://ecf.dgii.gov.do/certecf/recepcion/api/FacturasElectronicas";
            string urlConsultaFactura = "https://ecf.dgii.gov.do/certecf/consultaresultado/api/Consultas/Estado";

            try
            {
                // Llamada al método de la DLL
                string invoice = FacturacionElectronicaDGII.EnviarTokenSincrona(urlSemilla, passCert, jsonInvoiceFO);
                string response = FacturacionElectronicaDGII.EnviarFacturaElectronicaSincrona(urlValidarSemilla, urlRecepcionFactura, urlConsultaFactura);

                // Parsear el JSON 'invoice'
                JObject jsonObject = JObject.Parse(invoice);
                JObject jsonObjectResponse = JObject.Parse(response);

                var model = new FacturaDGIIModel
                {
                    JsonInvoice = jsonObject.GetValue("json")?.ToString(),
                    ENCF = jsonObject.GetValue("encf")?.ToString(),
                    XmlSemilla = jsonObject.GetValue("xmlsemilla")?.ToString(),
                    XmlSemillaFirmada = jsonObject.GetValue("xmlsemillafirmada")?.ToString(),
                    Token = jsonObject.GetValue("token")?.ToString(),
                    XmlFactura = jsonObject.GetValue("xmlfactura")?.ToString(),
                    XmlFacturaFirmada = jsonObject.GetValue("xmlfacturafirmada")?.ToString(),
                    CodigoSeguridad = jsonObject.GetValue("codigoseguridad")?.ToString(),
                    CodigoRespuesta = jsonObjectResponse.GetValue("codigo")?.ToString(),
                    EstadoRespuesta = jsonObjectResponse.GetValue("estado")?.ToString()
                };

                return View(model);
                //return View("NombreDeLaVista", model);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(null);
            }
        }

    }
}
