using System.Linq;
class RosterGenerator
{
    public Player[] GenerateRoster()
    {
        Player[] roster = { };
        try
        {
            StreamReader reader = new StreamReader("txtfiles/roster.txt");
            string line = reader.ReadLine()!;
            while (line != null)
            {
                string[] temp1 = line.Split(";");
                string[] temp2 = temp1[0].Split(",");
                string playername = temp2[0];
                string playerclass = temp2[1];
                string playerspec = temp2[2];
                int playercd = FindSpecCd(playerclass, playerspec);
                int[] interval = [];
                if (temp1.Length != 1)
                {
                    string[] temp3 = [];
                    for (int i = 1; i < temp1.Length; i++)
                    {
                        temp3 = temp3.Append(temp1[i]).ToArray();
                    }
                    int[] intarray1 = [];
                    int[] intarray2 = [];
                    foreach (string customcd in temp3)
                    {
                        string[] stringarray = customcd.Split(",");
                        intarray1 = intarray1.Append(int.Parse(stringarray[0])).ToArray();
                        intarray2 = intarray2.Append(int.Parse(stringarray[1])).ToArray();
                    }
                    int k = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        if (intarray1.Contains(i + 1))
                        {
                            interval = interval.Append(intarray2[k]).ToArray();
                            k += 1;
                        }
                        else
                        {
                            if (i == 0)
                            {
                                interval = interval.Append(0).ToArray();
                            }
                            else
                            {
                                interval = interval.Append(interval[i - 1] + playercd).ToArray();
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        interval = interval.Append(i * playercd).ToArray();
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
            case "frostmage":
                return 120;
            case "frostdk":
                return 120;
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
            case "windwalker":
                return 120;
        }
        return -1;
    }
}