class Settings
{
    int[] intervals;
    public Settings()
    {
        try
        {
            StreamReader reader = new StreamReader("settings.txt");
            string line = reader.ReadLine()!;
            int i = 0;
            if (line == null)
            {
                for (; i < 20; i++)
                {
                    intervals[i] = i * 30;
                }
            }
            while (line != null)
            {
                intervals[i] = int.Parse(line);
                i += 1;
                line = reader.ReadLine()!;
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("No settings found");
            for (int i = 0; i < 20; i++)
            {
                intervals[i] = i * 30;
            }
        }
    }
}