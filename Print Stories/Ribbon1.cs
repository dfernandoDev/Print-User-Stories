using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using System.Threading.Tasks;
using RallyRestApi.AuthenticatorUI;
using Microsoft.Office.Interop.PowerPoint;

namespace PrintUserStories
{
    public partial class Ribbon1
    {
        private string rallyUrl = "";
        private string apiUrl = "";
        private bool authenticated = false;
        private string sessionID = "";

        // Rally
        int selectedWorkspaceID = 0;
        int selectedProjectID = 0;
        RallyRestApi.Subscriptions.Subscription subscription;
        RallyRestApi.Workspaces.QueryResult workspaces;
        RallyRestApi.Projects.QueryResult projects;
        RallyRestApi.Iteration.QueryResult iterations;
        RallyRestApi.Iteration.Result selectedIteration;

        private RallyRestApi.RestClient rallyRestClient = new RallyRestApi.RestClient();

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            rallyUrl = Properties.Settings.Default.Rally_SSO_URL;
        }

        private void ConnectRally(object sender, RibbonControlEventArgs e)
        {
            frmAuthenticate frm = new frmAuthenticate();
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

                Task<RallyRestApi.Projects.QueryResult> taskProjects = Task.Run(async () => await rallyRestClient.GetProjectsAsync(workspaces.Results[0].Projects._ref));
                taskProjects.Wait();
                projects = taskProjects.Result;

                RefreshWorkspaceAndProjectSelections();
                EnableButtons(true);
            }
        }

        private void EnableButtons(bool state)
        {
            btnSelectWrkspProj.Enabled = state;

            btnIteration.Enabled = state;
            btnRelease.Enabled = state;
            btnBacklog.Enabled = state;
        }

        private void RefreshWorkspaceAndProjectSelections()
        {
            editBoxWorkspace.Text = workspaces.Results[selectedWorkspaceID].Name;
            editBoxProject.Text = projects.Results[selectedProjectID].Name;
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            frmSettings setting = new frmSettings();
            setting.WebUrl = rallyUrl;
            DialogResult result = setting.ShowDialog();

            if (result == DialogResult.OK)
            {

            }
            else if (result == DialogResult.Yes)
            {
                rallyUrl = setting.WebUrl;
                ConnectRally(sender, e);
            }
        }

        private void btnSelectWrkspProj_Click(object sender, RibbonControlEventArgs e)
        {
            frmWorkspaceSelector WrkspcProjSel = new frmWorkspaceSelector();
            WrkspcProjSel.Workspaces = workspaces;
            WrkspcProjSel.SelectedWorkspaceID = selectedWorkspaceID;
            WrkspcProjSel.Projects = projects;
            WrkspcProjSel.SelectedProjectID = selectedProjectID;

            if (WrkspcProjSel.ShowDialog() == DialogResult.OK)
            {
                selectedProjectID = WrkspcProjSel.SelectedProjectID;
                selectedWorkspaceID = WrkspcProjSel.SelectedWorkspaceID;
                rallyRestClient.Project = projects.Results[selectedProjectID]._ref;
                RefreshWorkspaceAndProjectSelections();
            }
        }

        private void btnIteration_Click(object sender, RibbonControlEventArgs e)
        {
            Task<RallyRestApi.Iteration.QueryResult> taskIterations = Task.Run(async () => await rallyRestClient.GetIterationsAsync());
            taskIterations.Wait();

            iterations = taskIterations.Result;

            RallyRestApi.Iteration.Iterations frm = new RallyRestApi.Iteration.Iterations();
            frm.IterationList = iterations;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.selectedIteration = frm.SelectedIteration;

                Task<RallyRestApi.Artifacts.QueryResult> taskArtifact = Task.Run(async () => await rallyRestClient.GetArtifactAsync(this.selectedIteration));
                taskArtifact.Wait();

                RallyRestApi.Artifacts.QueryResult artifacts = taskArtifact.Result;

                //Presentation pres = CreateNewPrintStoriesPPT();
                MessageBox.Show(artifacts.TotalResultCount.ToString());
            }
        }

        private void btnRelease_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void btnBacklog_Click(object sender, RibbonControlEventArgs e)
        {
            
        }

        private Presentation CreateNewPrintStoriesPPT()
        {
            string MyDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string PptTemplatePath = MyDocsPath + PrintUserStoriesConstants.TEMPLATE_PATH;
            //Presentation pres = Globals.ThisAddIn.Application.Presentations.Open(MyDocsPath + "\\Custom Office Templates\\Pin Debit User Story Board.potx", Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue);
            Presentation pres = PowerPointUtilities.CreateNewPptFromTemplate(PptTemplatePath);
            return pres;
        }

        private void DisplayAllTextPlaceholders()
        {
            Presentation pres = CreateNewPrintStoriesPPT();
            PowerPointUtilities.DeleteAllSlides(pres);
            Slide slide = PowerPointUtilities.InsertNewSlide(pres);
            foreach (Shape s in slide.Shapes)
            {
                s.TextFrame.TextRange.Text = s.Name + "[" + s.Id + "]";
                System.Diagnostics.Debug.WriteLine(s.Name + "[" + s.Id + "]");
            }

            slide.Shapes[PrintUserStories.PrintUserStoriesConstants.TEXT_PLACEHOLDER_TITLE].TextFrame.TextRange.Text = "The New Title";
        }
    }
}
