using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Acceso_a_Datos
{
    public class Suscripcion
    {
        public static string conexion = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;

        #region Metodos
        public static int obtenerUltimoId()
        {
            string consulta = "SELECT MAX(IdAsociacion) FROM Suscripcion";

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
        public static string obtenerFechaAlta(int idSuscriptor)
        {
            string consulta = "SELECT FechaAlta FROM Suscripcion WHERE IdSuscriptor = @idSuscriptor";

            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idSuscriptor", idSuscriptor);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                string resultado = Convert.ToString(cmd.ExecuteScalar());

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
        public static bool registrarSuscripcion(int IdSuscriptor)
        {
            string consulta = "INSERT INTO Suscripcion VALUES (@idAsociacion, @idSuscriptor, @fechaAlta, @fechaFin, @motivoFin)";

            SqlConnection cn = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                int ultimoId = obtenerUltimoId() + 1;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idAsociacion", ultimoId);
                cmd.Parameters.AddWithValue("@idSuscriptor", IdSuscriptor);
                cmd.Parameters.AddWithValue("@fechaAlta", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@fechaFin", DBNull.Value);
                cmd.Parameters.AddWithValue("@motivoFin", DBNull.Value);

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
