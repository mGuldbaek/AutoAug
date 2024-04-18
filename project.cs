using System.IO;
class Test
{
    public static void Main()
    {
        RosterGenerator gen = new RosterGenerator();
        Player[] roster = gen.GenerateRoster();
        Console.WriteLine(roster[0].Playername);
        Console.WriteLine(roster[1].Playername);
    }
}