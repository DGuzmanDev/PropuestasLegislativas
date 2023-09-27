using System;
using PropuestasLegislativas.Models;

namespace PropuestasLegislativas.Interfaces
{
	public interface IServicioPropuestasLegislativas
	{
		PropuestaLegislativa registarNuevaPropuestaLegislativa(PropuestaLegislativa propuestaLegislativa);
	}
}

