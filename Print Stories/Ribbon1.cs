using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using Rally.RestApi;

namespace Print_Stories
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void ConnectRally(object sender, RibbonControlEventArgs e)
        {
            RallyRestApi restApi = new RallyRestApi();
            String url = "";

            frmAuth frm = new frmAuth();
            frm.SSO_URL = url;
            frm.ShowDialog();

            MessageBox.Show("hello");
        }
    }
}
