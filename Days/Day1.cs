namespace Advent_of_Code.Days
{
    public class Day1
    {
        public void RunPart1()
        {
            try
            {
                string[] contents = File.ReadAllLines(@"..\\..\\..\\Inputs\\Day 1.txt");
                //Console.WriteLine("File contents:");
                //foreach (string line in contents)
                //{
                //    Console.WriteLine(line);
                //}

                int CIRCULAR_VALUE = 100; //The # of values of the dial.
                int STARTING_VALUE = 50; //The # the dial begins pointing at.

                int count = 0; //How many times 0 has been hit.
                int pos = STARTING_VALUE;

                foreach (string line in contents)
                { 
                    char direction = line[0];
                    int rotation = Int32.Parse(line[1..]);
                    rotation %= CIRCULAR_VALUE;

                    switch (direction)
                    {
                        case 'R':
                            pos += rotation;
                            if (pos >= CIRCULAR_VALUE)
                            {
                                pos %= CIRCULAR_VALUE;
                            }
                            break;
                        case 'L':
                            pos -= rotation;
                            if (pos < 0)
                            {
                                pos = CIRCULAR_VALUE - Math.Abs(pos);
                            }
                            break;
                        default:
                            //Something broke.
                            return;
                    }

                    if (pos == 0)
                    {
                        count++;
                    }
                }

                Console.WriteLine("Day 1 (Part 1): " + count);
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("Error: Access to the file is denied.");
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"I/O error while reading file: {ex.Message}");
            }
        }

        public void RunPart2()
        {
            try
            {
                string[] contents = File.ReadAllLines(@"..\\..\\..\\Inputs\\Day 1.txt");
                //Console.WriteLine("File contents:");
                //foreach (string line in contents)
                //{
                //    Console.WriteLine(line);
                //}

                int CIRCULAR_VALUE = 100; //The # of values of the dial.
                int STARTING_VALUE = 50; //The # the dial begins pointing at.

                int count = 0; //How many times 0 has been hit.
                int pos = STARTING_VALUE;

                foreach (string line in contents)
                {
                    int fullRotations = 0;
                    
                    char direction = line[0];
                    int rotation = Int32.Parse(line[1..]);

                    fullRotations = rotation / CIRCULAR_VALUE;
                    rotation %= CIRCULAR_VALUE;

                    switch (direction)
                    {
                        case 'R':
                            pos += rotation;
                            if (pos >= CIRCULAR_VALUE)
                            {
                                count++; //Passed over or ended on 0
                                pos %= CIRCULAR_VALUE;
                            }
                            break;
                        case 'L':
                            bool startedAtZero = pos == 0 ? true : false;
                            pos -= rotation;
                            if (pos <= 0 && !startedAtZero) { count++; } //Passed over or ended on 0
                            if (pos < 0)
                            {
                                pos = CIRCULAR_VALUE - Math.Abs(pos);
                            }
                            break;
                        default:
                            //Something broke.
                            return;
                    }

                    count += fullRotations; //Add the extra full rotations.
                }

                Console.WriteLine("Day 1 (Part 2): " + count);
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("Error: Access to the file is denied.");
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"I/O error while reading file: {ex.Message}");
            }
        }
    }
}
