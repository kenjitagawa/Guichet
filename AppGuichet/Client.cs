using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGuichet
{
    public class Client
    {
        
        
        #region CONSTANTES

        /// <summary>
        /// Solde client maximum.
        /// </summary>
        public const int MAX_SOLDE = 1000000;

        #endregion



        #region CHAMPS ET PROPRIÉTÉS

        private string m_motDePasse;
        /// <summary>
        /// Mot de passe du client
        /// </summary>
        public string MotDePasse { get { return m_motDePasse; } }


        private string m_nom;
        /// <summary>
        /// Get le nom du client
        /// </summary>
        public string Nom { get { return m_nom; } }


        private string m_numClient;
        /// <summary>
        /// Numero du client
        /// </summary>
        public string NumClient { get { return m_numClient; } }


        private int m_solde;
        /// <summary>
        /// Solde
        /// </summary>
        public int Solde { get { return m_solde; } }


        private SorteComptes m_sorteCompte;
        /// <summary>
        /// Sorte de compte
        /// </summary>
        public SorteComptes SorteCompte { get { return m_sorteCompte; } }
        #endregion






        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur a un parametre
        /// </summary>
        /// <param name="pChaineLue">Ligne d'un fichier</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public Client(string pChaineLue)
        {
            // 1RL,2,Robert Laporte,5000,abc
            // No du client, Sorte de compte, Nom, Solde, Mot de passe

            string[] chaineLue = pChaineLue.Split(',');


            // Verifier si les valeurs dans les fichiers sont correctes.
            if (int.Parse(chaineLue[3]) < 0 || int.Parse(chaineLue[3]) > MAX_SOLDE)
            {
                throw new ArgumentOutOfRangeException();
            }
            m_numClient = chaineLue[0];
            m_sorteCompte = (SorteComptes)int.Parse(chaineLue[1]);
            m_nom = chaineLue[2];
            m_solde = int.Parse(chaineLue[3]);
            m_motDePasse = chaineLue[4];
        }


        // Constructeur a plusieurs parametres
        public Client(string pNumClient, SorteComptes pSorteCompte, string pNom, int pSolde, string pMotDePasse)
        {
            // Verifier si les valeurs dans les fichiers sont correctes.
            if (pSolde < 0 || pSolde > MAX_SOLDE)
            {
                throw new ArgumentOutOfRangeException();
            }
            m_numClient = pNumClient;
            m_sorteCompte = pSorteCompte;
            m_nom = pNom;
            m_solde = pSolde;
            m_motDePasse = pMotDePasse;
        }
        #endregion

        #region MÉTHODES

        /// <summary>
        /// Verifie si le valeur à retirer est valide
        /// </summary>
        /// <param name="pMontant">Montant à verifier</param>
        /// <returns>Bool</returns>
        public bool PeutRetirer(int pMontant)
        {
            bool retirePossible = true;

            if (pMontant <= 0 || pMontant > m_solde)
            {
                retirePossible = false;
            }

            return retirePossible;
        }

        /// <summary>
        /// Retirer un montant de la compte du client.
        /// </summary>
        /// <param name="pMontant">Montant à retirer</param>
        /// <exception cref="ArgumentOutOfRangeException">Chiffre non permise</exception>
        public void Retirer(int pMontant)
        {
            if (PeutRetirer(pMontant))
            {
                m_solde -= pMontant;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }


        /// <summary>
        /// Conversion d'un objet a une string. 
        /// </summary>
        /// <returns>String avec les données du client</returns>
        public override string ToString()
        {
            return $"{m_numClient},{(int)m_sorteCompte},{m_nom},{m_solde},{m_motDePasse}";
        }
        #endregion
    }
}
