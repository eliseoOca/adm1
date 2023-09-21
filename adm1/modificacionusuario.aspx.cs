using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adm1
{
    public partial class modificacionusuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Obtener la cadena de conexión desde el archivo web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["administracion"].ConnectionString;

            // Crear una conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Consulta SQL para buscar un usuario por nombre
                    string consulta = "SELECT nombre, clave, mail FROM usuarios WHERE nombre = @nombre";

                    // Crear un comando SQL con parámetros
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Asignar el valor del parámetro @nombre
                        comando.Parameters.AddWithValue("@nombre", TextBox1.Text);

                        // Ejecutar la consulta y obtener los resultados
                        SqlDataReader registro = comando.ExecuteReader();

                        // Verificar si se encontraron resultados
                        if (registro.Read())
                        {
                            // Mostrar los datos del usuario encontrado en los TextBox
                            TextBox2.Text = registro["clave"].ToString();
                            TextBox3.Text = registro["mail"].ToString();
                        }
                        else
                        {
                            // Mostrar un mensaje si no se encontró un usuario con ese nombre
                            Label1.Text = "No existe un usuario con dicho nombre";
                        }

                        // Cerrar el SqlDataReader
                        registro.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir (por ejemplo, problemas de conexión)
                    Label1.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Obtener la cadena de conexión desde el archivo web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["administracion"].ConnectionString;

            // Crear una conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conexion.Open();

                    // Consulta SQL para actualizar los datos del usuario
                    string consulta = "UPDATE usuarios SET clave = @clave, mail = @mail WHERE nombre = @nombre";

                    // Crear un comando SQL con parámetros
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Asignar los valores de los parámetros
                        comando.Parameters.AddWithValue("@nombre", TextBox1.Text);
                        comando.Parameters.AddWithValue("@clave", TextBox2.Text);
                        comando.Parameters.AddWithValue("@mail", TextBox3.Text);

                        // Ejecutar la consulta y obtener la cantidad de filas afectadas
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 1)
                        {
                            // Mostrar un mensaje si se modificaron los datos correctamente
                            Label1.Text = "Datos Modificados";
                        }
                        else
                        {
                            // Mostrar un mensaje si no se encontró un usuario con ese nombre
                            Label1.Text = "No existe el usuario";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir (por ejemplo, problemas de conexión)
                    Label1.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}