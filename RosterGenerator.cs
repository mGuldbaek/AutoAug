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
                string[] active = line.Split(":");
                if (active[0].Equals("0")) {
                    line = reader.ReadLine()!;
                    continue;
                }
                string[] temp1 = active[1].Split(";");
                string[] temp2 = temp1[0].Split(",");
                string playername = temp2[0];
                string playerclass = temp2[1];
                string playerspec = temp2[2];
                int playercd = FindSpecCd(playerspec);
                int[] interval = [];
                if (temp1.Length != 1)
                {
                    int[] intarray = [];
                    foreach (string customcd in temp1[1].Split(","))
                    {
                        intarray = intarray.Append(int.Parse(customcd)).ToArray();
                    }
                    int k = 0;
                    for(int i = 0; i < 10; i++) {
                        if (i == 0) {
                            if (k < intarray.Length && intarray[0] < playercd) {
                                interval = interval.Append(intarray[k]).ToArray();
                                k += 1;
                            } else {
                                interval = interval.Append(0).ToArray();
                            }
                        } else {
                            if (k < intarray.Length && intarray[k] < interval[i-1] + playercd * 2) {
                                interval = interval.Append(intarray[k]).ToArray();
                                k += 1;
                            } else {
                                interval = interval.Append(interval[i-1] + playercd).ToArray();
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
    private int FindSpecCd(string specname)
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
            "sub" => 90,
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
