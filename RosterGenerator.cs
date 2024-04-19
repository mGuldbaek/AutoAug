using System.Linq;
class RosterGenerator
{
    public Player[] GenerateRoster()
    {
        Player[] roster = { };
        try
        {
            StreamReader reader = new StreamReader("roster.txt");
            string line = reader.ReadLine()!;
            while (line != null)
            {
                string[] temp1 = line.Split(";");
                string[] temp2 = temp1[0].Split(",");
                string playername = temp2[0];
                string playerclass = temp2[1];
                string playerspec = temp2[2];
                int playercd = FindSpecCd(playername, playerspec);
                string[] temp3;
                int[] interval = new int[20];
                if (temp1.Length != 1)
                {
                    temp3 = temp1[1].Split(",");
                    for (int i = 0; i < temp3.Length; i++)
                    {
                        interval[i] = int.Parse(temp3[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        interval[i] = i * playercd;
                    }
                }
                Player player = new Player(playername, playerclass, playerspec, playercd, interval);
                roster = roster.Append(player).ToArray();
                line = reader.ReadLine()!;
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
        return roster;
    }
    private int FindSpecCd(string classname, string specname)
    {
        switch (specname)
        {
            case "unholy":
                return 180;
            case "frost":
                if (classname.Equals("mage"))
                {
                    return 120;
                }
                else if (classname.Equals("dk"))
                {
                    return 120;
                }
                else
                {
                    return -1;
                }
            case "havoc":
                return 120;
            case "shadow":
                return 120;
            case "fire":
                return 0;
            case "arcane":
                return 90;
            case "sub":
                return 60;
            case "ass":
                return 120;
            case "outlaw":
                return 0;
            case "ret":
                return 60;
            case "enhance":
                return 0;
            case "bm":
                return 0;
            case "mm":
                return 120;
            case "dev":
                return 120;
            case "aff":
                return 120;
            case "demo":
                return 120;
            case "destro":
                return 180;
            case "ww":
                return 120;
            case "fury":
                return 90;
            case "arms":
                return 120;
            case "feral":
                return 120;
            case "boomie":
                return 180;
        }
        return -1;
    }
}