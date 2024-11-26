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
            string cadenaConexion = "server=localhost;Port=3306;user id=root;password=1234;database=cafecitos;persistsecurityinfo=True";
            con = new MySqlConnection();
            con.ConnectionString = cadenaConexion;
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }
        
        public List<Cafe> ObtenerCafe()
        {
            List<Cafe> cafes = new List<Cafe>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Cafe";

                cmd.Connection.Open();
                ds = new DataSet();

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var cafe = new Cafe()
                        {
                            id = Convert.ToInt32(row["id"].ToString()),
                            nombre = row["id"].ToString(),
                            descripcion = row["descripcion"].ToString(),
                            precio = Convert.ToDouble(row["precio"].ToString()),
                            marca = row["marca"].ToString()

                        };
                        cafes.Add(cafe);
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

            return cafes;
        }

    }
}
