using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAPRPrueba
{
    internal class Cliente
    {
		private string IdCliente;
        private string Nombre;
        private string Apellido;
        private string Correo;
        private string Ciudad;
        private string Pais;
        private int ComprasRealizadas;
        private string Estado;
        private string CodigoCliente;
        private string RedSocial;
        private int Edad;
        private string FechaCompra;

        public Cliente()
        {
            this.IdCliente = "";
            this.Nombre = "";
            this.Apellido = "";
            this.Correo = "";
            this.Ciudad = "";
            this.Pais = "";
            this.ComprasRealizadas = 0;
            this.Estado = "";
            this.CodigoCliente = "";
            this.RedSocial = "";
            this.Edad = 0;
            this.FechaCompra = "";

        }


        public string IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Ciudad1 { get => Ciudad; set => Ciudad = value; }
        public string Pais1 { get => Pais; set => Pais = value; }
        public int ComprasRealizadas1 { get => ComprasRealizadas; set => ComprasRealizadas = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string CodigoCliente1 { get => CodigoCliente; set => CodigoCliente = value; }
        public string RedSocial1 { get => RedSocial; set => RedSocial = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string FechaCompra1 { get => FechaCompra; set => FechaCompra = value; }
    }
}
