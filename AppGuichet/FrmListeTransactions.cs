using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppGuichet
{
    public partial class FrmListeTransactions : Form
    {

        private List<Transaction> m_colTransactions;


        //----------------------------------------------------------------
        public FrmListeTransactions(List<Transaction> pColTransactions)
        {
            InitializeComponent();

            m_colTransactions = pColTransactions;
            cboOpération.SelectedIndex = 0;
        
        }

        private void AfficherListeTransactions(FiltreOperation pFiltrerVal)
        { 
            // Clear ListView "lsvTransactions"
            lsvTransactions.Items.Clear();
            

            for (int n = m_colTransactions.Count - 1; n >= 0; n--)
            { 
                Transaction transaction = m_colTransactions[n];
                bool found = false;

                switch (pFiltrerVal)
                {

                    // Retourne la liste au complet
                    case FiltreOperation.Toutes:
                        found = true;
                        break;

                    // Check si c'est egual a Connexion ou Deconnexion
                    case FiltreOperation.ConnexionDéconnexion:
                        found = transaction.SorteTransaction == SorteTransactions.Connexion || transaction.SorteTransaction == SorteTransactions.Déconnexion;
                        break;

                    // Check si c'est egual a retrait
                    case FiltreOperation.Retrait:
                        found = transaction.SorteTransaction == SorteTransactions.Retrait;
                        break;

                    default:
                        found = true;
                        break;

                }

                if (found)
                {
                    ListViewItem listViewItem = new ListViewItem(transaction.SorteTransaction.ToString()); // First column
                    listViewItem.SubItems.Add(transaction.NumClient);
                    listViewItem.SubItems.Add(transaction.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    listViewItem.SubItems.Add((transaction.Montant != 0) ? transaction.Montant.ToString("C2") : "--");
                    lsvTransactions.Items.Add(listViewItem);
                }
            }
            lblNbrTransactions.Text = lsvTransactions.Items.Count.ToString();


        }

        //------------------------------------------------------------------------------
        private void cboOpération_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherListeTransactions((FiltreOperation)cboOpération.SelectedIndex); 
        }

        private void lsvTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblNbrTransactions_Click(object sender, EventArgs e)
        {

        }
    }
}