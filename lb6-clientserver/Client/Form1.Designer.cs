namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbAuthEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAuthPassword = new System.Windows.Forms.TextBox();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.lblAuthError = new System.Windows.Forms.Label();
            this.authPanel = new System.Windows.Forms.Panel();
            this.profilePanel = new System.Windows.Forms.Panel();
            this.lblProfileHost = new System.Windows.Forms.Label();
            this.sendPanel = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbSendBody = new System.Windows.Forms.TextBox();
            this.Post = new System.Windows.Forms.Label();
            this.tbSendTitle = new System.Windows.Forms.TextBox();
            this.tb = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRefreshPassword = new System.Windows.Forms.Button();
            this.btnPersistUser = new System.Windows.Forms.Button();
            this.tbProfileCreated = new System.Windows.Forms.TextBox();
            this.tbProfileEmail = new System.Windows.Forms.TextBox();
            this.tbProfileId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.regPanel = new System.Windows.Forms.Panel();
            this.lblRegError = new System.Windows.Forms.Label();
            this.rgRegPasswordConfim = new System.Windows.Forms.TextBox();
            this.btnRegistrate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRegPassword = new System.Windows.Forms.TextBox();
            this.tbRegEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.appMainMenu = new System.Windows.Forms.MenuStrip();
            this.authMenuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.regMenuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.accountMenuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.profileMenuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.sentPostMenuRoute = new System.Windows.Forms.ToolStripMenuItem();
            this.postsPanel = new System.Windows.Forms.Panel();
            this.rtbPosts = new System.Windows.Forms.RichTextBox();
            this.authPanel.SuspendLayout();
            this.profilePanel.SuspendLayout();
            this.sendPanel.SuspendLayout();
            this.regPanel.SuspendLayout();
            this.appMainMenu.SuspendLayout();
            this.postsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAuthEmail
            // 
            this.tbAuthEmail.Location = new System.Drawing.Point(75, 15);
            this.tbAuthEmail.Name = "tbAuthEmail";
            this.tbAuthEmail.Size = new System.Drawing.Size(173, 23);
            this.tbAuthEmail.TabIndex = 0;
            this.tbAuthEmail.Text = "pikj.reyderman@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // tbAuthPassword
            // 
            this.tbAuthPassword.Location = new System.Drawing.Point(75, 61);
            this.tbAuthPassword.Name = "tbAuthPassword";
            this.tbAuthPassword.Size = new System.Drawing.Size(173, 23);
            this.tbAuthPassword.TabIndex = 2;
            this.tbAuthPassword.Text = "alternativeWorld";
            this.tbAuthPassword.UseSystemPasswordChar = true;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(8, 108);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 4;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // lblAuthError
            // 
            this.lblAuthError.AutoSize = true;
            this.lblAuthError.Location = new System.Drawing.Point(127, 108);
            this.lblAuthError.Name = "lblAuthError";
            this.lblAuthError.Size = new System.Drawing.Size(47, 15);
            this.lblAuthError.TabIndex = 5;
            this.lblAuthError.Text = "--------";
            // 
            // authPanel
            // 
            this.authPanel.Controls.Add(this.tbAuthPassword);
            this.authPanel.Controls.Add(this.lblAuthError);
            this.authPanel.Controls.Add(this.tbAuthEmail);
            this.authPanel.Controls.Add(this.btnAuthorize);
            this.authPanel.Controls.Add(this.label1);
            this.authPanel.Controls.Add(this.label2);
            this.authPanel.Location = new System.Drawing.Point(21, 27);
            this.authPanel.Name = "authPanel";
            this.authPanel.Size = new System.Drawing.Size(284, 143);
            this.authPanel.TabIndex = 6;
            // 
            // profilePanel
            // 
            this.profilePanel.Controls.Add(this.lblProfileHost);
            this.profilePanel.Controls.Add(this.label9);
            this.profilePanel.Controls.Add(this.btnRefreshPassword);
            this.profilePanel.Controls.Add(this.btnPersistUser);
            this.profilePanel.Controls.Add(this.tbProfileCreated);
            this.profilePanel.Controls.Add(this.tbProfileEmail);
            this.profilePanel.Controls.Add(this.tbProfileId);
            this.profilePanel.Controls.Add(this.label8);
            this.profilePanel.Controls.Add(this.label7);
            this.profilePanel.Controls.Add(this.label6);
            this.profilePanel.Location = new System.Drawing.Point(12, 46);
            this.profilePanel.Name = "profilePanel";
            this.profilePanel.Size = new System.Drawing.Size(284, 200);
            this.profilePanel.TabIndex = 8;
            this.profilePanel.VisibleChanged += new System.EventHandler(this.profilePanel_VisibleChanged);
            // 
            // lblProfileHost
            // 
            this.lblProfileHost.AutoSize = true;
            this.lblProfileHost.Location = new System.Drawing.Point(72, 9);
            this.lblProfileHost.Name = "lblProfileHost";
            this.lblProfileHost.Size = new System.Drawing.Size(32, 15);
            this.lblProfileHost.TabIndex = 15;
            this.lblProfileHost.Text = "-----";
            // 
            // sendPanel
            // 
            this.sendPanel.Controls.Add(this.btnSend);
            this.sendPanel.Controls.Add(this.tbSendBody);
            this.sendPanel.Controls.Add(this.Post);
            this.sendPanel.Controls.Add(this.tbSendTitle);
            this.sendPanel.Controls.Add(this.tb);
            this.sendPanel.Location = new System.Drawing.Point(9, 59);
            this.sendPanel.Name = "sendPanel";
            this.sendPanel.Size = new System.Drawing.Size(284, 117);
            this.sendPanel.TabIndex = 9;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(99, 86);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbSendBody
            // 
            this.tbSendBody.Location = new System.Drawing.Point(44, 57);
            this.tbSendBody.Name = "tbSendBody";
            this.tbSendBody.Size = new System.Drawing.Size(214, 23);
            this.tbSendBody.TabIndex = 3;
            // 
            // Post
            // 
            this.Post.AutoSize = true;
            this.Post.Location = new System.Drawing.Point(8, 60);
            this.Post.Name = "Post";
            this.Post.Size = new System.Drawing.Size(30, 15);
            this.Post.TabIndex = 2;
            this.Post.Text = "Post";
            // 
            // tbSendTitle
            // 
            this.tbSendTitle.Location = new System.Drawing.Point(44, 14);
            this.tbSendTitle.Name = "tbSendTitle";
            this.tbSendTitle.Size = new System.Drawing.Size(214, 23);
            this.tbSendTitle.TabIndex = 1;
            // 
            // tb
            // 
            this.tb.AutoSize = true;
            this.tb.Location = new System.Drawing.Point(8, 17);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(30, 15);
            this.tb.TabIndex = 0;
            this.tb.Text = "Title";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "HOST";
            // 
            // btnRefreshPassword
            // 
            this.btnRefreshPassword.Location = new System.Drawing.Point(124, 136);
            this.btnRefreshPassword.Name = "btnRefreshPassword";
            this.btnRefreshPassword.Size = new System.Drawing.Size(95, 53);
            this.btnRefreshPassword.TabIndex = 13;
            this.btnRefreshPassword.Text = "Refresh password";
            this.btnRefreshPassword.UseVisualStyleBackColor = true;
            // 
            // btnPersistUser
            // 
            this.btnPersistUser.Location = new System.Drawing.Point(8, 141);
            this.btnPersistUser.Name = "btnPersistUser";
            this.btnPersistUser.Size = new System.Drawing.Size(92, 48);
            this.btnPersistUser.TabIndex = 12;
            this.btnPersistUser.Text = "Persist";
            this.btnPersistUser.UseVisualStyleBackColor = true;
            this.btnPersistUser.Click += new System.EventHandler(this.btnPersistUser_Click);
            // 
            // tbProfileCreated
            // 
            this.tbProfileCreated.Location = new System.Drawing.Point(72, 105);
            this.tbProfileCreated.Name = "tbProfileCreated";
            this.tbProfileCreated.ReadOnly = true;
            this.tbProfileCreated.Size = new System.Drawing.Size(147, 23);
            this.tbProfileCreated.TabIndex = 11;
            // 
            // tbProfileEmail
            // 
            this.tbProfileEmail.Location = new System.Drawing.Point(72, 76);
            this.tbProfileEmail.Name = "tbProfileEmail";
            this.tbProfileEmail.Size = new System.Drawing.Size(147, 23);
            this.tbProfileEmail.TabIndex = 10;
            // 
            // tbProfileId
            // 
            this.tbProfileId.Location = new System.Drawing.Point(72, 43);
            this.tbProfileId.Name = "tbProfileId";
            this.tbProfileId.ReadOnly = true;
            this.tbProfileId.Size = new System.Drawing.Size(147, 23);
            this.tbProfileId.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "created";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Email";
            // 
            // regPanel
            // 
            this.regPanel.Controls.Add(this.lblRegError);
            this.regPanel.Controls.Add(this.rgRegPasswordConfim);
            this.regPanel.Controls.Add(this.btnRegistrate);
            this.regPanel.Controls.Add(this.label5);
            this.regPanel.Controls.Add(this.tbRegPassword);
            this.regPanel.Controls.Add(this.tbRegEmail);
            this.regPanel.Controls.Add(this.label3);
            this.regPanel.Controls.Add(this.label4);
            this.regPanel.Location = new System.Drawing.Point(18, 36);
            this.regPanel.Name = "regPanel";
            this.regPanel.Size = new System.Drawing.Size(284, 161);
            this.regPanel.TabIndex = 6;
            // 
            // lblRegError
            // 
            this.lblRegError.AutoSize = true;
            this.lblRegError.Location = new System.Drawing.Point(114, 128);
            this.lblRegError.Name = "lblRegError";
            this.lblRegError.Size = new System.Drawing.Size(47, 15);
            this.lblRegError.TabIndex = 7;
            this.lblRegError.Text = "--------";
            // 
            // rgRegPasswordConfim
            // 
            this.rgRegPasswordConfim.Location = new System.Drawing.Point(90, 89);
            this.rgRegPasswordConfim.Name = "rgRegPasswordConfim";
            this.rgRegPasswordConfim.Size = new System.Drawing.Size(173, 23);
            this.rgRegPasswordConfim.TabIndex = 8;
            this.rgRegPasswordConfim.Text = "alternativeWorld";
            this.rgRegPasswordConfim.UseSystemPasswordChar = true;
            // 
            // btnRegistrate
            // 
            this.btnRegistrate.Location = new System.Drawing.Point(13, 126);
            this.btnRegistrate.Name = "btnRegistrate";
            this.btnRegistrate.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrate.TabIndex = 6;
            this.btnRegistrate.Text = "Registrate";
            this.btnRegistrate.UseVisualStyleBackColor = true;
            this.btnRegistrate.Click += new System.EventHandler(this.btnRegistrate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Configm pass";
            // 
            // tbRegPassword
            // 
            this.tbRegPassword.Location = new System.Drawing.Point(90, 48);
            this.tbRegPassword.Name = "tbRegPassword";
            this.tbRegPassword.Size = new System.Drawing.Size(173, 23);
            this.tbRegPassword.TabIndex = 6;
            this.tbRegPassword.Text = "alternativeWorld";
            this.tbRegPassword.UseSystemPasswordChar = true;
            // 
            // tbRegEmail
            // 
            this.tbRegEmail.Location = new System.Drawing.Point(90, 10);
            this.tbRegEmail.Name = "tbRegEmail";
            this.tbRegEmail.Size = new System.Drawing.Size(173, 23);
            this.tbRegEmail.TabIndex = 4;
            this.tbRegEmail.Text = "pikj.reyderman@gmail.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // appMainMenu
            // 
            this.appMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authMenuRoute,
            this.regMenuRoute,
            this.accountMenuRoute});
            this.appMainMenu.Location = new System.Drawing.Point(0, 0);
            this.appMainMenu.Name = "appMainMenu";
            this.appMainMenu.Size = new System.Drawing.Size(583, 24);
            this.appMainMenu.TabIndex = 7;
            this.appMainMenu.Text = "menuStrip1";
            // 
            // authMenuRoute
            // 
            this.authMenuRoute.Name = "authMenuRoute";
            this.authMenuRoute.Size = new System.Drawing.Size(91, 20);
            this.authMenuRoute.Text = "Authorization";
            this.authMenuRoute.Click += new System.EventHandler(this.authMenuRoute_Click);
            // 
            // regMenuRoute
            // 
            this.regMenuRoute.Name = "regMenuRoute";
            this.regMenuRoute.Size = new System.Drawing.Size(82, 20);
            this.regMenuRoute.Text = "Registration";
            this.regMenuRoute.Click += new System.EventHandler(this.regMenuRoute_Click);
            // 
            // accountMenuRoute
            // 
            this.accountMenuRoute.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileMenuRoute,
            this.exitMenuRoute,
            this.sentPostMenuRoute});
            this.accountMenuRoute.Name = "accountMenuRoute";
            this.accountMenuRoute.Size = new System.Drawing.Size(64, 20);
            this.accountMenuRoute.Text = "Account";
            // 
            // profileMenuRoute
            // 
            this.profileMenuRoute.Name = "profileMenuRoute";
            this.profileMenuRoute.Size = new System.Drawing.Size(108, 22);
            this.profileMenuRoute.Text = "Profile";
            this.profileMenuRoute.Click += new System.EventHandler(this.profileMenuRoute_Click);
            // 
            // exitMenuRoute
            // 
            this.exitMenuRoute.Name = "exitMenuRoute";
            this.exitMenuRoute.Size = new System.Drawing.Size(108, 22);
            this.exitMenuRoute.Text = "Exit";
            this.exitMenuRoute.Click += new System.EventHandler(this.exitMenuRoute_Click);
            // 
            // sentPostMenuRoute
            // 
            this.sentPostMenuRoute.Name = "sentPostMenuRoute";
            this.sentPostMenuRoute.Size = new System.Drawing.Size(108, 22);
            this.sentPostMenuRoute.Text = "Send";
            this.sentPostMenuRoute.Click += new System.EventHandler(this.sentPostMenuRoute_Click);
            // 
            // postsPanel
            // 
            this.postsPanel.Controls.Add(this.rtbPosts);
            this.postsPanel.Location = new System.Drawing.Point(311, 27);
            this.postsPanel.Name = "postsPanel";
            this.postsPanel.Size = new System.Drawing.Size(269, 354);
            this.postsPanel.TabIndex = 10;
            this.postsPanel.VisibleChanged += new System.EventHandler(this.postsPanel_VisibleChanged);
            // 
            // rtbPosts
            // 
            this.rtbPosts.Location = new System.Drawing.Point(12, 9);
            this.rtbPosts.Name = "rtbPosts";
            this.rtbPosts.Size = new System.Drawing.Size(237, 328);
            this.rtbPosts.TabIndex = 0;
            this.rtbPosts.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 411);
            this.Controls.Add(this.postsPanel);
            this.Controls.Add(this.sendPanel);
            this.Controls.Add(this.profilePanel);
            this.Controls.Add(this.regPanel);
            this.Controls.Add(this.authPanel);
            this.Controls.Add(this.appMainMenu);
            this.MainMenuStrip = this.appMainMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.authPanel.ResumeLayout(false);
            this.authPanel.PerformLayout();
            this.profilePanel.ResumeLayout(false);
            this.profilePanel.PerformLayout();
            this.sendPanel.ResumeLayout(false);
            this.sendPanel.PerformLayout();
            this.regPanel.ResumeLayout(false);
            this.regPanel.PerformLayout();
            this.appMainMenu.ResumeLayout(false);
            this.appMainMenu.PerformLayout();
            this.postsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbAuthEmail;
        private Label label1;
        private Label label2;
        private TextBox tbAuthPassword;
        private Button btnAuthorize;
        private Label lblAuthError;
        private Panel authPanel;
        private Panel regPanel;
        private Label lblRegError;
        private TextBox rgRegPasswordConfim;
        private Button btnRegistrate;
        private Label label5;
        private TextBox tbRegPassword;
        private TextBox tbRegEmail;
        private Label label3;
        private Label label4;
        private MenuStrip appMainMenu;
        private ToolStripMenuItem authMenuRoute;
        private ToolStripMenuItem regMenuRoute;
        private ToolStripMenuItem accountMenuRoute;
        private ToolStripMenuItem profileMenuRoute;
        private ToolStripMenuItem exitMenuRoute;
        private Panel profilePanel;
        private Label label6;
        private Label label7;
        private Button btnRefreshPassword;
        private Button btnPersistUser;
        private TextBox tbProfileCreated;
        private TextBox tbProfileEmail;
        private TextBox tbProfileId;
        private Label label8;
        private Label lblProfileHost;
        private Label label9;
        private ToolStripMenuItem sentPostMenuRoute;
        private Panel sendPanel;
        private Button btnSend;
        private TextBox tbSendBody;
        private Label Post;
        private TextBox tbSendTitle;
        private Label tb;
        private Panel postsPanel;
        private RichTextBox rtbPosts;
    }
}