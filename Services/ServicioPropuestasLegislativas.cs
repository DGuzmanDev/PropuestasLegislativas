using System;
using System.Text.RegularExpressions;
using System.Xml;
using PropuestasLegislativas.Interfaces;
using PropuestasLegislativas.Models;
using PropuestasLegislativas.Exceptions;

namespace PropuestasLegislativas.Services
{
    public class ServicioPropuestasLegislativas : IServicioPropuestasLegislativas
    {
        private readonly string fileName = "propuestas_legislativas.xml";


        public ServicioPropuestasLegislativas()
        {
        }

        /**
         * Agrega un nuevo elemento XML "propuesta_legislativa".
         * 
         * Si el archivo XML no existe, se crea uno nuevo, en caso contrario,
         * se agrega el nuevo elemento al archivo existente
         */
        public PropuestaLegislativa registarNuevaPropuestaLegislativa(PropuestaLegislativa propuestaLegislativa)
        {
            if (validarPropuestaLegislativa(propuestaLegislativa))
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("El archivo no existe aun");
                    crearNuevoArchivoXml(propuestaLegislativa);
                }
                else
                {
                    Console.WriteLine("El archivo ya existe");
                    agregarPropuestaLegislativa(propuestaLegislativa);
                }

                return propuestaLegislativa;
            }
            else
            {
                throw new ArgumentNullException("La propuesta legislativa es inválida");
            }
        }

        /**
         * Crea un nuevo archivo XML y agrega la propuesta legislativa dada
         * al registro de propuestas legislativas
         **/
        private void crearNuevoArchivoXml(PropuestaLegislativa propuestaLegislativa)
        {
            XmlTextWriter textWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
            textWriter.WriteStartDocument();

            textWriter.WriteStartElement("propuestas_legislativas");
            textWriter.WriteStartElement("propuesta_legislativa");

            agregarElementoXmlConTexto(textWriter, "nombre", propuestaLegislativa.Nombre);
            agregarElementoXmlConTexto(textWriter, "apellidos", propuestaLegislativa.Apellidos);
            agregarElementoXmlConTexto(textWriter, "telefono", propuestaLegislativa.Telefono);
            agregarElementoXmlConTexto(textWriter, "identificacion", propuestaLegislativa.Identificacion);
            agregarElementoXmlConTexto(textWriter, "correo_electronico", propuestaLegislativa.CorreoElectronico);
            agregarElementoXmlConTexto(textWriter, "tipo_identificacion", propuestaLegislativa.TipoIdentificacion);
            agregarElementoXmlConTexto(textWriter, "provincia", propuestaLegislativa.Provincia);
            agregarElementoXmlConTexto(textWriter, "canton", propuestaLegislativa.Canton);
            agregarElementoXmlConTexto(textWriter, "propuesta", propuestaLegislativa.Propuesta);

            textWriter.WriteEndElement();
            textWriter.WriteEndElement();

            textWriter.WriteEndDocument();
            textWriter.Close();
        }

        /**
         * Agrega la propuesta legislativa dada a un archivo XML existente 
         **/
        private void agregarPropuestaLegislativa(PropuestaLegislativa propuestaLegislativa)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList elemList = doc.GetElementsByTagName("propuestas_legislativas");

            if (elemList != null && elemList.Count == 1 && elemList[0] != null)
            {
                XmlElement propuesta = doc.CreateElement("propuesta_legislativa");

                agregarElementoXmlConTexto(doc, propuesta, "nombre", propuestaLegislativa.Nombre);
                agregarElementoXmlConTexto(doc, propuesta, "apellidos", propuestaLegislativa.Apellidos);
                agregarElementoXmlConTexto(doc, propuesta, "telefono", propuestaLegislativa.Telefono);
                agregarElementoXmlConTexto(doc, propuesta, "identificacion", propuestaLegislativa.Identificacion);
                agregarElementoXmlConTexto(doc, propuesta, "correo_electronico", propuestaLegislativa.CorreoElectronico);
                agregarElementoXmlConTexto(doc, propuesta, "tipo_identificacion", propuestaLegislativa.TipoIdentificacion);
                agregarElementoXmlConTexto(doc, propuesta, "provincia", propuestaLegislativa.Provincia);
                agregarElementoXmlConTexto(doc, propuesta, "canton", propuestaLegislativa.Canton);
                agregarElementoXmlConTexto(doc, propuesta, "propuesta", propuestaLegislativa.Propuesta);

                XmlElement propuestas = (XmlElement)elemList[0];
                propuestas.AppendChild(propuesta);

                doc.Save(fileName);
            }
            else
            {
                throw new MalformedXmlDocumentException("El archivo XML esta corrupto");
            }
        }

        private bool validarPropuestaLegislativa(PropuestaLegislativa propuestaLegislativa)
        {
            bool check_de_integridad = propuestaLegislativa != null && propuestaLegislativa.Apellidos != null
                && propuestaLegislativa.Canton != null
                && propuestaLegislativa.CorreoElectronico != null
                && propuestaLegislativa.Identificacion != null
                && propuestaLegislativa.Nombre != null
                && propuestaLegislativa.Propuesta != null
                && propuestaLegislativa.Provincia != null
                && propuestaLegislativa.Telefono != null
                && propuestaLegislativa.TipoIdentificacion != null;

            bool check_formato_id = validarFormatoIdentificacion(propuestaLegislativa.Identificacion, propuestaLegislativa.TipoIdentificacion);
            bool check_formato_tel = validarFormatoTelefono(propuestaLegislativa.Telefono);

            return check_de_integridad && check_formato_id && check_formato_tel;
        }

        private void agregarElementoXmlConTexto(XmlTextWriter textWriter, string name, string text)
        {
            textWriter.WriteStartElement(name);
            textWriter.WriteString(text);
            textWriter.WriteEndElement();
        }

        private void agregarElementoXmlConTexto(XmlDocument xmlDocument, XmlElement padre, string nombre, string text)
        {
            XmlElement element = xmlDocument.CreateElement(nombre);
            XmlText textNode = xmlDocument.CreateTextNode(text);
            element.AppendChild(textNode);
            padre.AppendChild(element);
        }

        private bool validarFormatoIdentificacion(string identificacion, string tipoIdentificacion)
        {
            string regexFormat = tipoIdentificacion == "Nacional" ? "[0-9]+-([0-9]{4})+-([0-9]{4})" : "[0-9]{12}";
            Regex regexIdentificacion = new Regex(regexFormat, RegexOptions.IgnoreCase);
            return regexIdentificacion.IsMatch(identificacion);
        }

        private bool validarFormatoTelefono(string telefono)
        {
            Regex regexIdentificacion = new Regex("\\(\\+506\\) [0-9]{4}-[0-9]{2}-[0-9]{2}", RegexOptions.IgnoreCase);
            return regexIdentificacion.IsMatch(telefono);
        }
    }
}

