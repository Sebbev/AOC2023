using System.Collections.Immutable;

namespace AOC2023;

public abstract class Day
{
    protected readonly IImmutableList<string> Input;

    protected Day(int day)
    {
        Input = Helpers.GetInput(day).ToImmutableList();
    }

    public virtual void SolvePart1()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Part 1 not implemented");
        Console.ResetColor();
    }

    public virtual void SolvePart2()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Part 2 not implemented");
        Console.ResetColor();
    }
}