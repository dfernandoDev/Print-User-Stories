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
        private string rallyUrl = "";
        private bool authenticated = false;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void ConnectRally(object sender, RibbonControlEventArgs e)
        {
            //RallyRestApi restApi = new RallyRestApi();

            frmAuth frm = new frmAuth();
            frm.SSO_URL = rallyUrl;
            frm.ShowDialog();

        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            String url = Properties.Settings.Default.Rally_SSO_URL;

            frmSettings setting = new frmSettings();

        }
    }
}
