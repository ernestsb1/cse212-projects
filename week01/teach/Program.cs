using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // Test Arrays.MultiplesOf and Arrays.RotateListRight
        double[] result = Arrays.MultiplesOf(7, 5);
        Console.WriteLine("MultiplesOf(7,5): " + string.Join(", ", result));

        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(list, 3);
        Console.WriteLine("RotateListRight(3): " + string.Join(", ", list));
    }
}
