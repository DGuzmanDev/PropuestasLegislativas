﻿using System;
using PropuestasLegislativas.Enums;

namespace PropuestasLegislativas.Models;

public class PropuestaLegislativa
{
	public String? Nombre { get; set; }
	public String? Apellidos { get; set; }
    public String? Identificacion { get; set; }
    public String? Provincia { get; set; }
    public String? Canton { get; set; }
    public String? Distrito { get; set; }
    public String? Propuesta { get; set; }
    public String? TipoIdentificacion { get; set; }
	public String? CorreoElectronico { get; set; }
	public String? Telefono { get; set; }
    //public TipoIdentificacionEnumeration tipoIdentificacion;

    public PropuestaLegislativa(String nombre, String apellidos, String identificacion, String provincia,
		String canton, String distrito, String propuesta, String tipoIdentificacion)
	{
		this.Nombre = nombre;
		this.Apellidos = apellidos;
		this.Identificacion = identificacion;
		this.Provincia = provincia;
		this.Canton = canton;
		this.Distrito = distrito;
		this.Propuesta = propuesta;
		this.TipoIdentificacion = tipoIdentificacion;
    }
}
