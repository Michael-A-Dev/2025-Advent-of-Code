namespace Advent_of_Code.Days
{
    public class Day2
    {
        public void Run()
        {
            string contents = File.ReadAllText(@"..\\..\\..\\Inputs\\Day 2.txt");
            string[] ranges = contents.Split(',', StringSplitOptions.RemoveEmptyEntries);

            RunPart1(ranges);
            RunPart2(ranges);
        }

        private void RunPart1(string[] ranges)
        {
            List<long> invalids = [];

            foreach (string range in ranges) 
            {
                long startNum = Int64.Parse(range.Split('-')[0]);
                long endNum = Int64.Parse(range.Split('-')[1]);

                List<long> newInvalids = [];

                for (long i = startNum; i <= endNum; i++)
                {
                    // If the number is an odd number of digits, it cannot be split in two, so skip it.
                    string iString = i.ToString();
                    if (iString.Length % 2 != 0) { continue; }

                    int mid = iString.Length / 2;

                    string a = iString[..mid];
                    string b = iString[mid..];

                    //Console.WriteLine("A: " + a);
                    //Console.WriteLine("B: " + b);

                    if (a.Equals(b)) { newInvalids.Add(i); }
                }

                foreach (long num in newInvalids)
                {
                    invalids.Add(num);
                }
            }

            long sumInvalids = 0;

            foreach (long num in invalids)
            {
                sumInvalids += num;
            }

            Console.WriteLine("Day 2 (Part 1): " + sumInvalids);
        }

        private void RunPart2(string[] ranges)
        {
            List<long> invalids = [];

            foreach (string range in ranges)
            {
                long startNum = Int64.Parse(range.Split('-')[0]);
                long endNum = Int64.Parse(range.Split('-')[1]);

                List<long> newInvalids = [];

                for (long i = startNum; i <= endNum; i++)
                {
                    string iString = i.ToString();

                    // Only checking for half number length and lower.
                    for (int j = (iString.Length / 2); j > 0; j--)
                    {
                        if (iString.Length % j != 0) continue;

                        IEnumerable<string> chunks = Enumerable.Range(0, iString.Length / j)
                                                .Select(s => iString.Substring(s * j, j));

                        int distinctChunks = chunks.Distinct().Count();

                        if (distinctChunks == 1)
                        {
                            newInvalids.Add(i);
                            break; // Stop doing any deeper checks, already invalid, move to next i
                        }
                    }

                }

                foreach (long num in newInvalids)
                {
                    invalids.Add(num);
                }
            }

            long sumInvalids = 0;

            foreach (long num in invalids)
            {
                sumInvalids += num;
            }

            Console.WriteLine("Day 2 (Part 2): " + sumInvalids);
        }
    }
}
