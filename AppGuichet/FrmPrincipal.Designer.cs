namespace AppGuichet
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpIdentification = new System.Windows.Forms.GroupBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.txtNumClient = new System.Windows.Forms.TextBox();
            this.lblNumClient = new System.Windows.Forms.Label();
            this.grpInfosClient = new System.Windows.Forms.GroupBox();
            this.txtSorteCompte = new System.Windows.Forms.TextBox();
            this.lblSorteCompte = new System.Windows.Forms.Label();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.cboMontant = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSolde = new System.Windows.Forms.TextBox();
            this.lblSolde = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFichierQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministrateur = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminListeClients = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminListeTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.errIdentification = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpIdentification.SuspendLayout();
            this.grpInfosClient.SuspendLayout();
            this.mnuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errIdentification)).BeginInit();
            this.SuspendLayout();
            // 
            // grpIdentification
            // 
            this.grpIdentification.Controls.Add(this.txtMotDePasse);
            this.grpIdentification.Controls.Add(this.btnConnexion);
            this.grpIdentification.Controls.Add(this.lblMotDePasse);
            this.grpIdentification.Controls.Add(this.txtNumClient);
            this.grpIdentification.Controls.Add(this.lblNumClient);
            this.grpIdentification.Enabled = false;
            this.grpIdentification.Location = new System.Drawing.Point(12, 34);
            this.grpIdentification.Name = "grpIdentification";
            this.grpIdentification.Size = new System.Drawing.Size(345, 137);
            this.grpIdentification.TabIndex = 0;
            this.grpIdentification.TabStop = false;
            this.grpIdentification.Text = "Identification";
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Enabled = false;
            this.txtMotDePasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotDePasse.Location = new System.Drawing.Point(114, 60);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(219, 22);
            this.txtMotDePasse.TabIndex = 3;
            this.txtMotDePasse.UseSystemPasswordChar = true;
            // 
            // btnConnexion
            // 
            this.btnConnexion.Enabled = false;
            this.btnConnexion.Location = new System.Drawing.Point(17, 93);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(316, 23);
            this.btnConnexion.TabIndex = 4;
            this.btnConnexion.Text = "Se connecter";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Enabled = false;
            this.lblMotDePasse.Location = new System.Drawing.Point(14, 60);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(77, 13);
            this.lblMotDePasse.TabIndex = 2;
            this.lblMotDePasse.Text = "Mot de passe :";
            // 
            // txtNumClient
            // 
            this.txtNumClient.Enabled = false;
            this.txtNumClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumClient.Location = new System.Drawing.Point(114, 29);
            this.txtNumClient.Name = "txtNumClient";
            this.txtNumClient.Size = new System.Drawing.Size(219, 22);
            this.txtNumClient.TabIndex = 1;
            // 
            // lblNumClient
            // 
            this.lblNumClient.AutoSize = true;
            this.lblNumClient.Enabled = false;
            this.lblNumClient.Location = new System.Drawing.Point(14, 34);
            this.lblNumClient.Name = "lblNumClient";
            this.lblNumClient.Size = new System.Drawing.Size(93, 13);
            this.lblNumClient.TabIndex = 0;
            this.lblNumClient.Text = "Numéro de client :";
            // 
            // grpInfosClient
            // 
            this.grpInfosClient.Controls.Add(this.txtSorteCompte);
            this.grpInfosClient.Controls.Add(this.lblSorteCompte);
            this.grpInfosClient.Controls.Add(this.btnRetirer);
            this.grpInfosClient.Controls.Add(this.cboMontant);
            this.grpInfosClient.Controls.Add(this.label1);
            this.grpInfosClient.Controls.Add(this.txtSolde);
            this.grpInfosClient.Controls.Add(this.lblSolde);
            this.grpInfosClient.Controls.Add(this.txtNom);
            this.grpInfosClient.Controls.Add(this.lblNom);
            this.grpInfosClient.Enabled = false;
            this.grpInfosClient.Location = new System.Drawing.Point(12, 177);
            this.grpInfosClient.Name = "grpInfosClient";
            this.grpInfosClient.Size = new System.Drawing.Size(345, 94);
            this.grpInfosClient.TabIndex = 1;
            this.grpInfosClient.TabStop = false;
            this.grpInfosClient.Text = "Informations/Opérations";
            // 
            // txtSorteCompte
            // 
            this.txtSorteCompte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSorteCompte.Location = new System.Drawing.Point(240, 22);
            this.txtSorteCompte.Name = "txtSorteCompte";
            this.txtSorteCompte.ReadOnly = true;
            this.txtSorteCompte.Size = new System.Drawing.Size(93, 20);
            this.txtSorteCompte.TabIndex = 3;
            // 
            // lblSorteCompte
            // 
            this.lblSorteCompte.AutoSize = true;
            this.lblSorteCompte.Location = new System.Drawing.Point(194, 27);
            this.lblSorteCompte.Name = "lblSorteCompte";
            this.lblSorteCompte.Size = new System.Drawing.Size(49, 13);
            this.lblSorteCompte.TabIndex = 2;
            this.lblSorteCompte.Text = "Compte :";
            // 
            // btnRetirer
            // 
            this.btnRetirer.Enabled = false;
            this.btnRetirer.Location = new System.Drawing.Point(94, 55);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(91, 23);
            this.btnRetirer.TabIndex = 6;
            this.btnRetirer.Text = "Retirer";
            this.btnRetirer.UseVisualStyleBackColor = true;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // cboMontant
            // 
            this.cboMontant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMontant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMontant.FormattingEnabled = true;
            this.cboMontant.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100",
            "200",
            "300",
            "500"});
            this.cboMontant.Location = new System.Drawing.Point(17, 57);
            this.cboMontant.Name = "cboMontant";
            this.cboMontant.Size = new System.Drawing.Size(59, 21);
            this.cboMontant.TabIndex = 4;
            this.cboMontant.SelectedIndexChanged += new System.EventHandler(this.cboMontant_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "$";
            // 
            // txtSolde
            // 
            this.txtSolde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolde.Location = new System.Drawing.Point(240, 57);
            this.txtSolde.Name = "txtSolde";
            this.txtSolde.ReadOnly = true;
            this.txtSolde.Size = new System.Drawing.Size(93, 20);
            this.txtSolde.TabIndex = 8;
            this.txtSolde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSolde
            // 
            this.lblSolde.AutoSize = true;
            this.lblSolde.Location = new System.Drawing.Point(194, 60);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(40, 13);
            this.lblSolde.TabIndex = 7;
            this.lblSolde.Text = "Solde :";
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(48, 23);
            this.txtNom.Name = "txtNom";
            this.txtNom.ReadOnly = true;
            this.txtNom.Size = new System.Drawing.Size(137, 20);
            this.txtNom.TabIndex = 1;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(14, 26);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFichier,
            this.mnuAdministrateur});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(369, 24);
            this.mnuPrincipal.TabIndex = 2;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mnuFichier
            // 
            this.mnuFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFichierQuitter});
            this.mnuFichier.Name = "mnuFichier";
            this.mnuFichier.Size = new System.Drawing.Size(54, 20);
            this.mnuFichier.Tag = "H15PCSD";
            this.mnuFichier.Text = "&Fichier";
            // 
            // mnuFichierQuitter
            // 
            this.mnuFichierQuitter.Name = "mnuFichierQuitter";
            this.mnuFichierQuitter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFichierQuitter.Size = new System.Drawing.Size(154, 22);
            this.mnuFichierQuitter.Text = "&Quitter";
            this.mnuFichierQuitter.Click += new System.EventHandler(this.mnuFichierQuitter_Click);
            // 
            // mnuAdministrateur
            // 
            this.mnuAdministrateur.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdminListeClients,
            this.mnuAdminListeTransactions});
            this.mnuAdministrateur.Name = "mnuAdministrateur";
            this.mnuAdministrateur.Size = new System.Drawing.Size(98, 20);
            this.mnuAdministrateur.Text = "&Administrateur";
            // 
            // mnuAdminListeClients
            // 
            this.mnuAdminListeClients.Name = "mnuAdminListeClients";
            this.mnuAdminListeClients.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.mnuAdminListeClients.Size = new System.Drawing.Size(232, 22);
            this.mnuAdminListeClients.Text = "Liste des clients...";
            this.mnuAdminListeClients.Click += new System.EventHandler(this.mnuAdminListeClients_Click);
            // 
            // mnuAdminListeTransactions
            // 
            this.mnuAdminListeTransactions.Name = "mnuAdminListeTransactions";
            this.mnuAdminListeTransactions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuAdminListeTransactions.Size = new System.Drawing.Size(232, 22);
            this.mnuAdminListeTransactions.Text = "Liste des transactions...";
            this.mnuAdminListeTransactions.Click += new System.EventHandler(this.mnuAdminListeTransactions_Click);
            // 
            // errIdentification
            // 
            this.errIdentification.ContainerControl = this;
            // 
            // FrmPrincipal
            // 
            this.AcceptButton = this.btnConnexion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 286);
            this.Controls.Add(this.grpInfosClient);
            this.Controls.Add(this.grpIdentification);
            this.Controls.Add(this.mnuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuPrincipal;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guichet Automatique ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.grpIdentification.ResumeLayout(false);
            this.grpIdentification.PerformLayout();
            this.grpInfosClient.ResumeLayout(false);
            this.grpInfosClient.PerformLayout();
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errIdentification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox grpIdentification;
        public System.Windows.Forms.Label lblNumClient;
        public System.Windows.Forms.Button btnConnexion;
        public System.Windows.Forms.Label lblMotDePasse;
        public System.Windows.Forms.TextBox txtNumClient;
        public System.Windows.Forms.GroupBox grpInfosClient;
        public System.Windows.Forms.TextBox txtSolde;
        public System.Windows.Forms.Label lblSolde;
        public System.Windows.Forms.TextBox txtNom;
        public System.Windows.Forms.Label lblNom;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.ComboBox cboMontant;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.MenuStrip mnuPrincipal;
        public System.Windows.Forms.ToolStripMenuItem mnuFichier;
        public System.Windows.Forms.ToolStripMenuItem mnuFichierQuitter;
        public System.Windows.Forms.TextBox txtSorteCompte;
        public System.Windows.Forms.Label lblSorteCompte;
        public System.Windows.Forms.ToolStripMenuItem mnuAdministrateur;
        public System.Windows.Forms.ToolStripMenuItem mnuAdminListeClients;
        public System.Windows.Forms.ToolStripMenuItem mnuAdminListeTransactions;
        public System.Windows.Forms.TextBox txtMotDePasse;
        public System.Windows.Forms.ErrorProvider errIdentification;
    }
}

