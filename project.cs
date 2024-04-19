using System.IO;
class Test
{
    public static void Main()
    {
        RosterGenerator gen = new RosterGenerator();
        Priority priogen = new Priority();
        string[][] prio = priogen.priority;
        Player[] roster = gen.GenerateRoster();
        foreach (int i in roster[0].Cduses)
        {
            Console.WriteLine($"cd : {i}");
        }

    }
    private Dictionary<int, string[]> FindSpec(Player[] players, string[][] prio, int[] intervals)
    {
        Dictionary<int, string[]> dictionary = new Dictionary<int, string[]>();
        for (int i = 0; i < intervals.Length; i++)
        {
            for (int j = 0; j < prio.Length; j++)
            {

            }
        }


        return dictionary;
    }
}