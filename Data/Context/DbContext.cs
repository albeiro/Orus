using System.Data;
using System.Data.SqlClient;

namespace ORUS.Data.Context
{
    public class DbContext
    {
        public static string stringConnection = "Data Source=LAB; Initial Catalog=orus369; Integrated Security=true";
        public static SqlConnection connect = new(stringConnection);

        public static void Open()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }

        public static void Close()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
    }
}
