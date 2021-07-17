using System;
namespace PagosTuya.entidades
{
    public class Mensajes
    {
        public enum Error
        {
            NO_CONTROLADO = 100,
            DUPLICADO = 101,
            NO_EXISTE = 102,
            FALLO_CLAVE = 103,
            NO_COINCIDE = 104,
            EXITOSO = 201
        }

        public Mensajes(Error codigo, string mensaje, string trama)
        {
            error = codigo;
            Mensaje = mensaje;
            Trama = trama;
        }

        public Error error { get; set; }

        public string Mensaje { get; set; }

        public string Trama { get; set; }
    }
}
