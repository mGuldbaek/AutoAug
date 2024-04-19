class Priority
{
    public string[][] priority;
    public Priority()
    {
        priority = new string[50][];
        try
        {
            StreamReader reader = new StreamReader("priority.txt");
            string line = reader.ReadLine()!;
            while (line != null)
            {
                string[] temp = line.Split(",");
                priority[0][0] = temp[0];
                priority[0][0] = temp[1];
                line = reader.ReadLine()!;
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}