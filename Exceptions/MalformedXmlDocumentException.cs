using System;
namespace PropuestasLegislativas.Exceptions
{
    public class MalformedXmlDocumentException : Exception
    {
        public MalformedXmlDocumentException() : base()
        {
            //Vacio, solo invoca a la clase base por defecto
        }

        public MalformedXmlDocumentException(string message) : base(message)
        {
            //Vacio, solo invoca a la clase base por defecto
        }
    }
}

