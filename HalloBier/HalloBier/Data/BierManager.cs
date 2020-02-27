using HalloBier.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HalloBier.Data
{
    public class BierManager
    {

        public IEnumerable<Kaffee> GetDemoKaffee()
        {
            yield return new Kaffee()
            {
                Rösterei = "Lavazza",
                Sorte = "Café Crema Classico",
                Coffein = 7,
                Geschmack = Taste.Chocolate
            };

            yield return new Kaffee()
            {
                Rösterei = "Schümli",
                Sorte = "Café Crema Schlürf",
                Coffein = 9,
                Geschmack = Taste.WoodAndTabacco
            };

            yield return new Kaffee()
            {
                Rösterei = "Jakobs",
                Sorte = "Café Crema siff",
                Coffein = 4,
                Geschmack = Taste.FruityAndFloral
            };
        }

        public IEnumerable<Bier> GetDemoBiere()
        {
            yield return new Bier()
            {
                Marke = "Welde",
                Name = "No.1",
                Alk = 5.1,
                Preis = 4.2m,
                Lecker = true,
                Sorte = Sorten.Pils
            };

            yield return new Bier()
            {
                Marke = "Rothaus",
                Name = "Tannenzäpfle",
                Alk = 5.1,
                Preis = 4.2m,
                Lecker = true,
                Sorte = Sorten.Pils
            };

            yield return new Bier()
            {
                Marke = "Augustiner",
                Name = "Edelstoff",
                Alk = 5.6,
                Preis = 4.2m,
                Lecker = true,
                Sorte = Sorten.Export
            };

            yield return new Bier()
            {
                Marke = "Augustiner",
                Name = "Heller Bock",
                Alk = 7,
                Preis = 4.2m,
                Lecker = !true,
                Sorte = Sorten.Bock
            };
        }
    }
}
