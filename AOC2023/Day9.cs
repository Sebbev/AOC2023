namespace AOC2023;

public class Day9 : Day
{
    public Day9() : base(9)
    {
    }

    public override void SolvePart1()
    {
        var total = 0;
        foreach (var pattern in Input)
        {
            var values = pattern.Split(' ').Select(int.Parse).ToList();
            var extrapolated = Extrapolate(values);
            total += extrapolated;
        }

        Console.WriteLine(total);
    }

    public override void SolvePart2()
    {
        var total = 0;
        foreach (var pattern in Input)
        {
            var values = pattern.Split(' ').Select(int.Parse).ToList();
            var extrapolated = Extrapolate(values, true);
            total += extrapolated;
        }
        
        Console.WriteLine(total);
    }

    // ReSharper disable once UnusedMember.Local
    private void SolveExample()
    {
        // List<string> input =
        // [
        //     "0 3 6 9 12 15",
        //     "1 3 6 10 15 21",
        //     "10 13 16 21 30 45"
        // ]; // Result : 114

        List<string> input =
        [
            "10 13 16 21 30 45"
        ]; // Result : 5

        var total = 0;
        foreach (var pattern in input)
        {
            var values = pattern.Split(' ').Select(int.Parse).ToList();
            var extrapolated = Extrapolate(values, true);
            total += extrapolated;
        }

        Console.WriteLine(total);
    }

    private static int Extrapolate(List<int> values, bool reverse = false)
    {
        var differences = GetDifference(values).ToList();
        var diffs = new List<List<int>>
        {
            differences
        };

        while (differences.Exists(x => x != 0))
        {
            differences = GetDifference(differences).ToList();
            diffs.Add(differences);
        }

        diffs.Reverse();
        if (reverse)
        {
            diffs[0].Insert(0, 0);
        }
        else
        {
            diffs[0].Add(0);
        }

        for (var i = 0; i < diffs.Count; i++)
        {
            var nextIndex = i + 1;
            if (nextIndex >= diffs.Count)
            {
                continue;
            }

            if (reverse)
            {
                diffs[nextIndex].Insert(0, diffs[nextIndex][0] - diffs[i][0]);
            }
            else
            {
                diffs[nextIndex].Add(diffs[i][^1] + diffs[nextIndex][^1]);
            }
        }

        if (reverse)
        {
            return values[0] - diffs[^1][0];
        }

        return values[^1] + diffs[^1][^1];
    }

    private static IEnumerable<int> GetDifference(IList<int> values)
    {
        for (var i = 0; i < values.Count - 1; i++)
        {
            yield return values[i + 1] - values[i];
        }
    }
}