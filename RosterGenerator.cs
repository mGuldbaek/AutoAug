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
        return specname switch
        {
            "unholy" => 180,
            "frostmage" => 120,
            "frostdk" => 120,
            "havoc" => 120,
            "shadow" => 120,
            "fire" => 0,
            "arcane" => 90,
            "sub" => 60,
            "ass" => 120,
            "outlaw" => 0,
            "ret" => 60,
            "enhance" => 0,
            "bm" => 0,
            "mm" => 120,
            "dev" => 120,
            "aff" => 120,
            "demo" => 120,
            "destro" => 180,
            "ww" => 120,
            "fury" => 90,
            "arms" => 120,
            "feral" => 120,
            "boomie" => 180,
            "windwalker" => 120,
            _ => -1,
        };
    }
}
