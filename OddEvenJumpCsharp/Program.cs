/* Problem:

https://leetcode.com/problems/odd-even-jump/

You are given an integer array arr. From some starting index, you can make a series of jumps. The (1st, 3rd, 5th, ...) jumps in the series are called odd-numbered jumps,
and the (2nd, 4th, 6th, ...) jumps in the series are called even-numbered jumps. Note that the jumps are numbered, not the indices.

You may jump forward from index i to index j (with i < j) in the following way:

 - During odd-numbered jumps (i.e., jumps 1, 3, 5, ...), you jump to the index j such that arr[i] <= arr[j] and arr[j] is the smallest possible value.
   If there are multiple such indices j, you can only jump to the smallest such index j.

 - During even-numbered jumps (i.e., jumps 2, 4, 6, ...), you jump to the index j such that arr[i] >= arr[j] and arr[j] is the largest possible value.
   If there are multiple such indices j, you can only jump to the smallest such index j.

A starting index is good if, starting from that index, you can reach the end of the array (index arr.length - 1) by jumping some number of times (possibly 0 or more than once).
Return the number of good starting indices.

Array with nums for tests you can find at arr.txt

*/

using System.Text;

namespace OddEvenJumpCsharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter nums separated by ','");

            Stream stream = Console.OpenStandardInput();
            byte[] buffer = new byte[200000000];
            stream.Read(buffer, 0, buffer.Length);

            string str = Encoding.UTF8.GetString(buffer);
            if (str != null)
            {
                Solution solution = new();
                var watch = new System.Diagnostics.Stopwatch();

                string[] strArr = str.Trim(new char[] { ' ', '\n' }).Split(", ");
                int[] arr = strArr.Select(strNum => int.Parse(strNum)).ToArray();


                watch.Start();
                int jumps = solution.OddEvenJumps(arr);
                watch.Stop();

                // must be 1420
                Console.WriteLine(string.Format("Jumps count = {0}", jumps));
                Console.WriteLine(string.Format("Time = {0}\n", watch.ElapsedMilliseconds));
            }
        }
    }
}