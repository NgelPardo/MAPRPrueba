using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace MAPRPrueba
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection("SERVER=LAPTOP-KH94VFS1;DATABASE=EnsamblajeComputadoras; integrated security=true");
        SqlConnection cn1 = new SqlConnection("SERVER=LAPTOP-KH94VFS1;DATABASE=ConstruccionRed1; integrated security=true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConexDB.Conexion();
            dataGridView1.DataSource = Procesos.Consultar();  
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Llenar el datagrid
            ConexDB.Conexion();
            string id;
            id = txtID.Text;
            dataGridView1.DataSource = Procesos.Consultarid(id);
            //Recuperar los datos en el datatimepicker
            string fecha1 = "select FechaCompra from Clientes1 " +
                                "where IdCliente = " + id + ";";
            string fecha2 = "select FechaCompra from Clientes2 " +
                                "where IdCliente = " + id + ";";
            SqlCommand cmd = new SqlCommand(fecha1, ConexDB.Conexion());
            SqlCommand cmd2 = new SqlCommand(fecha2, ConexDB.Conexion2());
            cmd.Parameters.AddWithValue(id, txtID.Text);
            cmd2.Parameters.AddWithValue(id, txtID.Text);
            cn.Open();
            cn1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            SqlDataReader reader1 = cmd2.ExecuteReader();
            if (reader.Read())
            {
                dateTimePicker1.Text = reader["FechaCompra"].ToString();
            }
            cn.Close();
            if (reader1.Read())
            {
                dateTimePicker1.Text = reader1["FechaCompra"].ToString();
            }
            cn1.Close();
        }

        public void enviarCorreo()
        {
            string body =
                "<body>" +
                    "<h1>Promocion empresa ensambladora de computadoras</h1>" +
                    "<h4>Apreciado cliente,</h4>" +
                    "<span>Por su lealtad con nuestras empresas le queremos ofrecer una oferta especial para usted</span>" +
                    "<span>Obtenga un 15% de descuento en nuestros productos y servicios en su proxima compra</span>" +
                    "<br></br><span>Saludos cordiales.</span>" +
                "</body>";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.Credentials = new NetworkCredential("demoapp@gmail.com", "********");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("demoapp@gmail.com", "PROMOCION");
            mailMessage.To.Add(new MailAddress("jperez@sitic.com.co"));
            mailMessage.Subject = "Mensaje de promocion";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string id;
            id = txtID.Text;

            //Actualizar la fecha
            string fecha = dateTimePicker1.Text;
            string query = "update Clientes1 set FechaCompra = @fecha where IdCliente = "+id+";"; 
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.ExecuteNonQuery();
            cn.Close();

            //Sumar compra realizada
            cn.Open();
            int c,n;
            SqlCommand cmd4 = new SqlCommand("select ComprasRealizadas from Clientes1 " +
                                "where IdCliente = " + id + ";", ConexDB.Conexion());
            SqlDataReader reader = cmd4.ExecuteReader();
            if (reader.Read())
            {
                c = Int32.Parse(reader["ComprasRealizadas"].ToString());
                n = 1 + c;
                SqlCommand cmd5 = new SqlCommand("update Clientes1 set ComprasRealizadas = "+n+" where IdCliente = " + id + ";", cn);
                cmd5.ExecuteNonQuery();
                cn.Close();
                if (n == 15)
                {
                    enviarCorreo();
                }
            }

            //Llenar el datagrid
            ConexDB.Conexion();
            dataGridView1.DataSource = Procesos.Consultarid(id);
            MessageBox.Show("Actualizado");
            //Comparar fechas
            DateTime date = Convert.ToDateTime(fecha);
            var dias = (DateTime.Now - date).TotalDays;
            if (dias < 93)
            {
                //Actualizar estado activo
                string estado = "Activo";
                string query1 = "update Clientes1 set Estado = @estado where IdCliente = " + id + ";";
                cn.Open();
                SqlCommand cmd1 = new SqlCommand(query1, cn);
                cmd1.Parameters.AddWithValue("@estado", estado);
                cmd1.ExecuteNonQuery();
                cn.Close();
                //Llenar el datagrid
                ConexDB.Conexion();
                dataGridView1.DataSource = Procesos.Consultarid(id);
            }
            else
            {
                //Actualizar estado inactivo
                string estado = "Inactivo";
                string query1 = "update Clientes1 set Estado = @estado where IdCliente = " + id + ";";
                cn.Open();
                SqlCommand cmd1 = new SqlCommand(query1, cn);
                cmd1.Parameters.AddWithValue("@estado", estado);
                cmd1.ExecuteNonQuery();
                cn.Close();
                //Llenar el datagrid
                ConexDB.Conexion();
                dataGridView1.DataSource = Procesos.Consultarid(id);
            }

        }
    }
}
