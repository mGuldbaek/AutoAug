class Player
{
    public string Playername;
    public string Classname;
    public string Specname;
    public int Cd;
    int[] Cduses;
    public Player(string playername, string classname, string specname, int cd, int[] cduses)
    {
        Playername = playername;
        Classname = classname;
        Specname = specname;
        Cd = cd;
        Cduses = cduses;
    }
}