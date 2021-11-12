using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MAPRPrueba
{
    internal class ConexDB
    {
        public static SqlConnection Conexion()
        {
            //Cadena de conexion 1
            SqlConnection cn = new SqlConnection("SERVER=LAPTOP-KH94VFS1;DATABASE=EnsamblajeComputadoras; integrated security=true");
            cn.Open();
            return cn;
        }

        public static SqlConnection Conexion2()
        {
            //Cadena de conexion 2
            SqlConnection cn1 = new SqlConnection("SERVER=LAPTOP-KH94VFS1;DATABASE=ConstruccionRed1; integrated security=true");
            cn1.Open();
            return cn1;
        }



    }
}
