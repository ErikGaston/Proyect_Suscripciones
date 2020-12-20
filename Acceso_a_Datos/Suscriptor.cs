using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Acceso_a_Datos
{
    public class Suscriptor
    {
        public static string conexion = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;

        #region Metodos
        public static DataTable obtenerSuscriptor(String tipoDocumento, int numeroDocumento)
        {
            string consulta = "SELECT * FROM Suscriptor WHERE TipoDocumento = @tipoDocumento AND NumeroDocumento = @numeroDocumento";
            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta,cn);
            try
            {

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
                cmd.Parameters.AddWithValue("@numeroDocumento", numeroDocumento);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cn.Open();

                da.Fill(tabla);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo la siguiente excepcion" + ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
        public static DataTable obtenerTipoDocumento()
        {
            string consulta = "SELECT DISTINCT TipoDocumento FROM Suscriptor";
            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta,cn);
            try
            {
                cmd.Parameters.Clear();


                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cn.Open();

                da.Fill(tabla);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo la siguiente excepcion" + ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
        public static int obtenerUltimoId()
        {
            string consulta = "SELECT MAX(IdSuscriptor) FROM Suscriptor";

            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {

                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                int resultado = (int)cmd.ExecuteScalar();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo la siguiente excepcion" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public static bool registrarSuscriptor(Clases_Negocio.Suscriptor suscriptor)
        {
            string consulta = "INSERT INTO Suscriptor (IdSuscriptor,Nombre,Apellido,NumeroDocumento,TipoDocumento,Direccion,Telefono,Email,NombreUsuario,Password) VALUES (@idSuscriptor,@nombre,@apellido,@numeroDocumento,@tipoDocumento,@direccion,@telefono,@email,@nombreUsuario,@password)";

            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                int ultimoID = obtenerUltimoId() + 1;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idSuscriptor", ultimoID);
                cmd.Parameters.AddWithValue("@nombre", suscriptor.Nombre);
                cmd.Parameters.AddWithValue("@apellido", suscriptor.Apellido);
                cmd.Parameters.AddWithValue("@numeroDocumento", suscriptor.NumeroDocumento);
                cmd.Parameters.AddWithValue("@tipoDocumento", suscriptor.TipoDocumento);
                cmd.Parameters.AddWithValue("@direccion", suscriptor.Direccion);
                cmd.Parameters.AddWithValue("@telefono", suscriptor.Telefono);
                cmd.Parameters.AddWithValue("@email", suscriptor.Email);
                cmd.Parameters.AddWithValue("@nombreUsuario", suscriptor.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", suscriptor.Password);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                cmd.Connection = cn;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Se produjo la siguiente excepcion" + ex.Message);

            }
            finally
            {
                cn.Close();
            }
        }
        public static bool modificarSuscriptor(Clases_Negocio.Suscriptor suscriptor)
        {
            string consulta = "UPDATE Suscriptor SET Nombre = @nombre, Apellido = @apellido, Direccion = @direccion, Telefono = @telefono, Email = @email, Password = @password";
            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", suscriptor.Nombre);
                cmd.Parameters.AddWithValue("@apellido", suscriptor.Apellido);
                cmd.Parameters.AddWithValue("@direccion", suscriptor.Direccion);
                cmd.Parameters.AddWithValue("@telefono", suscriptor.Telefono);
                cmd.Parameters.AddWithValue("@email", suscriptor.Email);
                cmd.Parameters.AddWithValue("@password", suscriptor.Password);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                cmd.Connection = cn;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Se produjo la siguiente excepcion" + ex.Message);

            }
            finally
            {
                cn.Close();
            }
        }
        #endregion
    }
}
