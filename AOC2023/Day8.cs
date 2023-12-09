using System.Collections.Immutable;

namespace AOC2023;

public sealed class Day8 : Day
{
    private const string StartLocation = "AAA";
    private const string EndLocation = "ZZZ";

    private readonly string _instructions;
    private readonly Dictionary<string, Node> _dict = new();

    public Day8() : base(8)
    {
        _instructions = Input[0];
        foreach (var point in Input.Skip(1))
        {
            if (string.IsNullOrEmpty(point)) continue;

            var split = point.Split(" = ");
            var location = split[0];
            var left = split[1].Substring(1, 3);
            var right = split[1].Substring(6, 3);

            _dict.Add(location, new Node(location, left, right));
        }
    }

    public override void SolvePart1()
    {
        var steps = 0;
        var currentNode = _dict[StartLocation];
        while (currentNode.Location != EndLocation)
        {
            currentNode = FollowInstruction(currentNode, GetInstruction(steps));
            steps++;
        }

        Console.WriteLine("Found end location in {0} steps", steps);
    }

    private Node FollowInstruction(Node node, char instruction)
    {
        return instruction switch
        {
            'L' => _dict[node.Left],
            'R' => _dict[node.Right],
            _ => node
        };
    }

    private char GetInstruction(int index) => _instructions[index % _instructions.Length];

    public override void SolvePart2()
    {
        var nodes = _dict.Where(x => x.Key[2] == 'A')
            .Select(x => x.Value)
            .ToList();

        var nodeSteps = nodes.Select(FollowNodeLoop).ToArray();

        var lcm = Lcm(nodeSteps);
        Console.WriteLine("Found end location in {0} steps", lcm);
    }

    private long FollowNodeLoop(Node start)
    {
        var steps = 0L;
        var currentNode = start;
        while (currentNode.Location[2] != 'Z')
        {
            currentNode = FollowInstruction(currentNode, GetInstruction((int)steps));
            steps++;
        }

        return steps;
    }
    
    private static long Lcm(params long[] numbers)
    {
        return numbers.Aggregate(Lcm);
    }

    private static long Lcm(long a, long b)
    {
        return a / Gcd(a, b) * b;
    }

    private static long Gcd(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }
}

internal sealed record Node(string Location, string Left, string Right);