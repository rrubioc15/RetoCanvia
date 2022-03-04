using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiCanvia.Models;

namespace WebApiCanvia.Data
{
    public class PeliculaData
    {
        public static bool Registrar(Pelicula oPelicula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oPelicula.Nombre);
                cmd.Parameters.AddWithValue("@director", oPelicula.Director);
                cmd.Parameters.AddWithValue("@categoria", oPelicula.Categoria);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Pelicula oPelicula)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpelicula", oPelicula.IdPelicula);
                cmd.Parameters.AddWithValue("@nombre", oPelicula.Nombre);
                cmd.Parameters.AddWithValue("@director", oPelicula.Director);
                cmd.Parameters.AddWithValue("@categoria", oPelicula.Categoria);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Pelicula> Listar()
        {
            List<Pelicula> oListaPelicula = new List<Pelicula>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaPelicula.Add(new Pelicula()
                            {
                                IdPelicula = Convert.ToInt32(dr["IdPelicula"]),
                                Nombre = dr["Nombre"].ToString(),
                                Director = dr["Director"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                Estado = Convert.ToByte(dr["Estado"]),
                            });
                        }
                    }
                    return oListaPelicula;
                }
                catch (Exception ex)
                {
                    return oListaPelicula;
                }
            }
        }


        public static List<Pelicula> Paginar(int id, int id2)
        {
            List<Pelicula> oListaPelicula = new List<Pelicula>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_pagination", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@registros_por_pagina", id);
                cmd.Parameters.AddWithValue("@pagina", id2);
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaPelicula.Add(new Pelicula()
                            {
                                IdPelicula = Convert.ToInt32(dr["IdPelicula"]),
                                Nombre = dr["Nombre"].ToString(),
                                Director = dr["Director"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                Estado = Convert.ToByte(dr["Estado"]),
                            });
                        }
                    }
                    return oListaPelicula;
                }
                catch (Exception ex)
                {
                    return oListaPelicula;
                }
            }
        }


        public static Pelicula Obtener(int idPelicula)
        {
            Pelicula oPelicula = new Pelicula();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpelicula", idPelicula);
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oPelicula = new Pelicula()
                            {
                                IdPelicula = Convert.ToInt32(dr["IdPelicula"]),
                                Nombre = dr["Nombre"].ToString(),
                                Director = dr["Director"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                Estado = Convert.ToByte(dr["Estado"]),
                            };
                        }

                    }
                    return oPelicula;
                }
                catch (Exception ex)
                {
                    return oPelicula;
                }
            }
        }


        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpelicula", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static bool Desactivar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_desactivar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpelicula", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static bool Activar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("psp_activar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpelicula", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}