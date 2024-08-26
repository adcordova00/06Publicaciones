using _06Publicaciones.config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Publicaciones.Models
{
    internal class Venta
    {
        public string IdTienda { get; set; }
        public string NumeroOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public int Cantidad { get; set; }
        public string MetodoPago { get; set; }
        public string IdPublicacion { get; set; }

        // Constructor vacío
        public Venta() { }

        // Método para insertar un nuevo autor y retornar el registro insertado
        public static Venta InsertarVenta(Venta venta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "INSERT INTO sales (stor_id, ord_num, ord_date, qty, payterms, title_id) VALUES (@IdTienda, @NumeroOrden, @FechaOrden, @Cantidad, @MetodoPago, @IdPublicacion)";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdTienda", venta.IdTienda);
                        comando.Parameters.AddWithValue("@NumeroOrden", venta.NumeroOrden);
                        comando.Parameters.AddWithValue("@FechaOrden", venta.FechaOrden);
                        comando.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                        comando.Parameters.AddWithValue("@MetodoPago", venta.MetodoPago);
                        comando.Parameters.AddWithValue("@IdPublicacion", venta.IdPublicacion);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Venta
                                {
                                    IdTienda = lector["stor_id"].ToString(),
                                    NumeroOrden = lector["ord_num"].ToString(),
                                    FechaOrden = Convert.ToDateTime(lector["ord_date"]),
                                    Cantidad = Convert.ToInt32(lector["qty"]),
                                    MetodoPago = lector["payterms"].ToString(),
                                    IdPublicacion = lector["title_id"].ToString(),
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al insertar la venta.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar la venta.");
            }
            return null;
        }

        // Método para actualizar un autor existente y retornar "OK"
        public static string ActualizarVenta(Venta venta)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "UPDATE sales SET stor_id = @IdTienda, ord_num = @NumeroOrden, ord_date = @FechaOrden, qty = @Cantidad, payterms = @MetodoPago, title_id = @IdPublicacion  WHERE ord_num = @NumeroOrden";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        //sql inyection
                        comando.Parameters.AddWithValue("@IdEditorial", editorial.IdEditorial);
                        comando.Parameters.AddWithValue("@Nombre", editorial.Nombre);
                        comando.Parameters.AddWithValue("@Ciudad", editorial.Ciudad);
                        comando.Parameters.AddWithValue("@Estado", editorial.Estado);
                        comando.Parameters.AddWithValue("@Pais", editorial.Pais);

                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al actualizar la editorial.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar la editorial.");
                return "Error";
            }
        }

        // Método para eliminar un autor y retornar "OK"
        public static string EliminarEditorial(string idEditorial)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "DELETE FROM publishers WHERE pub_id = @IdEditorial";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEditorial", idEditorial);
                        comando.ExecuteNonQuery();
                    }
                }
                return "OK";
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al eliminar la editorial.");
                return "Error SQL";
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al eliminar la editorial.");
                return "Error";
            }
        }

        // Método para obtener un trabajo por ID
        public static Editorial ObtenerEditorialPorId(string idEditorial)
        {
            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM publishers WHERE pub_id = @IdEditorial";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdEditorial", idEditorial);

                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Editorial
                                {
                                    IdEditorial = lector["pub_id"].ToString(),
                                    Nombre = lector["pub_name"].ToString(),
                                    Ciudad = lector["city"].ToString(),
                                    Estado = lector["state"].ToString(),
                                    Pais = lector["country"].ToString(),
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener la editorial");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la editorial");
            }
            return null;
        }
        public static List<Editorial> ListEditoriales()
        {
            var editoriales = new List<Editorial>();

            try
            {
                using (var conexion = Conexion.GetConnection())
                {
                    var consulta = "SELECT * FROM publishers";

                    using (var comando = new SqlCommand(consulta, conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                editoriales.Add(new Editorial
                                {
                                    IdEditorial = lector["pub_id"].ToString(),
                                    Nombre = lector["pub_name"].ToString(),
                                    Ciudad = lector["city"].ToString(),
                                    Estado = lector["state"].ToString(),
                                    Pais = lector["country"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ErrorHandler.ManejarErrorSql(ex, "Error al obtener la lista de editoriales.");
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la lista de editoriales.");
            }
            return editoriales;
        }
    }
}
