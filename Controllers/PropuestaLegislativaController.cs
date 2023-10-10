using Microsoft.AspNetCore.Mvc;
using PropuestasLegislativas.Models;
using PropuestasLegislativas.Interfaces;
using PropuestasLegislativas.Services;

namespace PropuestasLegislativas.Controllers
{
    [Route("api/[controller]")]
    public class PropuestaLegislativaController : ControllerBase
    {
        private readonly ILogger<PropuestaLegislativaController> _logger;
        private IServicioPropuestasLegislativas ServicioPropuestasLegislativas;


        public PropuestaLegislativaController(ILogger<PropuestaLegislativaController> logger)
        {
            _logger = logger;
            ServicioPropuestasLegislativas = new ServicioPropuestasLegislativas();
        }

        [HttpPost]
        [Route("guardar")]
        public PropuestaLegislativa saveNewNode([FromBody] PropuestaLegislativa propuestaLegislativa)
        {
            if (propuestaLegislativa != null)
            {
                _logger.LogInformation("Ejecutando endpoint para registro de nueva propuesta legislativa");
                return ServicioPropuestasLegislativas.registarNuevaPropuestaLegislativa(propuestaLegislativa);
            }
            else
            {
                throw new BadHttpRequestException("El cuerpo de la solicitud no es válido");
            }
        }
    }

}

