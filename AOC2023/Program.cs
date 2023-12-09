using AOC2023;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Enter day to solve (q to exit): ");
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }

    if (!int.TryParse(input, out var day) || day < 1 || day > 25)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input");
        Console.ResetColor();
        continue;
    }

    Console.ResetColor();
    Helpers.Solve(day);
    Console.WriteLine();
}