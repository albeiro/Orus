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
                sqlCommand.Parameters.AddWithValue("@Identificacion", lpersonal.Identificacion);
                sqlCommand.Parameters.AddWithValue("@Nombre", lpersonal.Nombres);
                sqlCommand.Parameters.AddWithValue("@Pais", lpersonal.Pais);
                sqlCommand.Parameters.AddWithValue("@CargoId", lpersonal.CargoId);
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
        public bool UpdatePersonal(LPersonal lpersonal)
        {
            try
            {
                DbContext.Open();
                SqlCommand sqlCommand = new("Sp_UpdatePersonal", DbContext.connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", lpersonal.Id);
                sqlCommand.Parameters.AddWithValue("@Identificacion", lpersonal.Identificacion);
                sqlCommand.Parameters.AddWithValue("@Nombre", lpersonal.Nombres);
                sqlCommand.Parameters.AddWithValue("@Pais", lpersonal.Pais);
                sqlCommand.Parameters.AddWithValue("@CargoId", lpersonal.CargoId);
                sqlCommand.Parameters.AddWithValue("@SueldoPorHora", lpersonal.SueldoPorHora);
                sqlCommand.Parameters.AddWithValue("@Estado", lpersonal.Estado);
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
        public bool DeletePersonal(LPersonal lpersonal)
        {
            try
            {
                DbContext.Open();
                SqlCommand sqlCommand = new("Sp_DeletePersonal", DbContext.connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", lpersonal.Id);
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
        public void ShowPersonal(ref DataTable datatable, int desde, int hasta) {
            try
            {
                DbContext.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_ShowPersonal", DbContext.connect);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Deste", desde);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                sqlDataAdapter.Fill(datatable);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally {
                DbContext.Close();
            }
        }
        public void SearchPersonal(ref DataTable datatable, int desde, int hasta, string buscar)
        {
            try
            {
                DbContext.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_SearchPersonal", DbContext.connect);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Deste", desde);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Buscar", buscar);
                sqlDataAdapter.Fill(datatable);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                DbContext.Close();
            }
        }

    }
}
