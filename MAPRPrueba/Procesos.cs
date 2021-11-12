using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MAPRPrueba
{
    
    internal class Procesos
    {
        SqlConnection cn = new SqlConnection("SERVER=LAPTOP-KH94VFS1;DATABASE=EnsamblajeComputadoras; integrated security=true");
        SqlConnection cn1 = new SqlConnection("SERVER=LAPTOP-KH94VFS1;DATABASE=ConstruccionRed1; integrated security=true");

        public static DataTable Consultar()
        {
            ConexDB.Conexion();
            ConexDB.Conexion2();
            
            DataTable dt = new DataTable();
            string consulta = "select IdCliente,Nombre,Apellido,Correo,Ciudad,ComprasRealizadas,Estado,FechaCompra from Clientes1";
            string consulta2 = "select IdCliente,Nombre,Apellido,Correo,Ciudad,ComprasRealizadas,Estado,FechaCompra from Clientes2";
            SqlCommand cmd = new SqlCommand(consulta,ConexDB.Conexion());
            SqlCommand cmd2 = new SqlCommand(consulta2, ConexDB.Conexion2());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da.Fill(dt);
            da1.Fill(dt);
            return dt;
        }

        public static DataTable Consultarid(string a)
        {
            ConexDB.Conexion();
            DataTable dt = new DataTable();
            string consulta = "select IdCliente,Nombre,Apellido,Correo,Ciudad,ComprasRealizadas,Estado,FechaCompra from Clientes1 " +
                                "where IdCliente = '"+a+"';"; 
            string consulta2 = "select IdCliente,Nombre,Apellido,Correo,Ciudad,ComprasRealizadas,Estado,FechaCompra from Clientes2 " +
                                "where IdCliente = '"+a+"';";
            string fecha1 = "select FechaCompra from Clientes1 " +
                                "where IdCliente = '"+a+"';";
         
            SqlCommand cmd = new SqlCommand(consulta, ConexDB.Conexion());
            SqlCommand cmd2 = new SqlCommand(consulta2, ConexDB.Conexion2());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da.Fill(dt);
            da1.Fill(dt);
            return dt;
        }

        


    }
}
