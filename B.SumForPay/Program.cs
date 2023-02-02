namespace SumForPay
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ushort testCasesAmount = ReadNumber();

            List<int> finalSums = new List<int>(testCasesAmount);

            for (int i = 0; i < testCasesAmount; i++)
            {
                int itemsAmount = ReadNumber();

                finalSums.Add(FindFinalSum(ReadPurchase(itemsAmount)));
            }

            foreach (int finalSum in finalSums)
            {
                Console.WriteLine(finalSum);
            }
        }

        private static ushort ReadNumber()
        {
            bool isNumber = false;
            ushort number = 0;

            while (isNumber == false)
            {
                isNumber = ushort.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        private static ushort[] ReadPurchase(int itemsAmount)
        {
            List<ushort> purchase = new List<ushort>(itemsAmount);

            bool isPurchaseRight = false;

            while (isPurchaseRight == false)
            {
                string[] userPurchase = Console.ReadLine().Split(' ');

                if (userPurchase.Length != itemsAmount)
                {
                    continue;
                }

                foreach (string eachItem in userPurchase)
                {
                    bool isNumber = ushort.TryParse(eachItem, out ushort item);

                    if (isNumber == false)
                    {
                        purchase.Clear();
                        break;
                    }
                    
                    purchase.Add(item);
                }

                if (purchase.Count > 0)
                {
                    isPurchaseRight = true;
                }
            }

            return purchase.ToArray();
        }

        private static int FindFinalSum(ushort[] items)
        {
            Dictionary<ushort, int> itemsAmount = new Dictionary<ushort, int>();
            int finalSum = 0;

            foreach (ushort item in items)
            {
                if (itemsAmount.ContainsKey(item))
                {
                    itemsAmount[item] += 1;
                }
                else
                {
                    itemsAmount.Add(item, 1);
                }
            }

            foreach (KeyValuePair<ushort,int> keyValuePair in itemsAmount)
            {
                const int freeProductNumber = 3;
                
                ushort price = keyValuePair.Key;
                int itemsCount = keyValuePair.Value;
                int freeItemsAmount = itemsCount / freeProductNumber;
                
                finalSum += (itemsCount - freeItemsAmount) * price;
            }

            return finalSum;
        }
    }
}