using System.IO;
using System.Runtime.CompilerServices;
class Test
{
    public static void Main()
    {
        RosterGenerator gen = new RosterGenerator();
        Priority priogen = new Priority();
        Player[] roster = gen.GenerateRoster();
        PrintRoster(roster);
        Settings settings = new Settings();
        int[] intervals = settings.intervals;
        Console.WriteLine(intervals[0]);
        Dictionary<int, string[]> bufflist = FindSpec(roster, priogen.priority, intervals);
        PrintBufflist(bufflist);
        CreateNote(bufflist, roster);
    }
    private static Dictionary<int, string[]> FindSpec(Player[] players, string[][] prio, int[] intervals)
    {
        Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
        for (int i = 0; i < intervals.Length; i++)
        {
            string[] stringarray = [];
            for (int j = 0; j < prio[0].Length; j++)
            {
                if (stringarray.Length == 4)
                {
                    break;
                }
                for (int k = 0; k < players.Length; k++)
                {
                    if (stringarray.Length == 4)
                    {
                        break;
                    }
                    if (players[k].Specname.Equals(prio[0][j]))
                    {
                        if (prio[1][j].Equals("y"))
                        {
                            if (players[k].Cduses.Contains(intervals[i]))
                            {
                                stringarray = stringarray.Append(players[k].Playername).ToArray();
                            }
                        }
                        else
                        {
                            stringarray = stringarray.Append(players[k].Playername).ToArray();
                        }
                    }
                }
            }
            dictionary.Add(intervals[i], stringarray);
        }
        return dictionary;
    }
    private static void CreateNote(Dictionary<int, string[]> bufflist, Player[] players)
    {
        using StreamWriter writer = new StreamWriter("out/Note.txt");
        writer.WriteLine("\"");
        writer.WriteLine("AugBuffStart");
        foreach (var pair in bufflist)
        {
            string line = "";
            int minutes = FindMinutes(pair.Key);
            int seconds = FindSeconds(pair.Key);
            string minutestring = "";
            string secondstring = "";
            line += "{time:";
            if (minutes < 10)
            {
                minutestring = "0";
            }
            line += minutestring + $"{minutes}:";
            if (seconds < 10)
            {
                secondstring = "0";
            }
            line += secondstring + $"{seconds}";
            line += "}" + $"{minutestring}{minutes}:{secondstring}{seconds} ";
            writer.WriteLine(line);
        }
    }
    private static void PrintRoster(Player[] roster)
    {
        foreach (Player player in roster)
        {
            Console.WriteLine($"player: {player.Playername} plays {player.Classname}, {player.Specname}");
            foreach (int i in player.Cduses)
            {
                Console.WriteLine($"cd : {i}");
            }
        }
    }
    private static void PrintBufflist(Dictionary<int, string[]> bufflist)
    {
        foreach (var pair in bufflist)
        {
            Console.Write($"interval {pair.Key}: {pair.Value[0]}, ");
            Console.Write($"{pair.Value[1]}, ");
            Console.Write($"{pair.Value[2]}, ");
            Console.WriteLine($"{pair.Value[3]}");
        }
    }
    private static int FindMinutes(int seconds)
    {
        return seconds / 60;
    }
    private static int FindSeconds(int seconds)
    {
        return seconds % 60;
    }
}
