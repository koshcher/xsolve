namespace OddEvenJumpCsharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();

            Solution solution = new();

            watch.Start();
            int jumps = solution.OddEvenJumps(Test.Arr65);
            watch.Stop();

            // must be 1420
            Console.WriteLine(string.Format("Jumps count = {0}", jumps));
            Console.WriteLine(string.Format("Time = {0}\n", watch.ElapsedMilliseconds));
        }
    }
}