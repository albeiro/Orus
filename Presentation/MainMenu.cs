using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORUS.Presentation
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            PersonalControl personalControl = new();
            personalControl.Dock = DockStyle.Fill;

            panelFather.Controls.Clear();
            panelFather.Controls.Add(personalControl);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            panelWelcome.Dock = DockStyle.Fill;
        }
    }
}
