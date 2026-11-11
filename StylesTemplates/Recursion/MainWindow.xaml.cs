using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recursion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
             Mes documents (100)
                Cours (200)
                    SF3 (300)
                        TP (400)
                Photos (500)
            */

            Dossier tp = new Dossier() { TailleKo = 400 };
            Dossier sf3 = new Dossier() { TailleKo = 300 };
            sf3.SousDossiers.Add(tp);
            Dossier cours = new Dossier() { TailleKo = 200 };
            cours.SousDossiers.Add(sf3);
            Dossier photos = new Dossier() { TailleKo = 500 };
            Dossier racine = new Dossier() { TailleKo = 100 };
            racine.SousDossiers.Add(cours);
            racine.SousDossiers.Add(photos);
            
            tBlkBoucles.Text = $"Avec boucles: {TailleAvecBoucles(racine)} Ko";
            tBlkRecursion.Text = $"Avec récursion: {TailleRecursion(racine)} Ko"; //  Bonne valeur (1500 Ko)
        }

        private int TailleRecursion(Dossier racine)
        {
            int total = racine.TailleKo;

            foreach (Dossier dossier in racine.SousDossiers)
            {
                total += TailleRecursion(dossier); // Appel récursif
            }

            return total;
        }

        // Sans récursion:
        // Une boucle par niveau
        // Pour aller plus profond, il faudrait d'autres boucles...
        // mais on ne sait pas combien de niveaux il y aura
        private int TailleAvecBoucles(Dossier racine)
        {
            int tailleTotale = racine.TailleKo;

            foreach (Dossier dossier in racine.SousDossiers)
            {
                tailleTotale += dossier.TailleKo;

                //foreach (Dossier dossier1 in dossier.SousDossiers)
                //{
                //    tailleTotale += dossier1.TailleKo;

                //    foreach (Dossier dossier2 in dossier1.SousDossiers)
                //    {
                //        tailleTotale += dossier.TailleKo;
                //    }
                //}
            }

            return tailleTotale;
        }
    }
}