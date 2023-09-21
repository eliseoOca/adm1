using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adm1
{
    public partial class consultausuario : System.Web.UI.Page
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
                            // Mostrar los datos del usuario encontrado en la etiqueta Label1
                            Label1.Text = "Nombre: " + registro["nombre"] + "<br>";
                            Label1.Text += "Clave: " + registro["clave"] + "<br>";
                            Label1.Text += "Mail: " + registro["mail"];
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
    }
}