using ORUS.Data.Context;
using ORUS.Logic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ORUS.Data
{
    class DCargo
    {
        public bool InsertCargo(LCargo lCargo)
        {
            try
            {
                DbContext.Open();
                SqlCommand sqlCommand = new("Sp_InsertCargo", DbContext.connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Nombre", lCargo.Nombre);
                sqlCommand.Parameters.AddWithValue("@SueldoPorHora", lCargo.SueldoPorHora);
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
        public bool UpdatePersonal(LCargo lCargo)
        {
            try
            {
                DbContext.Open();
                SqlCommand sqlCommand = new("Sp_UpdatePersonal", DbContext.connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", lCargo.Id);
                sqlCommand.Parameters.AddWithValue("@Identificacion", lCargo.Identificacion);
                sqlCommand.Parameters.AddWithValue("@Nombre", lCargo.Nombres);
                sqlCommand.Parameters.AddWithValue("@Pais", lCargo.Pais);
                sqlCommand.Parameters.AddWithValue("@CargoId", lCargo.CargoId);
                sqlCommand.Parameters.AddWithValue("@SueldoPorHora", lCargo.SueldoPorHora);
                sqlCommand.Parameters.AddWithValue("@Estado", lCargo.Estado);
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
        public bool DeletePersonal(LCargo lCargo)
        {
            try
            {
                DbContext.Open();
                SqlCommand sqlCommand = new("Sp_DeletePersonal", DbContext.connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", lCargo.Id);
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
        public void ShowPersonal(ref LCargo datatable, int desde, int hasta)
        {
            try
            {
                DbContext.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_ShowPersonal", DbContext.connect);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Deste", desde);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
               // sqlDataAdapter.Fill(datatable);
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
