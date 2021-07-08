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
                Nombres = tbNombre.Text,
                SueldoPorHora = Convert.ToDouble(tbSueldoPorHora.Text)
            };

           if (dPersonal.InsertPersonal(lPersonal))
            {
                MessageBox.Show("Todo bien");
            }

        }
    }
}
