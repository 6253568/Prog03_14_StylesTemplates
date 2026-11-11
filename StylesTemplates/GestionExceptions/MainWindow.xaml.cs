using System.Windows;

namespace GestionExceptions
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDiviser_Click(object sender, RoutedEventArgs e)
        {
            // Essayez: "4", "abc", "0", "-5", "99999999999"
            try
            {
                int resultat = Diviser(100, tBoxDiviseur.Text);

                tBlkResultat.Text = $"Résultat : {resultat}";
            }
            catch (FormatException)
            {
                tBlkResultat.Text = "Erreur : entrez un nombre entier.";
            }
            catch (DivideByZeroException)
            {
                tBlkResultat.Text = "Erreur : division par zéro impossible.";
            }
            catch (ArgumentException ex)
            {
                // ex.Message contient le message qu'on a écrit dans le throw
                tBlkResultat.Text = $"Erreur : {ex.Message}";
            }
            catch (Exception ex)
            {
                // Catch général attrape toutes les autres exceptions (Exemple ici: "OverflowException")
                // Ordre important!
                tBlkResultat.Text = $"Erreur inattendue : {ex.Message}";
            }
            finally
            {
                // Le finally s'exécute toujours, qu'il y ait eu une exception ou non.
                tBoxDiviseur.Focus();
                tBoxDiviseur.SelectAll();
            }
        }

        /// <summary>
        /// Divise un nombre par le diviseur reçu sous forme de texte.
        /// </summary>
        /// <exception cref="FormatException">Le texte n'est pas un nombre entier.</exception>
        /// <exception cref="OverflowException">Le nombre est trop grand pour un int.</exception>
        /// <exception cref="ArgumentException">Le diviseur est négatif.</exception>
        /// <exception cref="DivideByZeroException">Le diviseur est 0.</exception>
        private int Diviser(int nombre, string texteDiviseur)
        {
            // Exceptions lancées automatiquement par .NET :
            // int.Parse lance "FormatException" ou "OverflowException"
            int diviseur = int.Parse(texteDiviseur);

            // Exception lancée par nous-même
            if (diviseur < 0)
                throw new ArgumentException("le diviseur doit être positif.");

            // Autre exception automatique: "DivideByZeroException" si diviseur == 0.
            return nombre / diviseur;
        }
    }
}