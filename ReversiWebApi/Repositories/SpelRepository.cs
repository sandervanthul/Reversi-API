﻿using System.Collections.Generic;
using ReversiWebApi.Models;

namespace ReversiWebApi.Repositories
{
    public class SpelRepository // komt niet langer overeen met ISpelRepository en wordt net meer gebruikt dus overerving verwijdert
    {
        // Lijst met tijdelijke spellen
        public List<Spel> Spellen { get; set; }

        public SpelRepository()
        {
            Spel spel1 = new Spel();
            Spel spel2 = new Spel();
            Spel spel3 = new Spel();

            spel1.Speler1Token = "abcdef";
            spel1.Omschrijving = "Potje snel reversi, dus niet lang nadenken";
            spel2.Speler1Token = "ghijkl";
            spel2.Speler2Token = "mnopqr";
            spel2.Omschrijving = "Ik zoek een gevorderde tegenspeler!";
            spel3.Speler1Token = "stuvwx";
            spel3.Omschrijving = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";

            Spellen = new List<Spel> { spel1, spel2, spel3 };
        }

        public void AddSpel(Spel spel) => Spellen.Add(spel);

        public List<Spel> GetSpellen() => Spellen;

        public Spel GetSpel(string token) => Spellen.Find(s => s.Token == token);

        public Spel GetSpelMetSpelerToken(string token) => Spellen.Find(s => s.Speler1Token == token || s.Speler2Token == token);
    }
}
