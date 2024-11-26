using System.Data;
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
            string cadenaConexion = "server=localhost;Port=3306;user id=root;password=1234;database=libreriadb;persistsecurityinfo=True";
            con = new MySqlConnection();
            con.ConnectionString = cadenaConexion;
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }
        
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
                            stock = Convert.ToInt32(row["stock"].ToString()),
                            idgenero = Convert.ToInt32(row["idGenero"].ToString())

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

    }
}
