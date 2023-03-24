using ORUS.Data;
using ORUS.Logic;
using System;
using System.Windows.Forms;

namespace ORUS.Presentation
{
    public partial class PersonalControl : UserControl
    {
        public PersonalControl()
        {
            InitializeComponent();
            styleInictial();
        }

        private void styleInictial()
        {
            style.button(ref btnLeft);
            style.button(ref btnLeft);
        }

        private void PersonalControl_Load(object sender, EventArgs e)
        {


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btSavePersonal_Click(object sender, EventArgs e)
        {
            DPersonal dPersonal = new();
            LPersonal lPersonal = new()
            {
                Identificacion = tbIdentificacion.Text,
                Nombres = tbNombre.Text,
                Pais = cbPais.Text,
                CargoId = 1,//tbCargo.Text,
                SueldoPorHora = Convert.ToDouble(tbSueldoPorHora.Text)

            };

           if (dPersonal.InsertPersonal(lPersonal))
            {
                MessageBox.Show("Todo bien");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnDeletePersonal_Click(object sender, EventArgs e)
        {
            DPersonal dPersonal = new();
            LPersonal lPersonal = new()
            {
                Id = 1
            };

            if (dPersonal.DeletePersonal(lPersonal))
            {
                MessageBox.Show("Todo bien");
            }
        }

        private void btnCreatePersonal_Click(object sender, EventArgs e)
        {
            flpPaginado.Visible = false;
            panelSearchCargo.Visible = false;
            panelCreatePersonal.Visible = true;
            fromCreatePersonalClean();
        }

        private void fromCreatePersonalClean()
        {
            tbIdentificacion.Clear();
            tbNombre.Clear();
            tbSueldoPorHora.Clear();
            cbPais.SelectedIndex = 0;
            tbCargo.Clear();

        }

        private void lbCreateCargo_Click(object sender, EventArgs e)
        {
            panelCreateCargo.Visible = true;
            panelCreateCargo.BringToFront();
            
        }

        private void btnSaveCargo_Click(object sender, EventArgs e)
        {
            LPersonal lPersonal = new();
        }
    }
}
