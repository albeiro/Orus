using ORUS.Data.Context;
using ORUS.Logic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORUS.Data
{
    public class DPersonal
    {
        public bool InsertPersonal(LPersonal lpersonal)
        {
            try
            {
                DbContext.Open();
                SqlCommand sqlCommand = new("Sp_InsertPersonal", DbContext.connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Nombre", lpersonal.Nombres);
                sqlCommand.Parameters.AddWithValue("@SueldoPorHora", lpersonal.SueldoPorHora);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                DbContext.Close();
            }
        }
    }
}
