using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGuichet
{
    public class Transaction
    {
        #region Champs et Propriétés
        DateTime m_date;
        /// <summary>
        /// Get date of transaction
        /// </summary>
        public DateTime Date { get { return m_date; } }


        int m_montant;
        /// <summary>
        /// Get montant pour la transaction
        /// </summary>
        public int Montant { get { return m_montant; } }


        string m_numClient;
        /// <summary>
        /// Get numero du client qui fait passer la transaction
        /// </summary>
        public string NumClient { get { return m_numClient; } }


        SorteTransactions m_sorteTransaction;
        /// <summary>
        /// Get du sort de transaction
        /// </summary>
        public SorteTransactions SorteTransaction { get { return m_sorteTransaction; } }

        #endregion


        #region Méthodes
        /// <summary>
        /// Conversion des données en string pour sauvegarde
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            
            return $"{(int)m_sorteTransaction},{m_numClient},{m_date.ToString("yyyy-MM-dd HH:mm:ss")},{m_montant}";
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur à plusieurs paramétrés
        /// </summary>
        /// <param name="pSorte">Sorte de compte</param>
        /// <param name="pNumClient">Numéro du client</param>
        /// <param name="pDate">Date de la transaction</param>
        /// <param name="pMontant">Montant de transfer</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Transaction(SorteTransactions pSorte, string pNumClient, DateTime pDate, int pMontant)
        {

            if ((pMontant != 0 && pSorte != SorteTransactions.Retrait) || pMontant < 0)
                throw new ArgumentException("Montant non valide!");

            m_date = pDate;
            m_montant = pMontant;
            m_numClient = pNumClient;
            m_sorteTransaction = pSorte;

        }


        public Transaction(string pChaineLue)
        {
            string[] chaineLue = pChaineLue.Split(',');

            if ((int.Parse(chaineLue[3]) != 0 && (SorteTransactions)int.Parse(chaineLue[0]) != SorteTransactions.Retrait) || int.Parse(chaineLue[3]) < 0)
                throw new ArgumentOutOfRangeException("Montant non valide!");


            m_date = DateTime.Parse(chaineLue[2]);
            m_montant = int.Parse(chaineLue[3]);
            m_numClient = chaineLue[1];
            m_sorteTransaction = (SorteTransactions)int.Parse(chaineLue[0]);

        }

        #endregion





    }
}
