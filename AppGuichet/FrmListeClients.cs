using System.Collections.Generic;
using System.Windows.Forms;

namespace AppGuichet
{
    public partial class FrmListeClients : Form
    {
        private List<Client> m_colClients;
        


        public FrmListeClients(List<Client> pColClients)
        {

            InitializeComponent();

            //Utiliser les clients dans la liste
            m_colClients = pColClients;
            AfficherListeClients();
        }

        public void AfficherListeClients()
        {
            // Clear list of clients (form) to ensure that no values are present before doing anything.
            lsvClients.Items.Clear();

            foreach (Client client in m_colClients)
            {
                ListViewItem lsvClientObj = new ListViewItem(client.NumClient);
                lsvClientObj.SubItems.Add(client.Nom);
                lsvClientObj.SubItems.Add(client.SorteCompte.ToString());
                lsvClientObj.SubItems.Add(client.Solde.ToString("C2"));
                lsvClientObj.SubItems.Add(client.MotDePasse);

                lsvClients.Items.Add(lsvClientObj);
                
            }


        }

        private void lsvClients_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}