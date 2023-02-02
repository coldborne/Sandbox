namespace SumForPay
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int testCasesAmount = ReadInt();

            List<int[]> purchases = new List<int[]>();

            for (int i = 0; i < testCasesAmount; i++)
            {
                int itemsAmount = ReadInt();

                int[] items = ReadPurchase(itemsAmount);
                
                purchases.Add(items);
            }

            foreach (int[] purchase in purchases)
            {
                Console.WriteLine(FindFinalSum(purchase));
            }
        }

        private static int ReadInt()
        {
            bool isNumber = false;
            int number = 0;

            while (isNumber == false)
            {
                isNumber = int.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }

        private static int[] ReadPurchase(int itemsAmount)
        {
            List<int> purchase = new List<int>(itemsAmount);

            bool isPurchaseRight = false;

            while (isPurchaseRight == false)
            {
                string[] userPurchase = Console.ReadLine().Split(' ');

                foreach (string eachItem in userPurchase)
                {
                    bool isNumber = int.TryParse(eachItem, out int item);

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

        private static int FindFinalSum(int[] items)
        {
            Dictionary<int, int> itemsAmount = new Dictionary<int, int>();
            int finalSum = 0;

            foreach (int item in items)
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

            foreach (KeyValuePair<int,int> keyValuePair in itemsAmount)
            {
                const int freeProductNumber = 3;
                
                int price = keyValuePair.Key;
                int itemsCount = keyValuePair.Value;
                int freeItemsAmount = itemsCount / freeProductNumber;
                
                finalSum += (itemsCount - freeItemsAmount) * price;
            }

            return finalSum;
        }
    }
}