using System.Data;
using System.Security.Cryptography.X509Certificates;
using MySqlConnector;
using pruebaAPI_BD.Models;

namespace pruebaAPI_BD.Datos
{
    public class Db
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataSet ds;
        public Db()
        {
            string cadenaConexion = "server=b9gbnoonn2o8i5etcard-mysql.services.clever-cloud.com;Port=3306;user id=ulikf55afsa6qbr2;password=rVHGltw9cIx4tIECuOgh;database=b9gbnoonn2o8i5etcard;persistsecurityinfo=True";
            con = new MySqlConnection();
            con.ConnectionString = cadenaConexion;
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }
        
        //me da todos los libro
        public List<Libro> ObtenerLibros()
        {
            List<Libro> libros = new List<Libro>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Libro";

                cmd.Connection.Open();
                ds = new DataSet();

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var libro = new Libro()
                        {
                            idlibro = Convert.ToInt32(row["idLibro"].ToString()),
                            titulo = row["titulo"].ToString(),
                            autor = row["autor"].ToString(),
                            precio = Convert.ToDecimal(row["precio"].ToString()),
                            urlPortada = row["urlPortada"].ToString(),
                            idgenero = Convert.ToInt32(row["idGenero"].ToString()),
                            Descripcion = row["Descripcion"].ToString()

                        };
                        libros.Add(libro);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return libros;
        }

        //busca un libro por id
        public List<Libro> DameUnLibro(string _idlibro)
        {
            List<Libro> libros = new List<Libro>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("SELECT * FROM Libro where idlibro = " + _idlibro + ";");

                cmd.Connection.Open();
                ds = new DataSet();

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var libro = new Libro()
                        {
                            idlibro = Convert.ToInt32(row["idLibro"].ToString()),
                            titulo = row["titulo"].ToString(),
                            autor = row["autor"].ToString(),
                            precio = Convert.ToDecimal(row["precio"].ToString()),
                            urlPortada = row["urlPortada"].ToString(),
                            idgenero = Convert.ToInt32(row["idGenero"].ToString()),
                            Descripcion = row["Descripcion"].ToString()

                        };
                        libros.Add(libro);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return libros;
        }


        //inserta un libro
        public int InsertarLibro(LibroRequest libritolindo)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO libro(titulo, autor, precio, stock,idgenero) values (@titulo,@autor,@precio, @url, @idgenero, @Desc)";
                cmd.Parameters.Add(new MySqlParameter("@titulo", libritolindo.titulo));
                cmd.Parameters.Add(new MySqlParameter("@autor", libritolindo.autor));
                cmd.Parameters.Add(new MySqlParameter("@precio", libritolindo.precio));
                cmd.Parameters.Add(new MySqlParameter("@idgenero", libritolindo.idgenero));
                cmd.Parameters.Add(new MySqlParameter("@url", libritolindo.urlPortada));
                cmd.Parameters.Add(new MySqlParameter("@Desc", libritolindo.Descripcion));


                cmd.Connection.Open();
                int insertedId = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (insertedId > 0)
                    return insertedId;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { cmd.Connection.Close(); }
            return 0;
        }

        //obtiene un usuario solicitado
        public List<Usuarios> ObtenerUsuario(string name, string password)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("SELECT * FROM admins WHERE nombreAdmin = @name and contraAdmin = @password");

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.Connection.Open();
                ds = new DataSet();

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var usuario = new Usuarios()
                        {
                            Id = Convert.ToInt32(row["idAdmin"].ToString()),
                            Name = row["nombreAdmin"].ToString(),
                            Password = row["contraAdmin"].ToString(),


                        };
                        usuarios.Add(usuario);
                    }
                }
            }

            catch (Exception ex) { throw;  }

            finally { cmd.Connection.Close(); }

            return usuarios;
            
        }

        //busqueda de usuarios (Clientes)
        public List<Cliente> ObtenerUnCliente(string name, string password)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmd.CommandText = ("SELECT * FROM Cliente WHERE nombre = @name and contra = @password");

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);

                
            }
            catch (Exception ex) { throw; }
            finally { cmd.Connection.Close(); }
            return clientes;
        }
    }
}
