namespace AOC2023;

public static class Helpers
{
    public static string[] GetInput(int day)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Inputs", $"Day{day}.txt");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Input file for day {day} not found.");
        }

        return File.ReadAllLines(path);
    }
    
    public static void Solve(int day)
    {
        var type = Type.GetType($"AOC2023.Day{day}");
        if (type?.GetConstructor(Array.Empty<Type>())?.Invoke(null) is not Day dayObj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Day {day} not yet solved/implemented");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"############# Day {day} #############\n");
        Console.ResetColor();

        dayObj.SolvePart1();
        dayObj.SolvePart2();
    }
}