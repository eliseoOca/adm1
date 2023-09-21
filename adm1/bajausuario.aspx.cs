using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adm1
{
    public partial class bajausuario : System.Web.UI.Page
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

                    // Consulta SQL para eliminar un usuario por nombre
                    string consulta = "DELETE FROM usuarios WHERE nombre = @nombre";

                    // Crear un comando SQL con parámetros
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Asignar el valor del parámetro @nombre
                        comando.Parameters.AddWithValue("@nombre", TextBox1.Text);

                        // Ejecutar la consulta y obtener la cantidad de filas afectadas
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 1)
                        {
                            // Mostrar un mensaje si se eliminó el usuario correctamente
                            Label1.Text = "Se borró el usuario";
                        }
                        else
                        {
                            // Mostrar un mensaje si no se encontró un usuario con ese nombre
                            Label1.Text = "No existe un usuario con dicho nombre";
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