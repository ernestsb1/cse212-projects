using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // ---------------------------------------------------
        //  PLAN (Detailed enough for another person to implement)
        //
        //  We need an array that will hold 'length' number of elements.
        //  Each element will be a multiple of 'number'.
        //      Example: if number = 7 and length = 5
        //               the result = {7, 14, 21, 28, 35}
        //  The first element is number * 1,
        //    the second is number * 2,
        //    the third is number * 3,
        //    and so on until number * length.
        //  Steps in code:
        //    a. Create a new double[] with the given length.
        //    b. Use a for loop (i = 0 → length-1).
        //    c. For each position i, store number * (i + 1).
        //    d. Return the filled array.
        //
        // ---------------------------------------------------

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    ///   <param name="data">The list to rotate</param>
    /// <param name="amount">How many places to rotate to the right</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // ---------------------------------------------------
        //  PLAN (Detailed enough for another person to implement)
        //
        // GOAL: Move the last 'amount' elements to the front of the list in order.
        //
        // Example:
        //   data = {1,2,3,4,5,6,7,8,9}
        //   amount = 3
        //   After rotation → {7,8,9,1,2,3,4,5,6}
        // STEPS:
        //  If data is null or empty, do nothing.
        //  Let n = data.Count.
        //  Normalize amount to amount % n to support amount == n (rotation by full length = no-op).
        //  If amount == 0 after normalization, do nothing.
        //  Use GetRange(n - amount, amount) to copy the tail segment that should move to the front.
        //  RemoveRange(n - amount, amount) to remove that tail from the end.
        //  InsertRange(0, tail) to put the tail at the front.
        //  Return (the list is modified in place).
        //
        // ---------------------------------------------------

        if (data == null || data.Count == 0)
        {
            return; // nothing to do
        }

        int n = data.Count;

        // Normalize amount so that rotating by n does nothing.
        amount = amount % n; // in case amount >= n
        if (amount == 0)
        {
            return; // rotating by full length = same list
        }

        // take last 'amount' items
        List<int> tail = data.GetRange(n - amount, amount);

        // Remove the last 'amount' elements from the original list
        data.RemoveRange(n - amount, amount);

        // insert the saved tail at the beginning
        data.InsertRange(0, tail);
    }
}
