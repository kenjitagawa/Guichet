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
        public const string APP_INFO = "(Matériel)";

        #region Constantes
        //--- CHAMPS: constantes ----------------------------------------------------------
        private const string NOM_FICHIER_CLIENTS = "Fichiers\\Clients.txt";
        public const string NOM_FICHIER_TRANSACTIONS = "Fichiers\\Transactions.txt";
        private const string NO_ADMIN = "000";
        public const string ERR_NUMERO_CLIENT = "Numéro de client non valide";
        private const string ERR_MOT_DE_PASSE = "Mot de passe incorrect";
        #endregion

        #region Champs et Propriétés : À RÉACTIVER lorsque vos classes Client et Transaction seront complétées
        //private List<Client> m_colClients;
        //public List<Client> ColClients
        //{
        //    get { return m_colClients; }
        //}

        //private List<Transaction> m_colTransactions;
        //public List<Transaction> ColTransactions
        //{
        //    get { return m_colTransactions; }
        //}

        //private Client m_objClientCourant;
        //public Client ClientCourant
        //{
        //    get
        //    {
        //        return m_objClientCourant;
        //    }
        //    set
        //    {
        //        m_objClientCourant = value;
        //    }
        //}
        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;

            // À COMPLÉTER...

            // Initialiser vos 2 collections ainsi que le ClientCourant...

            // Le programme doit charger les deux collections en débutant : NE PAS MODIFIER
            ChargerCollectionClients();
            ChargerCollectionTransactions();
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
            // À COMPLÉTER...
        }
        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Lits les données dans le fichier des transactions et les stocke dans la collection de transactions.
        /// Les données sont séparées par une virgule
        /// </summary>
        /// ---------------------------------------------------------------------------------------------------
        private void ChargerCollectionTransactions()
        {
            // À COMPLÉTER...
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
            // À COMPLÉTER...
        }
        //---------------------------------------------------------------------------------
        private void mnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------------------
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // À COMPLÉTER...
        }
        #endregion

        #region Menu Administrateur
        //---------------------------------------------------------------------------------
        private void mnuAdminListeClients_Click(object sender, EventArgs e)
        {
            // À COMPLÉTER...
        }
        //---------------------------------------------------------------------------------
        private void mnuAdminListeTransactions_Click(object sender, EventArgs e)
        {
            // À COMPLÉTER...
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
            // À COMPLÉTER...
        }

        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifie l'interface selon qu'un client se connecte ou se déconnecte. 
        /// </summary>
        /// <param name="pConnexionEstPermise">un client se connecte ou non</param>
        /// ---------------------------------------------------------------------------------------------
        private void PermettreUneConnexion(bool pConnexionEstPermise)
        {
            // À COMPLÉTER...

        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Active ou désactive les menus et contrôles selon s'il s'agit de l'administrateur ou non.
        /// </summary>
        /// -----------------------------------------------------------------------------------------
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
        }

        /// -------------------------------------------------------------------------------
        /// <summary>
        /// Recherche le client dont le numéro est spécifié.
        /// Si ce numéro n'est pas dans la collection de clients, alors retourne null.
        /// </summary>
        /// <param name="pNumClient">numéro du client à rechercher</param>
        /// <returns>le client ou null si pas trouvé</returns>
        /// --------------------------------------------------------------------------------
        //private Client RechercherClient(string pNumClient)
        //{
        //}
        #endregion

        #region Bouton Connexion/Déconnexion 
        //---------------------------------------------------------------------------------
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // À COMPLÉTER...
        }
        #endregion

        #region Bouton Retirer et Événement Combo Montant à retirer
        //---------------------------------------------------------------------------------
        //Retire le montant choisi
        private void btnRetirer_Click(object sender, EventArgs e)
        {
            // À COMPLÉTER...
        }

        //---------------------------------------------------------------------------------
        //Choix du montant à retirer
        private void cboMontant_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
        }

        #endregion
    }
}