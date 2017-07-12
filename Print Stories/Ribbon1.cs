using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using System.Threading.Tasks;
using RallyRestApi.Workspaces;

namespace PrintUserStories
{
    public partial class Ribbon1
    {
        private string rallyUrl = "";
        private string apiUrl = "";
        private bool authenticated = false;
        private string sessionID = "";

        // Rally
        RallyRestApi.Subscriptions.Subscription subscription;
        RallyRestApi.Workspaces.QueryResult workspaces;

        private RallyRestApi.RestClient rallyRestClient = new RallyRestApi.RestClient();

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            rallyUrl = Properties.Settings.Default.Rally_SSO_URL;
        }

        private void ConnectRally(object sender, RibbonControlEventArgs e)
        {
            RallyAuthenticator.frmAuthenticate frm = new RallyAuthenticator.frmAuthenticate();
            frm.WebURL = rallyUrl;

            DialogResult result = frm.ShowDialog();
            authenticated = (result == DialogResult.OK);

            if (authenticated)
            {
                this.apiUrl = frm.ApiURL;
                rallyRestClient.ApiURL = this.apiUrl;
                this.sessionID = frm.SessionID;
                rallyRestClient.SessionID = this.sessionID;

                Task<RallyRestApi.Subscriptions.Subscription> taskSubscription = Task.Run(async () => await rallyRestClient.GetSubscriptionAsync());
                taskSubscription.Wait();
                subscription = taskSubscription.Result;

                Task<RallyRestApi.Workspaces.QueryResult> taskWorkspaces = Task.Run(async () => await rallyRestClient.GetWorkspacesAsync(subscription.Workspaces._ref));
                taskWorkspaces.Wait();
                workspaces = taskWorkspaces.Result;

                editBoxWorkspace.Text = workspaces.Results[0].Name;
                btnSelectWrkspProj.Enabled = true;
            }
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            String url = Properties.Settings.Default.Rally_SSO_URL;

            RallyAuthenticator.frmSettings setting = new RallyAuthenticator.frmSettings();

            DialogResult result = setting.ShowDialog();

        }
    }
}
