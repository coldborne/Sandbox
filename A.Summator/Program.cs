namespace A.Summator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isNumber = false;
            int testCasesAmount = 0;

            while (isNumber == false)
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out testCasesAmount);
            }
            
            List<(int FirstNumber, int SecondNumber)> pairsOfNumbers = new List<(int FirstNumber, int SecondNumber)>();

            for (int i = 0; i < testCasesAmount; i++)
            {
                bool isNumberFirst = false;
                bool isNumberSecond = false;
                
                int firstNumber = 0;
                int secondNumber = 0;
                
                while (isNumberFirst == false || isNumberSecond == false)
                {
                    
                    string? userInput = Console.ReadLine();

                    if (userInput?.Split().Length != 2)
                    {
                        continue;
                    }

                    isNumberFirst = Int32.TryParse(userInput?.Split(" ")[0], out firstNumber);
                    isNumberSecond = Int32.TryParse(userInput?.Split(" ")[1], out secondNumber);
                }
                
                pairsOfNumbers.Add((firstNumber, secondNumber));
            }

            foreach ((int FirstNumber, int SecondNumber) pairOfNumbers in pairsOfNumbers)
            {
                Console.WriteLine(Sum(pairOfNumbers.FirstNumber, pairOfNumbers.SecondNumber));
            }
        }

        private static int Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}