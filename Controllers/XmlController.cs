using Microsoft.AspNetCore.Mvc;
using PropuestasLegislativas.Models;
using PropuestasLegislativas.Interfaces;
using PropuestasLegislativas.Services;

namespace PropuestasLegislativas.Controllers
{
    [Route("api/[controller]")]
    public class XmlController : ControllerBase
    {
        private readonly ILogger<XmlController> _logger;
        private IServicioPropuestasLegislativas ServicioPropuestasLegislativas;


        public XmlController(ILogger<XmlController> logger)
        {
            _logger = logger;
            ServicioPropuestasLegislativas = new ServicioPropuestasLegislativas();
        }

        [HttpPost]
        [Route("write/dynamic")]
        public PropuestaLegislativa saveNewNode([FromBody] PropuestaLegislativa propuestaLegislativa)
        {
            if (propuestaLegislativa != null)
            {
                return ServicioPropuestasLegislativas.registarNuevaPropuestaLegislativa(propuestaLegislativa);
            }
            else
            {
                throw new BadHttpRequestException("El cuerpo de la solicitud no es válido");
            }
        }
    }

}

