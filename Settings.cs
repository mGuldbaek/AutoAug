class Settings
{
    public int[] intervals = [];
    public Settings()
    {
        try
        {
            StreamReader reader = new StreamReader("txtfiles/settings.txt");
            string line = reader.ReadLine()!;
            while (line != null)
            {
                intervals = intervals.Append(int.Parse(line)).ToArray();
                line = reader.ReadLine()!;
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("No settings found");
        }
        finally
        {
            intervals = [];
            for (int i = 0; i < 20; i++)
            {
                intervals = intervals.Append(i * 30).ToArray();
            }
        }
    }
}
