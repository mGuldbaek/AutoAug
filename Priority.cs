class Priority
{
    public string[][] priority = [[], []];
    public Priority()
    {
        try
        {
            StreamReader reader = new StreamReader("txtfiles/priority.txt");
            string line = reader.ReadLine()!;
            string[] prio1 = [];
            string[] prio2 = [];
            while (line != null)
            {
                string[] temp = line.Split(",");
                prio1 = prio1.Append(temp[0]).ToArray();
                prio2 = prio2.Append(temp[1]).ToArray();
                line = reader.ReadLine()!;
            }
            priority = [prio1, prio2];
            for (int i = 0; i < prio1.Length; i++)
            {
                Console.WriteLine($"{priority[0][i]}, {priority[1][i]}");
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}
