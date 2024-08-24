using System.Data;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Client
{
    public partial class Form1 : Form
    {
        ClientVM Client;
        List<Post> PostPool;
        Panel[] controlsPanel;
        ToolStripMenuItem[] controlsMenuRoute;
        public Form1()
        {
            Client = new ClientVM("http://api.alterworld.pp.ua/api/v1");
            InitializeComponent();
            controlsPanel = new Panel[] { authPanel, regPanel, profilePanel, sendPanel };
            controlsMenuRoute = new ToolStripMenuItem[] { authMenuRoute, regMenuRoute, accountMenuRoute };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            PostPool = await Client.PullPosts();

            foreach (var panel in controlsPanel) panel.Visible = false;
            foreach (var route in controlsMenuRoute) route.Visible = false;

            authPanel.Visible = true;
            authMenuRoute.Visible = true;
            regMenuRoute.Visible = true;

            if(Client.isConnect)
            {
                foreach (var panel in controlsPanel) panel.Visible = false;
                foreach (var route in controlsMenuRoute) route.Visible = false;
                profilePanel.Visible = true;
                accountMenuRoute.Visible = true;
            }
                postsPanel.Visible = false;
                postsPanel.Visible = true;
 
        }

        private async void btnAuthorize_Click(object sender, EventArgs e)
        {
            lblAuthError.Text = "------";
            try
            {
                await Client.Authorize(tbAuthEmail.Text, tbAuthPassword.Text);
            }
            catch (DataException ex) { 
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException aex)
            {
                lblAuthError.Text = aex.Message;
            }
            if(Client.isConnect)
            {
                foreach (var panel in controlsPanel) panel.Visible = false;
                foreach (var route in controlsMenuRoute) route.Visible = false;
                profilePanel.Visible = true;
                accountMenuRoute.Visible = true;
            }
        }

        private async void btnRegistrate_Click(object sender, EventArgs e)
        {
            lblAuthError.Text = "------";
            try
            {
                await Client.Registrate(tbRegEmail.Text, tbRegPassword.Text);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException aex)
            {
                lblRegError.Text = aex.Message;
            }
        }

        private void authMenuRoute_Click(object sender, EventArgs e)
        {
            foreach (var panel in controlsPanel) panel.Visible = false;
            authPanel.Visible = true;
        }

        private void regMenuRoute_Click(object sender, EventArgs e)
        {
            foreach (var panel in controlsPanel) panel.Visible = false;
            regPanel.Visible = true;
        }

        private void profileMenuRoute_Click(object sender, EventArgs e)
        {
            foreach (var panel in controlsPanel) panel.Visible = false;
            profilePanel.Visible = true;
        }

        private async void exitMenuRoute_Click(object sender, EventArgs e)
        {
            await Client.Exit();
            foreach (var panel in controlsPanel) panel.Visible = false;
            foreach (var route in controlsMenuRoute) route.Visible = false;

            authPanel.Visible = true;
            authMenuRoute.Visible = true;
            regMenuRoute.Visible = true;
        }

        private void profilePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (!Client.isConnect) return;
            tbProfileId.Text = Client.Session.user.id;
            tbProfileEmail.Text = Client.Session.user.email;
            tbProfileCreated.Text = Client.Session.user.created;
            lblProfileHost.Text = Client.HOST;
        }

        private void sentPostMenuRoute_Click(object sender, EventArgs e)
        {
            foreach (var panel in controlsPanel) panel.Visible = false;
            sendPanel.Visible = true;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                await Client.SendPost(tbSendTitle.Text, tbSendBody.Text);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message);
            }

            postsPanel.Refresh();
        }

        private async void postsPanel_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                PostPool = await Client.PullPosts();
            }
            catch(ArgumentException aex)
            {
                MessageBox.Show($"Fetch Posts Error: {aex}");
                PostPool = new List<Post>() { };
            }
            rtbPosts.Clear();
            foreach (var post in PostPool) rtbPosts.AppendText(post.ToString());
        }

        private void btnPersistUser_Click(object sender, EventArgs e)
        {
            Client.Session.user.setEmail(tbProfileEmail.Text);
        }
    }
}