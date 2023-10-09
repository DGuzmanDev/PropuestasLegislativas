using System;

namespace PropuestasLegislativas.Models;

public class PropuestaLegislativa
{
    public String? Nombre { get; set; }
    public String? Apellidos { get; set; }
    public String? Identificacion { get; set; }
    public String? Provincia { get; set; }
    public String? Canton { get; set; }
    public String? Propuesta { get; set; }
    public String? TipoIdentificacion { get; set; }
    public String? CorreoElectronico { get; set; }
    public String? Telefono { get; set; }

    public PropuestaLegislativa(String nombre, String apellidos, String identificacion, String provincia,
        String canton, String propuesta, String tipoIdentificacion)
    {
        this.Nombre = nombre;
        this.Apellidos = apellidos;
        this.Identificacion = identificacion;
        this.Provincia = provincia;
        this.Canton = canton;
        this.Propuesta = propuesta;
        this.TipoIdentificacion = tipoIdentificacion;
    }
}

