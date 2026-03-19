

public class Program
{
    public static void Main(string[] args)
    {
        int readingsCount = Convert.ToInt32(Console.ReadLine()?.Trim());
        if (readingsCount == 0)
        {
            Console.WriteLine(string.Join("\n", SlidingWindow.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3)));
            return;
        }
        
        List<int> readings = new List<int>();

        for (int i = 0; i < readingsCount; i++)
        {
            int readingsItem = Convert.ToInt32(Console.ReadLine().Trim());
            readings.Add(readingsItem);
        }

        int windowSize = Convert.ToInt32(Console.ReadLine().Trim());

        var result = SlidingWindow.MaxSlidingWindow(readings.ToArray(), windowSize);

        Console.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));
    }
}