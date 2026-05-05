using BuscarServidor;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GestionAlojamientos
    {
        private String conexion;
        public GestionAlojamientos(out String errorServidor)
        {
            conexion = "Data Source=" + MiServidor.Servidor(out errorServidor) + ";Initial Catalog=ALOJAMIENTOSIKERSANCHEZ;Integrated Security=True";

        }
        // El constructor intentará conectar con el servidor que le devuelva MiServidor.Servidor
        // Si no puede conectar, devolverá un mensaje con el error

        public List<Clientela> ObtenerClientes()
        {
            List<Clientela> clientes = new List<Clientela>();
            string consulta = "SELECT * FROM CLIENTELA";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(new Clientela(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4)
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                }
            }

            return clientes;
        }

        public List<Establecimiento> ObtenerEstablecimientos()
        {
            List<Establecimiento> establecimientos = new List<Establecimiento>();
            string consulta = "SELECT * FROM ESTABLECIMIENTOS";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                establecimientos.Add(new Establecimiento(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetInt32(5)
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                }
            }

            return establecimientos;
        }

        public List<UnidadAlojamiento> ObtenerUnidadesAlojamiento()
        {
            List<UnidadAlojamiento> unidadesAlojamiento = new List<UnidadAlojamiento>();
            string consulta = "SELECT * FROM UNIDADES_ALOJAMIENTO";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                unidadesAlojamiento.Add(new UnidadAlojamiento(
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    reader.IsDBNull(2) ? null : reader.GetString(2),
                                    reader.GetInt32(3),
                                    reader.IsDBNull(4) ? null : reader.GetString(4),
                                    (float)reader.GetDouble(5),
                                    reader.IsDBNull(6) ? null : reader.GetString(6)
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                }
            }

            return unidadesAlojamiento;
        }

        public List<Reserva> ObtenerReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            string consulta = "SELECT * FROM RESERVAS";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reservas.Add(new Reserva(
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    reader.GetInt32(2),
                                    reader.GetInt32(3),
                                    reader.IsDBNull(4) ? default(DateTime) : reader.GetDateTime(4),
                                    reader.GetDateTime(5),
                                    reader.GetDateTime(6),
                                    reader.GetInt32(7),
                                    reader.IsDBNull(8) ? null : reader.GetString(8),       
                                    reader.IsDBNull(9) ? (float?)null : (float)reader.GetDouble(9),
                                    (float)reader.GetDouble(10)                            
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                }
            }

            return reservas;
        }

        public List<Pago> ObtenerPagos()
        {
            List<Pago> pagos = new List<Pago>();
            string consulta = "SELECT * FROM PAGOS";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                pagos.Add(new Pago(
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    (float)reader.GetDouble(2),
                                    reader.IsDBNull(3) ? default(DateTime) : reader.GetDateTime(3),
                                    reader.GetString(4)
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                }
            }

            return pagos;
        }

        public bool EliminarReserva(int idReserva)
        {
            string consulta = "DELETE FROM RESERVAS WHERE ID_RESERVA = @idReserva";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@idReserva", idReserva);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                    return false;
                }
            }
        }

        public bool EliminarPago(int idPago)
        {
            string consulta = "DELETE FROM PAGOS WHERE ID_PAGO = @idPago";
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@idPago", idPago);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se ha podido ejecutar la consulta: ", ex);
                    return false;
                }
            }
        }



    }
}
