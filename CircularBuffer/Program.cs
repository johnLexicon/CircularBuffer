using System;

namespace CircularBuffer
{
    class MainClass
    {

        public static string AskForString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static int AskForInt(string prompt)
        {
            string answer = AskForString(prompt);
            if(int.TryParse(answer, out int value))
            {
                return value;
            }
            else
            {
                throw new FormatException("Value not an integer!!!");
            }
        }

        public static void AddValue(CircularBuffer buffer)
        {
            try
            {
                int value = AskForInt("Write value to add to the buffer: ");
                buffer.AddValue(value);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RetrieveValue(CircularBuffer buffer)
        {
            try
            {
                int value = buffer.RetrieveValue();
                Console.WriteLine("Value retrieved: {0}", value);
            }
            catch (Exception)
            {
                Console.WriteLine("No value available in buffer.");
            }
        }

        public static void Main(string[] args)
        {

            string menuOption = string.Empty;
            CircularBuffer buffer = new CircularBuffer(3);

            do
            {
                menuOption = AskForString("0.Quit\n1.Add value\n2.Retrieve value\n");
                switch (menuOption)
                {
                    case "0":
                        break;
                    case "1":
                        AddValue(buffer);
                        break;
                    case "2":
                        RetrieveValue(buffer);
                        break;
                    default:
                        Console.WriteLine("Not an available option");
                        break;
                }
            } while (menuOption != "0");

            Console.WriteLine("Program ends!");
        }
    }
}
