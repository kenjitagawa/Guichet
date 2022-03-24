//Décommenter les lignes suivantes pour activer les tests
//Partie à faire au premier labo
#define TestClasseClient
#define TestClasseTransaction

//Partie à faire au deuxième labo
#define TestFormulairePrincipalDebut
#define TestLesFormulairesListe

//Partie finale
#define TestFormulairePrincipaleSuite

//=======================================================================================
using AppGuichet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CorrecteurGuichet
{
    /// <summary>
    ///Classe de test pour AppGuichet, destinée à contenir tous
    ///les tests unitaires des classes et formulaires
    ///</summary>
    [TestClass()]
    public class Correcteur
    {
        public static string m_version = "Correcteur H21.1.0";

        #region Variables et constructeur des tests

        #region propriété du correcteur
        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion

        #region Attributs de tests supplémentaires
        private static int m_totalScore;
        private static int m_maxScore;

        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            m_totalScore = 0;
            m_maxScore = 0;
        }
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            StreamWriter ficScore = new StreamWriter("../../../Score.txt");
            ficScore.Write(FrmPrincipal.APP_INFO + "\n");
            ficScore.Write(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            ficScore.Write("\nRésultat de la correction (" + m_version + ")\nScore : " + m_totalScore + "/" + m_maxScore, Correcteur.m_version, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ficScore.Close();
        }

        #endregion
        #endregion

        #region Tests de la classe Client (15 pts)
#if TestClasseClient
        #region Tests des Constructeurs Client
        /// <summary>
        ///Test pour Constructeur Client
        ///Test aussi les Getter de la classe
        ///</summary>
        [TestMethod()]
        public void A01_ClientConstructeur1Param()
        {
            m_maxScore += 3;
            string chaineLue = "101,0,Jean Lapointe,4360,abc";
            Client target = new Client(chaineLue);
            Assert.AreEqual("101", target.NumClient);
            Assert.AreEqual(SorteComptes.Épargne, target.SorteCompte);
            Assert.AreEqual("Jean Lapointe", target.Nom);
            Assert.AreEqual(4360, target.Solde);
            Assert.AreEqual("abc", target.MotDePasse);

            //TEST H13.1
            //Ajouter ce test en H13 car le premier n'est pas complet
            chaineLue = "102,1,Denis Poirier,1230,xyz";
            target = new Client(chaineLue);
            Assert.AreEqual("102", target.NumClient);
            Assert.AreEqual(SorteComptes.Chèque, target.SorteCompte);
            Assert.AreEqual("Denis Poirier", target.Nom);
            Assert.AreEqual(1230, target.Solde);
            Assert.AreEqual("xyz", target.MotDePasse);

            m_totalScore += 3;
        }
        /// <summary>
        ///Test pour Constructeur Client
        ///</summary>
        [TestMethod()]
        public void A01_ClientConstructeur5Param()
        {
            m_maxScore += 2;
            string numClient = "102";
            SorteComptes sorteCompte = SorteComptes.Chèque;
            string nom = "Luc Langevin";
            int solde = 100;
            string motDePasse = "QWERTY";
            Client target = new Client(numClient, sorteCompte, nom, solde, motDePasse);
            Assert.AreEqual(numClient, target.NumClient);
            Assert.AreEqual(sorteCompte, target.SorteCompte);
            Assert.AreEqual(nom, target.Nom);
            Assert.AreEqual(solde, target.Solde);
            Assert.AreEqual(motDePasse, target.MotDePasse);
            m_totalScore += 2;
        }
        /// <summary>
        /// Modifié le 2012.08.14
        ///Test pour Constructeur Client
        ///</summary>
        [TestMethod()]
        public void A02_ClientConstructeur1ParamSoldeTestLesLimites()
        {
            m_maxScore += 2;
            //Limite supérieure
            int solde = Client.MAX_SOLDE;
            string chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            Client target = new Client(chaineLue);
            Assert.AreEqual(solde, target.Solde);

            //Limite inférieure
            solde = 0; ; 
            chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            target = new Client(chaineLue);
            Assert.AreEqual(solde, target.Solde);

            
            //Limite supérieure +1
            solde = Client.MAX_SOLDE + 1;
            chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            Assert.IsTrue(InstancierClient1ParAvecArgumentOutOfRange(chaineLue));

            //Limite inférieure -1
            solde = -1; ; 
            chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            Assert.IsTrue(InstancierClient1ParAvecArgumentOutOfRange(chaineLue));

            m_totalScore += 2;
        }

        private bool InstancierClient1ParAvecArgumentOutOfRange(String pChaineDeParametres)
        {
            try
            {
                Client objClient = new Client(pChaineDeParametres);
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///Test pour Constructeur Client
        ///</summary>
        [TestMethod()]
        public void A02_ClientConstructeur5ParamSoldeTestLesLimites()
        {
            m_maxScore += 1;
            string numClient = "102";
            SorteComptes sorteCompte = SorteComptes.Chèque;
            string nom = "Luc Langevin";
            string motDePasse = "QWERTY";

            //Limite supérieure
            int solde = Client.MAX_SOLDE;
            Client target = new Client(numClient, sorteCompte, nom, solde, motDePasse);
            Assert.AreEqual(solde, target.Solde);

            //Limite supérieure +1
            solde = Client.MAX_SOLDE + 1;
            Assert.IsTrue(InstancierClient5ParAvecArgumentOutOfRange(numClient, sorteCompte, nom, solde, motDePasse));

            //Limite inférieure
            solde = 0; ;
            target = new Client(numClient, sorteCompte, nom, solde, motDePasse);
            Assert.AreEqual(solde, target.Solde);

            //Limite inférieure -1
            solde = -1; ;
            Assert.IsTrue(InstancierClient5ParAvecArgumentOutOfRange(numClient, sorteCompte, nom, solde, motDePasse));
            m_totalScore += 1;

        }

        private bool InstancierClient5ParAvecArgumentOutOfRange(string pNumClient, SorteComptes pSorteCompte,
                         string pNom, int pSolde, string pMotDePasse)
        {
            try
            {
                Client objClient = new Client(pNumClient, pSorteCompte, pNom, pSolde, pMotDePasse);
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Test méthode PeutRetirer
        /// <summary>
        ///Test pour PeutRetirer
        ///</summary>
        [TestMethod()]
        public void A03_PeutRetirerTest()
        {
            m_maxScore += 2;
            int solde = Client.MAX_SOLDE;
            string chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            Client target = new Client(chaineLue);

            int montant = Client.MAX_SOLDE;
            Assert.IsTrue(target.PeutRetirer(montant-1));
            Assert.IsTrue(target.PeutRetirer(montant));
            Assert.IsFalse(target.PeutRetirer(montant+1));

            solde = Client.MAX_SOLDE / 2;
            chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            target = new Client(chaineLue);
            montant = Client.MAX_SOLDE/2;
            Assert.IsTrue(target.PeutRetirer(montant - 1));
            Assert.IsTrue(target.PeutRetirer(montant));
            Assert.IsFalse(target.PeutRetirer(montant + 1));
            montant = Client.MAX_SOLDE / 4;
            Assert.IsTrue(target.PeutRetirer(montant - 1));
            Assert.IsTrue(target.PeutRetirer(montant));
            Assert.IsTrue(target.PeutRetirer(montant + 1));

            solde = 1;
            chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            target = new Client(chaineLue);
            montant = 1;
            Assert.IsFalse(target.PeutRetirer(montant - 1));
            Assert.IsTrue(target.PeutRetirer(montant));
            Assert.IsFalse(target.PeutRetirer(montant + 1));

            solde = 0;
            chaineLue = "101,0,Jean Lapointe," + solde + ",abc";
            target = new Client(chaineLue);
            montant = 0;

            Assert.IsFalse(target.PeutRetirer(montant));
            Assert.IsFalse(target.PeutRetirer(montant + 1));
            m_totalScore += 2;
        }

        #endregion

        #region Test méthode Retirer
        /// <summary>
        ///Test pour Retirer valide
        ///</summary>
        [TestMethod()]
        public void A04a_RetirerTestValide()
        {
            m_maxScore += 2;
            int soldeDepart = Client.MAX_SOLDE;
            string chaineLue = "101,0,Jean Lapointe," + soldeDepart + ",abc";

            int montant = Client.MAX_SOLDE;
            //MAX -1
            Client target = new Client(chaineLue);
            target.Retirer(montant - 1);
            Assert.AreEqual(1,target.Solde);
            //MAX
            target = new Client(chaineLue);
            target.Retirer(montant);
            Assert.AreEqual(0, target.Solde);

            //------------------
            soldeDepart = 500;
            chaineLue = "101,0,Jean Lapointe," + soldeDepart + ",abc";
            montant = soldeDepart;

            //Limite supp -1
            target = new Client(chaineLue);
            target.Retirer(montant - 1);
            Assert.AreEqual(1, target.Solde);
            //Limite supp
            target = new Client(chaineLue);
            target.Retirer(montant);
            Assert.AreEqual(0, target.Solde);
            m_totalScore += 2;
        }
        /// <summary>
        ///Test pour Retirer avec des limites invalide
        ///</summary>
        [TestMethod()]
        public void A04b_RetirerTestInvalide()
        {
            m_maxScore += 1;
            string numClient = "102";
            SorteComptes sorteCompte = SorteComptes.Chèque;
            string nom = "Luc Langevin";
            string motDePasse = "QWERTY";
           
            //Exception Limite supp du solde +1
            int soldeDepart = 100;
            Client target = new Client(numClient, sorteCompte, nom, soldeDepart, motDePasse);
            Assert.IsTrue(retirerAvecArgumentInvalide(target, soldeDepart + 1), "ArgumentOutOfRangeException attendue");


            //Exception MAX + 1
            soldeDepart = Client.MAX_SOLDE;
            target = new Client(numClient, sorteCompte, nom, soldeDepart, motDePasse);
            Assert.IsTrue(retirerAvecArgumentInvalide(target, soldeDepart + 1), "ArgumentOutOfRangeException attendue");

            //H13
            Assert.IsTrue(retirerAvecArgumentInvalide(target, 0), "ArgumentOutOfRangeException attendue");
            Assert.IsTrue(retirerAvecArgumentInvalide(target, -1), "ArgumentOutOfRangeException attendue");
            m_totalScore += 1;
        }


        private bool retirerAvecArgumentInvalide(Client pTarget,int pMontant)
        {
            try
            {
                pTarget.Retirer(pMontant);
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Test méthode ToString
        /// <summary>
        ///Test pour ToString
        ///</summary>
        [TestMethod()]
        public void A05_ToStringTest()
        {
            m_maxScore += 2;
            string chaineLue = "101,0,Jean Lapointe,4360,abc";
            Client target = new Client(chaineLue);
            Assert.AreEqual(chaineLue, target.ToString());
            m_totalScore += 2;
        }
        #endregion

#endif
        #endregion

        #region Tests de la classe Transaction
#if TestClasseTransaction
        /// <summary>
        ///Test pour Constructeur Transaction(chaineLue) pour un retrait
        ///Test aussi les Getter
        ///</summary>
        [TestMethod()]
        public void B01a_TransactionConstr1ParRetrait()
        {
            m_maxScore += 2;
            int sorte = (int)SorteTransactions.Retrait;
            string chaineLue = sorte + ",222,2010-02-18 21:52:14,100";
            Transaction target = new Transaction(chaineLue);
            Assert.AreEqual(SorteTransactions.Retrait, target.SorteTransaction);
            Assert.AreEqual("222", target.NumClient);
            Assert.AreEqual(DateTime.Parse("2010-02-18 21:52:14"), target.Date);
            Assert.AreEqual(100, target.Montant);
            m_totalScore += 2;
        }
        /// <summary>
        ///Test pour Constructeur Transaction pour un retrait négatif -->> exception
        ///</summary>
        [TestMethod()]
        public void B01b_TransactionConstr1ParRetraitNégatif()
        {
            m_maxScore += 1;
            int sorte = (int)SorteTransactions.Retrait;
            string chaineLue = sorte + ",222,2010-02-18 21:52:14,-1";
            try
            {
                Transaction target = new Transaction(chaineLue);
                Assert.Fail("ArgumentException attendue");
            }
            catch (ArgumentException)
            {
                m_totalScore += 1;
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentException attendue");
            }

        }

        /// <summary>
        ///Test pour Constructeur Transaction pour un retrait
        ///</summary>
        [TestMethod()]
        public void B02a_TransactionConstr4ParRetrait()
        {
            m_maxScore += 2;
            SorteTransactions sorte = SorteTransactions.Retrait;
            string numClient = "123";
            DateTime date = DateTime.Now;
            int montant = 300;
            Transaction target = new Transaction(sorte, numClient, date, montant);
            Assert.AreEqual(sorte, target.SorteTransaction);
            Assert.AreEqual(numClient, target.NumClient);
            Assert.AreEqual(date, target.Date);
            Assert.AreEqual(montant, target.Montant);
            m_totalScore += 2;
        }

        /// <summary>
        ///Test pour Constructeur Transaction pour un retrait négatif --> Exception
        ///</summary>
        [TestMethod()]
        public void B02b_TransactionConstr4ParRetraitNegatif()
        {
            m_maxScore += 1;
            SorteTransactions sorte = SorteTransactions.Retrait;
            string numClient = "123";
            DateTime date = DateTime.Now;

            try
            {
                Transaction target = new Transaction(sorte, numClient, date, -1);
                Assert.Fail("ArgumentException attendue");
            }
            catch (ArgumentException)
            {
                m_totalScore += 1;
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentException attendue");
            };
        }

        /// <summary>
        ///Test pour Constructeur Transaction 1 paramètre pour une Connection et une Deconnection
        ///</summary>
        [TestMethod()]
        public void B03_TransactionConstr1ParConnectionDeconnection()
        {
            m_maxScore += 2;
            int sorte = (int)SorteTransactions.Connexion;
            string chaineLue = sorte + ",222,2010-02-18 21:52:14,0";

            Transaction target = new Transaction(chaineLue);
            Assert.AreEqual(SorteTransactions.Connexion, target.SorteTransaction);
            Assert.AreEqual("222", target.NumClient);
            Assert.AreEqual(DateTime.Parse("2010-02-18 21:52:14"), target.Date);
            Assert.AreEqual(0, target.Montant);
            m_totalScore += 1;

            sorte = (int)SorteTransactions.Déconnexion;
            chaineLue = sorte + ",222,2010-02-18 21:52:14,0";
            target = new Transaction(chaineLue);
            Assert.AreEqual(SorteTransactions.Déconnexion, target.SorteTransaction);
            Assert.AreEqual("222", target.NumClient);
            Assert.AreEqual(DateTime.Parse("2010-02-18 21:52:14"), target.Date);
            Assert.AreEqual(0, target.Montant);
            m_totalScore += 1;
        }

        /// <summary>
        ///Test pour Constructeur Transaction  4 paramètres pour une Connection et une Deconnection
        ///</summary>
        [TestMethod()]
        public void B03_TransactionConstr4ParConnectionDeconnection()
        {
            m_maxScore += 2;
            string numClient = "123";
            DateTime date = DateTime.Now;
            Transaction target = new Transaction(SorteTransactions.Connexion, numClient, date, 0);
            Assert.AreEqual(SorteTransactions.Connexion, target.SorteTransaction);
            Assert.AreEqual(numClient, target.NumClient);
            Assert.AreEqual(date, target.Date);
            Assert.AreEqual(0, target.Montant);
            m_totalScore += 1;


            target = new Transaction(SorteTransactions.Déconnexion, numClient, date, 0);
            Assert.AreEqual(SorteTransactions.Déconnexion, target.SorteTransaction);
            Assert.AreEqual(numClient, target.NumClient);
            Assert.AreEqual(date, target.Date);
            Assert.AreEqual(0, target.Montant);
            m_totalScore += 1;

        }
        /// <summary>
        ///Test pour Constructeur Transaction 1 paramètre pour une Connection et une Deconnection 
        ///qui lance une exception à cause que le montant est différent de zéro
        ///</summary>
        [TestMethod()]
        public void B04a_TransactionConstr1ParConnectionDéconnexionException()
        {
            m_maxScore += 1;
            //Test une connexion
            int sorte = (int)SorteTransactions.Connexion;
            string chaineLue = sorte + ",222,2010-02-18 21:52:14,1";
            try
            {
                Transaction target = new Transaction(chaineLue);
                Assert.Fail("ArgumentException attendue");
            }
            catch (ArgumentException)
            {
                //Résultat attendu
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentException attendue");
            };
            //Test une déconnexion
            sorte = (int)SorteTransactions.Déconnexion;
            chaineLue = sorte + ",222,2010-02-18 21:52:14,1";
            try
            {
                Transaction target = new Transaction(chaineLue);
                Assert.Fail("ArgumentException attendue");
            }
            catch (ArgumentException)
            {
                //Résultat attendu
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentException attendue");
            };

            m_totalScore += 1;
        }
        /// <summary>
        ///Test pour Constructeur Transaction  4 paramètres pour une Connection et une Deconnection
        ///qui lance une exception à cause que le montant est différent de zéro
        ///</summary>
        [TestMethod()]
        public void B04b_TransactionConstr4ParConnectionDeconnectionEXception()
        {
            m_maxScore += 1;
            string numClient = "123";
            DateTime date = DateTime.Now;
            Transaction target = null;
            try
            {
                target = new Transaction(SorteTransactions.Connexion, numClient, date, 1);
                Assert.Fail("ArgumentException attendue");
            }
            catch (ArgumentException)
            {
                //Résultat attendu
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentException attendue");
            };

            try
            {
                target = new Transaction(SorteTransactions.Déconnexion, numClient, date, 1);
            }
            catch (ArgumentException)
            {
                //Résultat attendu
            }
            catch (Exception)
            {
                Assert.Fail("ArgumentException attendue");
            };
            m_totalScore += 1;

        }
        #region Test méthode ToString
        /// <summary>
        ///Test pour ToString
        ///</summary>
        [TestMethod()]
        public void B05_ToStringTest()
        {
            m_maxScore += 3;
            string chaineLue = "2,444,2010-03-01 16:41:30,100";
            Transaction target = new Transaction(chaineLue);
            Assert.AreEqual(chaineLue, target.ToString());
            m_totalScore += 3;
        }
        #endregion
#endif
        #endregion

        #region Tests F01 à F03 formulaire principal
#if TestFormulairePrincipalDebut
        /// <summary>
        ///Test pour ChargerCollectionClients
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F01_ChargerCollectionClientsTest()
        {
            m_maxScore += 8;
            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            List<Client> ls = target.ColClients;

            StreamReader f = new StreamReader("..\\..\\..\\AppGuichet\\bin\\Debug\\Fichiers\\Clients.txt");
            string tx = f.ReadToEnd();
            f.Close();
            string[] t = tx.Split('\n');
            int nb = t[t.Length - 1].Length > 0 ? t.Length : t.Length - 1;

            Assert.AreEqual(nb, target.ColClients.Count, "La liste des clients doit contenir le bon nombre de clients");

            // Vérifie la correspondance entre le fichier et la collection des clients 
            for (int index = 0; index < ls.Count; index++)
            {
                Assert.AreEqual(ls[index].NumClient, t[index].Split(',')[0]);
                Assert.AreEqual((int)ls[index].SorteCompte, int.Parse(t[index].Split(',')[1]));
                Assert.AreEqual(ls[index].Nom, t[index].Split(',')[2]);
                Assert.AreEqual(ls[index].Solde, int.Parse(t[index].Split(',')[3]));
                Assert.AreEqual(ls[index].MotDePasse, t[index].Split(',')[4].Split('\r')[0]);
            }

            m_totalScore += 8;
        }

        /// <summary>
        ///Test pour ChargerCollectionTransactions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F02_ChargerCollectionTransactionsTest()
        {
            m_maxScore += 6;
            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            List<Transaction> ls = target.ColTransactions;

            StreamReader f = new StreamReader("..\\..\\..\\AppGuichet\\bin\\Debug\\Fichiers\\Transactions.txt");
            string tx = f.ReadToEnd();
            f.Close();
            string[] t = tx.Split('\n');
            int nb = t[t.Length - 1].Length > 0 ? t.Length : t.Length - 1;

            Assert.AreEqual(nb, ls.Count, "La liste des transactions doit contenir le bon nombre de transactions");

            for (int index = 0; index < ls.Count; index++)
            {
                Assert.AreEqual((int)ls[index].SorteTransaction, int.Parse(t[index].Split(',')[0]));
                Assert.AreEqual(ls[index].NumClient, t[index].Split(',')[1]);
                Assert.AreEqual(ls[index].Date, DateTime.Parse(t[index].Split(',')[2]));
                Assert.AreEqual(ls[index].Montant, int.Parse(t[index].Split(',')[3]));
            }

            m_totalScore += 6;
        }

        /// <summary>
        ///Test pour EnregistrerCollectionClients
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F03_EnregistrerCollectionClientsTest()
        {
            m_maxScore += 6;
            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            List<Client> ls = target.ColClients;
            Client ct = new Client("999", SorteComptes.Épargne, "Test", 12345, "MDP_Test");
            ls.Add(ct);
            target.EnregistrerCollectionClients();

            StreamReader f = new StreamReader("..\\..\\..\\AppGuichet\\bin\\Debug\\Fichiers\\Clients.txt");
            string tx = f.ReadToEnd();
            f.Close();
            string[] t = tx.Split('\n');
            int nb = t[t.Length - 1].Length > 0 ? t.Length : t.Length - 1;

            Assert.AreEqual(nb, ls.Count, "La liste des clients doit contenir le bon nombre de clients");

            // on s'assure que le contenu du fichier Clients.txt correspond au contenu de la liste
            for (int index = 0; index < target.ColClients.Count; index++)
            {
                Assert.AreEqual(ls[index].NumClient, t[index].Split(',')[0]);
                Assert.AreEqual((int)ls[index].SorteCompte, int.Parse(t[index].Split(',')[1]));
                Assert.AreEqual(ls[index].Nom, t[index].Split(',')[2]);
                Assert.AreEqual(ls[index].Solde, int.Parse(t[index].Split(',')[3]));
                Assert.AreEqual(ls[index].MotDePasse, t[index].Split(',')[4].Split('\r')[0]);
            }
            // on va enlever le client test pour ne pas laisser de trace de l'exécution du test dans le fichier Clients.txt
            ls.RemoveAt(ls.Count - 1);
            target.EnregistrerCollectionClients();

            m_totalScore += 6;
        }
#endif
        #endregion

        #region Tests F04 à F06 formulaires FrmListeClients et FrmListeTransactions
#if TestLesFormulairesListe
        /// <summary>
        ///Test pour AfficherListeClients dans FrmListeClients
        ///</summary>
        [TestMethod()]
        public void F04_FormulaireListeClientsTest()
        {
            m_maxScore += 5;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            List<Client> ls = frmPrincipal.ColClients;
            FrmListeClients target = new FrmListeClients(ls);

            Assert.AreEqual(ls.Count, target.lsvClients.Items.Count); // le ListView doit contenir autant de ListViewItem qu'il y a de clients

            // on va vérifier le contenu du ListView
            for (int index = 0; index < ls.Count; index++)
            {
                ListViewItem lvi = target.lsvClients.Items[index];
                Assert.AreEqual(ls[index].NumClient, lvi.SubItems[0].Text);
                Assert.AreEqual(ls[index].Nom, lvi.SubItems[1].Text);
                Assert.AreEqual(ls[index].SorteCompte.ToString(), lvi.SubItems[2].Text);
                Assert.AreEqual(ls[index].Solde.ToString("C2"), lvi.SubItems[3].Text);
                Assert.AreEqual(ls[index].MotDePasse, lvi.SubItems[4].Text);
            }


            m_totalScore += 5;
        }

        /// <summary>
        ///Test pour AfficherListeTransactions dans FrmListeTransactions
        ///</summary>
        [TestMethod()]
        public void F05_ListeTransactionsSansFiltreTest()
        {
            m_maxScore += 5;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            List<Transaction> ls = frmPrincipal.ColTransactions;
            Assert.IsTrue(ls.Count > 0); //Nouveau test pour H16: on suppose un fichier avec transactions dans ce test

            FrmListeTransactions target = new FrmListeTransactions(ls);
            Assert.IsTrue(target.lsvTransactions.Columns.Count > 0);//H16 pour contrer le lsvTransactions.Clear();
            

            Assert.AreEqual(ls.Count, target.lsvTransactions.Items.Count); // le ListView doit contenir autant de ListViewItem qu'il y a de transactions

            // on va vérifier le contenu du ListView
            for (int index = 0, indexFin = ls.Count - 1; index < ls.Count; index++, indexFin--)
            {
                ListViewItem lvi = target.lsvTransactions.Items[index];
                Assert.AreEqual(ls[indexFin].SorteTransaction.ToString(), lvi.SubItems[0].Text);
                Assert.AreEqual(ls[indexFin].NumClient, lvi.SubItems[1].Text);
                Assert.AreEqual(ls[indexFin].Date, DateTime.Parse(lvi.SubItems[2].Text));
                if (ls[indexFin].Montant == 0)
                    Assert.AreEqual("--", lvi.SubItems[3].Text);
                else
                    Assert.AreEqual(ls[indexFin].Montant.ToString("C2"), lvi.SubItems[3].Text);
            }

            m_totalScore += 5;
        }


        /// <summary>
        ///Test pour AfficherListeTransactions dans FrmListeTransactions
        ///</summary>
        [TestMethod()]
        public void F06_ListeTransactionsAvecFiltreTest()
        {
            m_maxScore += 6;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            List<Transaction> ls = frmPrincipal.ColTransactions;
            Assert.IsTrue(ls.Count > 0); //Nouveau test pour H16: on suppose un fichier avec transactions dans ce test

            FrmListeTransactions target = new FrmListeTransactions(ls);
            Assert.IsTrue(target.lsvTransactions.Columns.Count > 0);//H16 pour contrer le lsvTransactions.Clear();
            

            int cptR = 0, cptCD = 0;
            foreach (Transaction t in ls)
            {
                cptCD = t.SorteTransaction == SorteTransactions.Connexion || t.SorteTransaction == SorteTransactions.Déconnexion ? cptCD + 1 : cptCD;
                cptR = t.SorteTransaction == SorteTransactions.Retrait ? cptR + 1 : cptR;
            }

            target.cboOpération.SelectedIndex = 1;
            Assert.AreEqual(cptCD, target.lsvTransactions.Items.Count);
            m_totalScore += 3;

            target.cboOpération.SelectedIndex = 2;
            Assert.AreEqual(cptR, target.lsvTransactions.Items.Count);
            m_totalScore += 3;
        }
#endif
        #endregion

        #region Tests F07 à F12 formulaire principal
#if TestFormulairePrincipaleSuite
        /// <summary>
        ///Test pour vérifier l'état initial du formulaire principal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F07_EtatInitialFrmPrincipal()
        {
            m_maxScore += 4;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();

            Assert.IsTrue(target.txtNumClient.Enabled);
            Assert.IsTrue(target.txtMotDePasse.Enabled);
            Assert.AreEqual("", target.txtNumClient.Text);
            Assert.AreEqual("", target.txtMotDePasse.Text);
            Assert.AreEqual("Se connecter", target.btnConnexion.Text);
            Assert.IsTrue(target.btnConnexion.Enabled);
            Assert.IsTrue(target.grpIdentification.Enabled);

            Assert.IsFalse(target.mnuAdministrateur.Enabled);
            Assert.IsFalse(target.mnuAdminListeClients.Enabled);
            Assert.IsFalse(target.mnuAdminListeTransactions.Enabled);
            Assert.IsFalse(target.grpInfosClient.Enabled);

            m_totalScore += 4;
        }


        /// <summary>
        ///Test pour vérifier une connexion valide d'un client normal
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F08_SeConnecterIdentificationValide()
        {
            m_maxScore += 8;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            int nbT = target.ColTransactions.Count;
            // Un client au hasard est choisi pour établir la connection, sauf l'administrateur
            Random objR = new Random();
            Client objC = target.ColClients[objR.Next(1, target.ColClients.Count)];
            // on va essayer de se connecter
            target.txtNumClient.Text = objC.NumClient;
            target.txtMotDePasse.Text = objC.MotDePasse;
            target.btnConnexion_Click(null, null);
            // État du formulaire après la connexion
            Assert.IsFalse(target.lblMotDePasse.Enabled);
            Assert.IsFalse(target.txtMotDePasse.Enabled);
            Assert.AreEqual("Se déconnecter", target.btnConnexion.Text);
            Assert.IsTrue(target.grpInfosClient.Enabled);
            m_totalScore += 3;

            // On va vérifier le contenu du groupe Informations/Opérations
            Assert.AreEqual(objC.Nom, target.txtNom.Text);
            Assert.AreEqual(objC.SorteCompte.ToString(), target.txtSorteCompte.Text);
            Assert.AreEqual(objC.Solde.ToString("C0"), target.txtSolde.Text);
            m_totalScore += 3;

            // On va vérifier le combo des montants et le bouton retirer
            Assert.AreEqual(-1, target.cboMontant.SelectedIndex);
            Assert.IsFalse(target.btnRetirer.Enabled);

            // le nombre de transactions devrait augmenter de 1
            target = new FrmPrincipal();
            Assert.AreEqual(nbT + 1, target.ColTransactions.Count);

            m_totalScore += 2;
        }


        /// <summary>
        ///Test pour vérifier la gestion de la connexion lorsqu'il y a des erreurs
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F09_SeConnecterErreurIdentification()
        {
            m_maxScore += 10;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            Random objR = new Random();
            Client objC = target.ColClients[objR.Next(1, target.ColClients.Count)];

            // on va essayer de se connecter avec des données non valides
            target.txtNumClient.Text = "!!!";
            target.txtMotDePasse.Text = "???";
            target.btnConnexion_Click(null, null);

            // État du formulaire après l'essai de connexion avec un mauvais NumClient
            Assert.AreEqual("Se connecter", target.btnConnexion.Text);
            Assert.IsFalse(target.grpInfosClient.Enabled);
            Assert.AreEqual("", target.txtNumClient.Text);
            Assert.AreEqual("Numéro de client non valide", target.errIdentification.GetError(target.txtNumClient));
            Assert.AreEqual("???", target.txtMotDePasse.Text);
            Assert.AreEqual("", target.errIdentification.GetError(target.txtMotDePasse));


            m_totalScore += 4;

            // on va essayer de se connecter avec un bon numéro de client mais un mauvais mot de passe
            target.txtNumClient.Text = objC.NumClient;
            target.txtMotDePasse.Text = "???";
            target.btnConnexion_Click(null, null);

            // État du formulaire après l'essai de connexion avec un bon numéro de client mais un mauvais mot de passe
            Assert.AreEqual("Se connecter", target.btnConnexion.Text);
            Assert.IsFalse(target.grpInfosClient.Enabled);
            Assert.AreEqual(objC.NumClient, target.txtNumClient.Text);
            Assert.AreEqual("Mot de passe incorrect", target.errIdentification.GetError(target.txtMotDePasse));
            Assert.AreEqual("", target.txtMotDePasse.Text);
            Assert.AreEqual("", target.errIdentification.GetError(target.txtNumClient));

            m_totalScore += 4;

            // on devrait être en mesure de se connecter avec les bonnes informations 
            target.txtNumClient.Text = objC.NumClient;
            target.txtMotDePasse.Text = objC.MotDePasse;
            target.btnConnexion_Click(null, null);
            Assert.AreEqual("", target.errIdentification.GetError(target.txtNumClient));
            Assert.AreEqual("", target.errIdentification.GetError(target.txtMotDePasse));

            m_totalScore += 2;
        }

        /// <summary>
        ///Test pour vérifier une connexion valide d'un administrateur
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F10_SeConnecterAdministrateurValide()
        {
            m_maxScore += 4;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();

            int nbT = target.ColTransactions.Count;
            // Un client au hasard est choisi pour établir la connection, sauf l'administrateur
            Client objC = target.RechercherClient("000");
            // on va essayer de se connecter
            target.txtNumClient.Text = objC.NumClient;
            target.txtMotDePasse.Text = objC.MotDePasse;
            target.btnConnexion_Click(null, null);

            //// État du formulaire après la connexion par l'administrateur
            Assert.IsFalse(target.lblMotDePasse.Enabled);
            Assert.IsFalse(target.txtMotDePasse.Enabled);
            Assert.AreEqual("Se déconnecter", target.btnConnexion.Text);
            Assert.IsFalse(target.grpInfosClient.Enabled);

            Assert.IsTrue(target.mnuAdministrateur.Enabled);
            Assert.IsTrue(target.mnuAdminListeClients.Enabled);
            Assert.IsTrue(target.mnuAdminListeTransactions.Enabled);

            m_totalScore++;

            //// On va vérifier le contenu du groupe Informations/Opérations
            Assert.AreEqual(objC.Nom, target.txtNom.Text);
            Assert.AreEqual(objC.SorteCompte.ToString(), target.txtSorteCompte.Text);
            Assert.AreEqual(objC.Solde.ToString("C0"), target.txtSolde.Text);
            Assert.AreEqual(-1, target.cboMontant.SelectedIndex);

            m_totalScore++;

            // le nombre de transactions devrait augmenter de 1
            DateTime actuel = DateTime.Now;
            target = new FrmPrincipal();
            int nouveauCount = target.ColTransactions.Count;
            Assert.AreEqual(nbT + 1, nouveauCount);
            // on s'assure que la nouvelle transaction possède une Date récente d'au plus 1 minute
            Assert.IsTrue(target.ColTransactions[nouveauCount - 1].Date > DateTime.Now - new TimeSpan(0, 1, 0));
            m_totalScore += 2;
        }


        /// <summary>
        /// Test pour vérifier la déconnexion normale ou par le FormClosing et les ajouts dans le fichier des transactions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F11_SeDeconnecter()
        {
            m_maxScore += 4;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            int nbT = target.ColTransactions.Count;
            // Un client au hasard est choisi pour établir la connection, sauf l'administrateur
            Random objR = new Random();
            Client objC = target.ColClients[objR.Next(1, target.ColClients.Count)];
            // on va essayer de se connecter (+1)
            target.txtNumClient.Text = objC.NumClient;
            target.txtMotDePasse.Text = objC.MotDePasse;
            target.btnConnexion_Click(null, null);
            // on va se déconnecter (+1)
            target.btnConnexion_Click(null, null);

            Assert.AreEqual(String.Empty, target.txtNumClient.Text);
            Assert.AreEqual(String.Empty, target.txtMotDePasse.Text);
            Assert.AreEqual(String.Empty, target.txtSolde.Text);
            Assert.AreEqual(String.Empty, target.txtNom.Text);
            Assert.AreEqual(String.Empty, target.txtSorteCompte.Text);
       
            // on va se connecter de nouveau (+1)
            target.txtNumClient.Text = objC.NumClient;
            target.txtMotDePasse.Text = objC.MotDePasse;
            target.btnConnexion_Click(null, null);
            // on va se déconnecter par le FormClosing (+1)
            target.FrmPrincipal_FormClosing(null, new FormClosingEventArgs(CloseReason.None, false));





            // le nombre de transactions devrait augmenter de 4
            target = new FrmPrincipal();
            int nouveauCount = target.ColTransactions.Count;
            Assert.AreEqual(nbT + 4, nouveauCount);
            // on s'assure que les nouvelles transactions possèdent une Date récente d'au plus 1 minute
            Assert.IsTrue(target.ColTransactions[nouveauCount - 4].Date > DateTime.Now - new TimeSpan(0, 1, 0));
            Assert.AreEqual( SorteTransactions.Connexion,target.ColTransactions[nouveauCount - 4].SorteTransaction);

            Assert.IsTrue(target.ColTransactions[nouveauCount - 3].Date > DateTime.Now - new TimeSpan(0, 1, 0));
            Assert.AreEqual( SorteTransactions.Déconnexion,target.ColTransactions[nouveauCount - 3].SorteTransaction);

            Assert.IsTrue(target.ColTransactions[nouveauCount - 2].Date > DateTime.Now - new TimeSpan(0, 1, 0));
            Assert.AreEqual( SorteTransactions.Connexion,target.ColTransactions[nouveauCount - 2].SorteTransaction);

            Assert.IsTrue(target.ColTransactions[nouveauCount - 1].Date > DateTime.Now - new TimeSpan(0, 1, 0));
            Assert.AreEqual( SorteTransactions.Déconnexion,target.ColTransactions[nouveauCount - 1].SorteTransaction);



            m_totalScore += 4;
        }

        /// <summary>
        ///Test pour vérifier le fonctionnement du bouton Retrait
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AppGuichet.exe")]
        public void F12_BoutonRetraitFrmPrincipal()
        {
            m_maxScore += 4;

            Directory.SetCurrentDirectory("..\\..\\..\\AppGuichet\\bin\\Debug");
            FrmPrincipal target = new FrmPrincipal();
            int nbT = target.ColTransactions.Count;

            Client objT = new Client("F12", SorteComptes.Épargne, "Test F12", 1000, "abc");
            target.ColClients.Add(objT);

            target.ClientCourant = objT;
            target.cboMontant.SelectedIndex = 0;
            target.btnRetirer_Click(null, null);

            Assert.AreEqual(980, objT.Solde);
            // On va vérifier l'ajout de la nouvelle transaction
            target = new FrmPrincipal();
            int nouveauCount = target.ColTransactions.Count;
            Assert.AreEqual(nbT + 1, nouveauCount);
            Assert.IsTrue(target.ColTransactions[nouveauCount - 1].Date > DateTime.Now - new TimeSpan(0, 1, 0));
            Assert.AreEqual( SorteTransactions.Retrait,target.ColTransactions[nouveauCount - 1].SorteTransaction);

            m_totalScore += 4;


        }
#endif
        #endregion

    }
}
