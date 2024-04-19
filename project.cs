using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
class Test
{
    public static void Main()
    {
        SortRoster();
        RosterGenerator gen = new RosterGenerator();
        Priority priogen = new Priority();
        Player[] roster = gen.GenerateRoster();
        Settings settings = new Settings();
        int[] intervals = settings.intervals;
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
        writer.WriteLine("aug |cff33937fDuckievoker|r");
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
            line += "}" + $"{minutestring}{minutes}:{secondstring}{seconds} |";
            line += FindClassColor(FindPlayerClass(players, pair.Value[0])) + pair.Value[0] + "|r !1 |";
            line += FindClassColor(FindPlayerClass(players, pair.Value[1])) + pair.Value[1] + "|r !2 |";
            line += FindClassColor(FindPlayerClass(players, pair.Value[2])) + pair.Value[2] + "|r !3 |";
            line += FindClassColor(FindPlayerClass(players, pair.Value[3])) + pair.Value[3] + "|r !4";
            writer.WriteLine(line);
        }
        writer.WriteLine("AugBuffEnd {v2.0}");
        writer.WriteLine("\"");
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
    private static string FindClassColor(string classname) {
        switch(classname) {
            case "warlock":
                return "cff8788ee";
            case "hunter":
                return "cffaad372";
            case "warrior":
                return "cffc69b6d";
            case "dk":
                return "cffc41e3a";
            case "dh":
                return "cffa330c9";
            case "priest":
                return "cfffefefe";
            case "druid":
                return "cffff7c0a";
            case "mage":
                return "cff3fc7eb";
            case "evoker":
                return "cff33937f";
            case "shaman":
                return "cff0070dd";
            case "rogue":
                return "cfffff468";
            case "paladin":
                return "cfff48cba";
            case "monk":
                return "cff00ff98";
        }
        throw new Exception("classcolor not found");
    }
    private static string FindPlayerClass(Player[] roster, string playername) {
        foreach(Player player in roster) {
            if (playername.Equals(player.Playername)) {
                return player.Classname;
            }
        }
        throw new Exception("Player not found in roster");
    }
    private static void SortRoster() {
        StreamReader reader = new StreamReader("txtfiles/roster.txt");
        string line = reader.ReadLine()!;
        string[] active = [];
        string[] bench = [];
        while (line != null)
        {
            string mod = line.Split(":")[0];
            string p = line.Split(":")[1];
            if (mod.Equals("0")) {
                bench = bench.Append($"{mod}:{p}").ToArray();
            } else {
                active = active.Append($"{mod}:{p}").ToArray();
            }
            line = reader.ReadLine()!;
        }
        reader.Close();
        using StreamWriter writer = new StreamWriter("txtfiles/roster.txt");
        foreach(string player in active) {
            writer.WriteLine(player);
        }
        foreach(string player in bench) {
            writer.WriteLine(player);
        }
        writer.Close();
    }
}
