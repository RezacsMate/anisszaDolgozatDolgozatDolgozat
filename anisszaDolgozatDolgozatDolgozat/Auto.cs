using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anisszaDolgozatDolgozatDolgozat
{
    internal record Auto(string Brand, string Type, int HP, string Owner)
    {


        // A record az alábbi adatokat tárolja:
        // - Brand : string – public, immutable
        // - Type : string – public, immutable

        // - Price : int – private, mutable
        // - Rating : double – public, mutable
        // - AverageConsumption : double – private, mutable
        // - Hp : int – public, immutable
        // - Owner : string – private, immutable
        private int Price { get; set; }
        private double Rating { get; set; }
        private double AverageConsumption { get; set; }
        
        // Készíts Get függvényt az AverageConsumption értékéhez!
        public double GetAverageConsumption() 
        {
            return AverageConsumption;
        }
        // Készíts Get függvényt az Owner értékéhez!
        public string GetOwner()
        {
            return Owner;
        }
        // Készíts Get függvényt az Price értékéhez!
        public int GetPrice()
        {
            return Price;
        }
        public double GetRating()
        {
            return Rating;
        }
        // Készíts Set függvényt az AverageConsumption értékéhez!
        public void SetAverageConsumption(double consuption)
        {
            AverageConsumption = consuption;
        }
        // Készíts Set függvényt az Price értékéhez!
        public void SetPrice(int price)
        {
            Price =price ;
        }
        public void SetRating(double rating)
        {
            Rating = rating ;
        }


        // 1.feladat
        // Készíts egy public függvényt, amely eldönti, hogy az autó erősnek számít-e!
        // Egy autó akkor számít erősnek, ha legalább 200 lóerős.
        public bool IsStrong() 
        {
            return HP >= 200 ? true : false;
        }

        // 2.feladat
        // Készíts egy public függvényt, amely eldönti, hogy az autó jó értékelésű-e!
        // Egy autó akkor számít jó értékelésűnek, ha a Rating legalább 8.5.
        public bool IsGoodRating() 
        {
            return Rating >= 8.5? true : false;
        }


        // 3.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy maximális árat!
        // A függvény döntse el, hogy az autó ára nem haladja-e meg a megadott összeget!

        public bool IsLessThan(int maxPrice) 
        {
            return Price < maxPrice? true : false;
        }

        // 4.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy százalékos kedvezményt!
        // Ha a kedvezmény 1 és 30 százalék közé esik, csökkentse ennek megfelelően az autó Price értékét!

        public void Discount(int discount) 
        {
            if (discount >= 1 && discount <= 30) 
            {
                Price *= 1 - (discount / 100);
            }
        }
        // 5.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy megtett távolságot kilométerben!
        // A függvény számítsa ki, hogy az autó átlagosan hány liter üzemanyagot használna el a megadott távolság megtételéhez!
        // Az AverageConsumption érték 100km-re vonatkozik

        public double LiteConsuption(int km) 
        {
            
            return km / AverageConsumption;
        }
        // 6.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy üzemanyagárat és egy távolságot!
        // A függvény számítsa ki, hogy az adott távolság megtétele mennyibe kerülne az autóval!

        public double HowExpensive(double gasPrice, int km)
        {
            return gasPrice * LiteConsuption(km);
        }
        // 7.feladat
        // Készíts egy public függvényt, amely paraméterként kap egy új értékelést!
        // Ha az értékelés 1 és 10  közé esik, állítsa be az új értékelést, amúgy maradjon a régi.
        public void NewRating(double newRating) 
        {
            if (newRating >= 1 && newRating <= 10)
            {
                Rating = newRating;
            }
            
        }
        // 8.feladat
        // Készíts egy public függvényt, amely visszaadj egy szöveget, az alábbi példa alapján :
        // "Az autót a BMW cég gyártotta, ez a M5 Competition (F90) típusú, Kiss János a gazdája és 30000000 forintba került"
        public override string ToString()
        {
            return $"Az auto a {Brand} cég gyártotta, ez a {Type} tupusú, {Owner} a gazdája és {Price} forintvba kerult";
        }
        // A record az alábbi adatokat tárolja:
        // - Brand : string – public, immutable
        // - Type : string – public, immutable

        // - Price : int – private, mutable
        // - Rating : double – public, mutable
        // - AverageConsumption : double – private, mutable
        // - Hp : int – public, immutable
        // - Owner : string – private, immutable

        

    }
}
