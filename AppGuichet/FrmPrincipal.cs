using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace AppGuichet
{
    /// =====================================================================================================================
    /// <summary>
    /// Représente l’utilisation d’un guichet automatique. Un client peut se connecter avec son numéro et son mot de passe.
    /// Il peut retirer de l’argent si son solde le permet. L’administrateur du guichet peut demander la liste des clients
    /// où la liste des transactions effectuées sur le guichet.
    /// </summary>
    /// ======================================================================================================================
    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "Kenji Tagawa";

        #region Constantes
        //--- CHAMPS: constantes ----------------------------------------------------------
        private const string NOM_FICHIER_CLIENTS = "Fichiers\\Clients.txt";
        public const string NOM_FICHIER_TRANSACTIONS = "Fichiers\\Transactions.txt";
        private const string NO_ADMIN = "000";
        public const string ERR_NUMERO_CLIENT = "Numéro de client non valide";
        private const string ERR_MOT_DE_PASSE = "Mot de passe incorrect";
        #endregion

        #region Champs et Propriétés : À RÉACTIVER lorsque vos classes Client et Transaction seront complétées
        private List<Client> m_colClients;
        public List<Client> ColClients
        {
            get { return m_colClients; }
        }

        private List<Transaction> m_colTransactions;
        public List<Transaction> ColTransactions
        {
            get { return m_colTransactions; }
        }

        private Client m_objClientCourant;
        public Client ClientCourant
        {
            get
            {
                return m_objClientCourant;
            }
            set
            {
                m_objClientCourant = value;
            }
        }
        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;

            // À COMPLÉTER...
            m_colClients = new List<Client>();
            m_colTransactions = new List<Transaction>();
            // Initialiser vos 2 collections ainsi que le ClientCourant...


            // Le programme doit charger les deux collections en débutant : NE PAS MODIFIER
            ChargerCollectionClients();
            ChargerCollectionTransactions();

            MettreAJourSelonContexte();
        }

        #region Méthodes pour Charger les 2 collections
        //------------------------------------------------------------------------------------------
        /// <summary>
        /// Lit les données dans le fichier de clients et les stocke dans la collection de clients.
        /// Les données lues sont séparées par une virgule.
        /// </summary>
        /// ----------------------------------------------------------------------------------------
        private void ChargerCollectionClients()
        {
            /// Chargement de la collection des clients
            if (File.Exists(NOM_FICHIER_CLIENTS))
            { 
                StreamReader objFichier = new StreamReader(NOM_FICHIER_CLIENTS);

                while (!objFichier.EndOfStream)
                {
                    string ligne = objFichier.ReadLine();
                    Client client = new Client(ligne);
                    m_colClients.Add(client);
                }
                objFichier.Close();
            }
        }
        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Lits les données dans le fichier des transactions et les stocke dans la collection de transactions.
        /// Les données sont séparées par une virgule
        /// </summary>
        /// ---------------------------------------------------------------------------------------------------
        private void ChargerCollectionTransactions()
        {
            if (File.Exists(NOM_FICHIER_TRANSACTIONS))
            { 
                StreamReader objFichier = new StreamReader (NOM_FICHIER_TRANSACTIONS);

                while (!objFichier.EndOfStream)
                {
                    string ligne = objFichier.ReadLine();
                    Transaction transaction = new Transaction(ligne);
                    m_colTransactions.Add(transaction);
                }
            
            }
        }

        #endregion

        #region Enregsitrer la collection de clients, Menu Quitter et Fermeture
        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Écrit dans le fichier de clients, les clients contenus dans la collection de clients.
        /// Puisque le solde du client a pu changer après le retrait.
        /// </summary>
        /// -------------------------------------------------------------------------------------
        private void EnregistrerCollectionClients()
        {
            // Enregistre collection de clients.

            if (!File.Exists(NOM_FICHIER_CLIENTS))
            {
                // Créer le fichier manquant.
                File.Create(NOM_FICHIER_CLIENTS);
            }

            StreamWriter objFichier = new StreamWriter(NOM_FICHIER_CLIENTS);

            foreach (Client client in m_colClients)
            { 
                objFichier.WriteLine(client.ToString());
            }

            objFichier.Close ();

        }
        //---------------------------------------------------------------------------------
        private void mnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------------------
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Sauvegarde des transactions et de la liste des clients. 
            if (m_objClientCourant != null)
            {
                EnregistrerLaTransaction(SorteTransactions.Déconnexion, 0);
            }

            EnregistrerCollectionClients();

        }
        #endregion

        #region Menu Administrateur
        //---------------------------------------------------------------------------------
        private void mnuAdminListeClients_Click(object sender, EventArgs e)
        {
            // Liste de clients form popup
            FrmListeClients frmListeClients = new FrmListeClients(m_colClients);
            frmListeClients.ShowDialog();
        }
        //---------------------------------------------------------------------------------
        private void mnuAdminListeTransactions_Click(object sender, EventArgs e)
        {
            // Liste des transactions form popup
            FrmListeTransactions frmListeTransactions = new FrmListeTransactions(m_colTransactions);
            frmListeTransactions.ShowDialog();
        }


        #endregion

        #region  Méthodes: Enregistrer la transaction, PermettreUneConnexion, MettreAjourSelonContexte, RechercherClient
        //-----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Écrit dans le fichier de transactions, la nouvelle transaction qui vient de se produire, maintenant.
        /// Ajoute aussi cette nouvelle transaction dans la collection de transactions.
        /// </summary>
        /// <param name="pSorteTransaction">sorte de transaction</param>
        /// <param name="pMontantRetrait">montant du retrait, 0 si ce n'est pas un retrait</param>
        /// --------------------------------------------------------------------------------------------------------
        private void EnregistrerLaTransaction(SorteTransactions pSorteTransaction, int pMontantRetrait)
        {
            // Ajouter a un fichier
            StreamWriter objFichier = new StreamWriter(NOM_FICHIER_TRANSACTIONS, true); // True => append: true

            // Checking if the values are valid
            Transaction transaction = new Transaction(pSorteTransaction, m_objClientCourant.NumClient, DateTime.Now, pMontantRetrait);
            objFichier.WriteLine(transaction.ToString());

            objFichier.Close();
            m_colTransactions.Add(transaction); // Adding transaction to the list.
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifie l'interface selon qu'un client se connecte ou se déconnecte. 
        /// </summary>
        /// <param name="pConnexionEstPermise">un client se connecte ou non</param>
        /// ---------------------------------------------------------------------------------------------
        private void PermettreUneConnexion(bool pConnexionEstPermise)
        {
            // Verification de connections
            txtNumClient.ReadOnly = !pConnexionEstPermise;
            txtMotDePasse.Enabled = pConnexionEstPermise;
            lblMotDePasse.Enabled = pConnexionEstPermise;


            btnConnexion.Text = (pConnexionEstPermise ? "Se connecter" : "Se déconnecter");

            if (pConnexionEstPermise)
            {
                txtMotDePasse.Clear();
                txtNumClient.Clear();
                txtSolde.Clear();
                txtSorteCompte.Clear();
                txtNom.Clear();

                txtNumClient.Focus();
            }


        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Active ou désactive les menus et contrôles selon s'il s'agit de l'administrateur ou non.
        /// </summary>
        /// -----------------------------------------------------------------------------------------
        private void MettreAJourSelonContexte()
        {
            // Changer les fields

            // Check si le client est ADMIN et le client courant n'est pas NULL
            bool permission = m_objClientCourant != null && m_objClientCourant.NumClient == NO_ADMIN;

            #region Activer les permissions ADMIN
            mnuAdministrateur.Enabled = permission;
            mnuAdminListeClients.Enabled = permission;
            mnuAdminListeTransactions.Enabled = permission;
            #endregion

            // If the user isnt logged in already AND if the current user is not NULL
            grpInfosClient.Enabled = m_objClientCourant == null;//&& !permission;
            grpIdentification.Enabled = m_objClientCourant == null; //&& !permission;

        }

        /// -------------------------------------------------------------------------------
        /// <summary>
        /// Recherche le client dont le numéro est spécifié.
        /// Si ce numéro n'est pas dans la collection de clients, alors retourne null.
        /// </summary>
        /// <param name="pNumClient">numéro du client à rechercher</param>
        /// <returns>le client ou null si pas trouvé</returns>
        /// --------------------------------------------------------------------------------
        private Client RechercherClient(string pNumClient)
        {
            Client clientInfo = null;
            foreach (Client client in m_colClients)
            { 
                if (client.NumClient == pNumClient)
                    clientInfo = client;
            }
            return clientInfo;
        }
        #endregion

        #region Bouton Connexion/Déconnexion 
        //---------------------------------------------------------------------------------
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Connecter utilisateur

            // Messages d'erreur
            errIdentification.SetError(txtMotDePasse, "");
            errIdentification.SetError(txtNumClient, "");

            // Vérifier si les champs du Form ne sont pas vides.
            if (m_objClientCourant == null)
            {
                m_objClientCourant = RechercherClient(txtNumClient.Text);
                if (m_objClientCourant == null)
                {
                    errIdentification.SetError(txtNumClient, ERR_NUMERO_CLIENT);
                    txtNumClient.Clear();
                    txtNumClient.Focus();
                }
                else
                {
                    if (m_objClientCourant.MotDePasse == txtMotDePasse.Text)
                    {
                        errIdentification.SetError(txtMotDePasse, "");
                        PermettreUneConnexion(false);

                        txtNom.Text = m_objClientCourant.Nom;
                        txtSorteCompte.Text = m_objClientCourant.SorteCompte.ToString();
                        txtSolde.Text = m_objClientCourant.Solde.ToString();

                        cboMontant.SelectedIndex = -1;
                        EnregistrerLaTransaction(SorteTransactions.Connexion, 0);
                    }
                    else
                    {
                        errIdentification.SetError(txtMotDePasse, ERR_MOT_DE_PASSE);

                        txtMotDePasse.Clear();
                        txtMotDePasse.Focus();

                        m_objClientCourant = null;
                    }
                }

            }
            else 
            {
                m_objClientCourant = null;
                PermettreUneConnexion(true);
                EnregistrerLaTransaction(SorteTransactions.Déconnexion, 0);
            }
            MettreAJourSelonContexte();
        }
            
        #endregion

        #region Bouton Retirer et Événement Combo Montant à retirer
        //---------------------------------------------------------------------------------
        //Retire le montant choisi
        private void btnRetirer_Click(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            int montant = int.Parse(cboMontant.Text);
            if (montant == 0)
                return;

            if (m_objClientCourant.PeutRetirer(montant))
                m_objClientCourant.Retirer(montant);

            txtSolde.Text = m_objClientCourant.Solde.ToString();
            cboMontant.SelectedIndex = -1;

            EnregistrerLaTransaction(SorteTransactions.Retrait, montant);

        }

        //---------------------------------------------------------------------------------
        //Choix du montant à retirer
        private void cboMontant_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            if (cboMontant.SelectedIndex != -1)
            {
                btnRetirer.Enabled = m_objClientCourant.PeutRetirer(int.Parse(cboMontant.Text));
            }

            btnRetirer.Enabled = false;

        }

        #endregion

        private void txtNumClient_TextChanged(object sender, EventArgs e)
        {

        }
    }
}