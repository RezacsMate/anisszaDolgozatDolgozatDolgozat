using System.Xml.Schema;

namespace anisszaDolgozatDolgozatDolgozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Használd az alábbi listát, az adatokat helyetesen állítsd be:
            //Az adatok sorrendje : márka, típus, ár, értékelés, átlagfogyasztás, lóerő, tulajdonos

            // A record az alábbi adatokat tárolja:
            // - Brand : string – public, immutable
            // - Type : string – public, immutable

            // - Price : int – private, mutable
            // - Rating : double – public, mutable
            // - AverageConsumption : double – private, mutable
            // - Hp : int – public, immutable
            // - Owner : string – private, immutable
            Console.WriteLine("Hello, Friend!");

            List<Auto> autos = new List<Auto>()
{
    new Auto("Toyota", "Corolla", 140, "Nagy Peter"),
    new Auto("BMW", "330i", 245, "Kiss Adam"),
    new Auto("Tesla", "Model 3", 410, "Zsár Dániel"),
    new Auto("Honda", "Civic", 220, "Zsár Dániel"),
    new Auto("Toyota", "Camry", 218, "Kiss Adam"),
    new Auto("BMW", "520i", 208, "Szabo David"),
    new Auto("Ford", "Mustang", 450, "Szabo David")
};
            autos[0].SetAverageConsumption(5.8);
            autos[1].SetAverageConsumption(7.2);
            autos[2].SetAverageConsumption(0.4);
            autos[3].SetAverageConsumption(10.2);
            autos[4].SetAverageConsumption(6.4);
            autos[5].SetAverageConsumption(6.8);
            autos[6].SetAverageConsumption(10.5);
            autos[0].SetPrice(9500000);
            autos[1].SetPrice(18500000);
            autos[2].SetPrice(9000000);
            autos[3].SetPrice(2000000);
            autos[4].SetPrice(14500000);
            autos[5].SetPrice(22500000);
            autos[6].SetPrice(24000000);
            autos[0].SetRating(8.7);
            autos[1].SetRating(9.1);
            autos[2].SetRating(4.3);
            autos[3].SetRating(7.3);
            autos[4].SetRating(8.8);
            autos[5].SetRating(8.9);
            autos[6].SetRating(9.2);






            // LINQ FELADATOK


            // 1.feladat
            // LINQ segítségével számold meg, hány Toyota márkájú autó található a listában!
            Console.WriteLine(autos.Where(x => x.Brand == "Toyota").Count());

            // 2.feladat
            // LINQ segítségével számítsd ki az összes autó Price értékének összegét!

            Console.WriteLine(autos.Sum(x => x.GetPrice()));
            // 3.feladat
            // LINQ segítségével számítsd ki a BMW márkájú autók átlagos teljesítményét (lóerő)!
            Console.WriteLine(autos.Where(x => x.Brand == "BMW").Average(x => x.HP));

            // 4.feladat
            // LINQ segítségével keresd meg a legolcsóbb autónak a típusát!
            Console.WriteLine(autos.OrderBy(x => x.GetPrice()).Select(x=>x.Brand).First());

            // 5.feladat
            // LINQ segítségével add meg az összes autómárkát!
            // Minden márka csak egyszer szerepeljen az eredményben!
            autos.Select(x => x.Brand).Distinct().ToList().ForEach(x => Console.WriteLine(x));


            // 6.feladat
            // LINQ segítségével add vissza márkánként, hogy hány autó tartozik az adott márkához!
            foreach (KeyValuePair<string, int> item in autos.Select(x => x.Brand).Distinct().ToDictionary(x => x, x => x.Count()))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }


            // 7.feladat
            // LINQ segítségével számítsd ki tulajdonosonként az autók árának értékeinek összegét!
            
            foreach (KeyValuePair<string, int> item in autos.GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.Sum(x => x.GetPrice())))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }
            // 8.feladat
            // LINQ segítségével add vissza márkánként az autók átlagos értékelését!
            foreach (KeyValuePair<string, double> item in autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Average(x => x.GetPrice())))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }

            // 9.feladat
            // LINQ segítségével add vissza márkánként a legjobb értékelésű autójának típusát!

            foreach (KeyValuePair<string, string> item in autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.OrderByDescending(x => x.GetRating()).Select(x=>x.Brand).First()))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }

            // 10.feladat
            // LINQ segítségével keresd meg minden tulajdonos legdrágább autójának típusát!
            foreach (KeyValuePair<string, string> item in autos.GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.OrderByDescending(x => x.GetPrice()).Select(x => x.Brand).First()))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }

            // 11..feladat
            // LINQ segítségével számítsd ki márkánként az autók átlagos árát, 
            // de csak azokat mentsd el, amelyek átlagos értékelése legalább 8.8!
            foreach (KeyValuePair<string, double> item in autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Where(x=>x.GetRating()>=8.8).Average(x=>x.GetPrice())))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }

            // 12.feladat
            // LINQ segítségével számítsd ki tulajdonosonként
            // az autók átlagos árát, majd keresd meg azt a tulajdonost, akinek az autói átlagosan a legdrágábbak!
            foreach (KeyValuePair<string, double> item in autos.GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.Average(x => x.GetPrice())))
            {
                Console.WriteLine($"{item.Key}--{item.Value}");
            }
            
        }
    }
}
