using System;


class Series
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string FirstPlatform { get; set; }
}

class ComedySeries
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Series> seriesList = new List<Series>();
        string continueAdding;

        do
        {
            Series newSeries = new Series();

            Console.Write("Seri Adı: ");
            newSeries.Name = Console.ReadLine();

            Console.Write("Yayınlanma Yılı: ");
            newSeries.ProductionYear = int.Parse(Console.ReadLine());

            Console.Write("Türü: ");
            newSeries.Genre = Console.ReadLine();

            Console.Write("Bitme Yılı: ");
            newSeries.ReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Yönetmen: ");
            newSeries.Director = Console.ReadLine();

            Console.Write("İlk Yayınlandığı Yer: ");
            newSeries.FirstPlatform = Console.ReadLine();

            seriesList.Add(newSeries);

            Console.Write("Yeni dizi eklemek ister misiniz? (y/n): ");
            continueAdding = Console.ReadLine();

        } while (continueAdding.ToLower() == "y");

        // Create a list of comedy series
        var comedySeriesList = seriesList
            .Where(s => s.Genre.Contains("Comedy"))
            .Select(s => new ComedySeries
            {
                Name = s.Name,
                Genre = s.Genre,
                Director = s.Director
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Director)
            .ToList();

        Console.WriteLine("\nComedy Series:");
        Console.WriteLine("| Series Name      | Genre   | Director              |");
        Console.WriteLine("|------------------|---------|-----------------------|");

        foreach (var series in comedySeriesList)
        {
            Console.WriteLine($"| {series.Name,-16} | {series.Genre,-7} | {series.Director,-21} |");
        }
    }
}
