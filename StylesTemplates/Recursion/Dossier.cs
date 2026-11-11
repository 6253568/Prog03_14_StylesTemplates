using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class Dossier
    {
        public required int TailleKo { get; set; } // Taille des fichiers dans ce dossier

        public List<Dossier> SousDossiers { get; set; } = new List<Dossier>();
    }
}
