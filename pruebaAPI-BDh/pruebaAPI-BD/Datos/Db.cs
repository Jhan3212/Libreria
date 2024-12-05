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
                cmd.CommandText = "SELECT * FROM Libro WHERE idUsuario IS NULL";

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
        //obtiene todos los libros no importa el usuaroio
        public List<Libro> ObtenerTodosLibros()
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

        // --------------------------------------------------------

        public List<Libro> ObtenerLibroXuser (int _id)
        {
            List<Libro> libros = new List<Libro>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Libro where idUsuario = "+ _id +";";

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



        //---------------------------------------------------------

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
                cmd.CommandText = "INSERT INTO Libro (titulo, autor, precio, urlPortada, idgenero, Descripcion) values (@titulo,@autor,@precio, @url, @idgenero, @Desc)";
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

        //Actualiza los libros por los admis 
        public int ActualizarLibro(int id, LibroRequest librito)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Libro SET titulo = @titulo, autor = @autor, precio = @precio, urlPortada = @portada, idGenero = @genero,  descripcion = @descripcion WHERE idLibro =" + id;
                cmd.Parameters.Add(new MySqlParameter("@titulo", librito.titulo));
                cmd.Parameters.Add(new MySqlParameter("@autor", librito.autor));
                cmd.Parameters.Add(new MySqlParameter("@precio", librito.precio));
                cmd.Parameters.Add(new MySqlParameter("@portada", librito.urlPortada));
                cmd.Parameters.Add(new MySqlParameter("@genero", librito.idgenero));
                cmd.Parameters.Add(new MySqlParameter("@descripcion", librito.Descripcion));



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



        //esto elimina un usuario cliente
        public int EliminarLibro(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Libro WHERE idLibro =" + id;

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
        //obtenr todos los clientes
        public List<Cliente> ObtenerTotalClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Cliente";

                cmd.Connection.Open();

                ds = new DataSet();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var cliente = new Cliente()
                        {
                            idCliente = Convert.ToInt32(row["idCliente"]),
                            nombre = row["nombre"].ToString(),
                            pass = row["Pass"].ToString(),
                            direccion = row["direccion"].ToString(),
                            email = row["email"].ToString()
                        };
                        clientes.Add(cliente);
                    }
                }


            }
            catch (Exception ex)
            {
                // Log o imprimir detalles del error
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            finally { cmd.Connection.Close(); }
            return clientes;
        }

        //busqueda de usuarios (Clientes)
        public List<Cliente> ObtenerUnCliente(string name, string password)
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Cliente WHERE nombre = @name AND Pass = @password";

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

                cmd.Connection.Open();

                ds = new DataSet();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var cliente = new Cliente()
                        {
                            idCliente = Convert.ToInt32(row["idCliente"]),
                            nombre = row["nombre"].ToString(),
                            pass = row["Pass"].ToString(),
                            direccion = row["direccion"].ToString(),
                            email = row["email"].ToString()
                        };
                        clientes.Add(cliente);
                    }
                }


            }
            catch (Exception ex)
            {
                // Log o imprimir detalles del error
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            finally { cmd.Connection.Close(); }
            return clientes;
        }

        //esto inserta un cliente desde el usuario admin
        public int InsertarCliente(ClienteRequest cliente)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("INSERT INTO Cliente (nombre, direccion, email, Pass) values (@name, @direccion, @email, @Pass)");
                cmd.Parameters.Add(new MySqlParameter("@name", cliente.nombre));
                cmd.Parameters.Add(new MySqlParameter("@direccion", cliente.direccion));
                cmd.Parameters.Add(new MySqlParameter("@email", cliente.email));
                cmd.Parameters.Add(new MySqlParameter("@Pass", cliente.pass));


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

        //esto actualiza un usuario clientee
        public int ActualizarCliente(int id, ClienteRequest _usuario)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Cliente SET nombre = @n, direccion = @d, Pass = @p, email = @e WHERE idCliente = " + id;
                cmd.Parameters.Add(new MySqlParameter("@n", _usuario.nombre));
                cmd.Parameters.Add(new MySqlParameter("@d", _usuario.direccion));
                cmd.Parameters.Add(new MySqlParameter("@p", _usuario.pass));
                cmd.Parameters.Add(new MySqlParameter("@e", _usuario.email));

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

        //esto elimina un usuario cliente
        public int EliminarCliente(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Cliente WHERE idCliente =" + id;

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
        

        //compra de libros
        public  int compraLibro(int idUser, int idLibro )
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Libro SET idUsuario = " + idUser + " WHERE idLibro = "+ idLibro;

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

        //vender libro
        public int venderLibro(int idLibro)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Libro SET idUsuario = null WHERE idLibro = " + idLibro;

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

    }
}
