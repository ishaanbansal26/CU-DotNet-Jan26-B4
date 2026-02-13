
namespace Day30
{
    internal class Program
    {
        //static void diff(params int[] a)
        //{
        //    int max = a[0];
        //    int avg = 0;
        //    int sum = 0;
        //    for (int i = 1; i < a.Length; i++)
        //    {
        //        if (a[i] > max)
        //        {
        //            max = a[i];
        //        }
        //    }
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        sum += a[i];
        //    }
        //    avg = sum / a.Length;
        //    int val = Math.Abs(avg - max);
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (a[i] > avg)
        //        {

        //            Console.WriteLine($"{a[i]} should receive {a[i] - avg} from others ");
        //        }
        //        else if (a[i] < avg)

        //            Console.WriteLine($"{a[i]} should give {avg - a[i]} to {max} ");
        //    }

        //}

        static List<string> ExpenseShare(Dictionary<string, int> d)
        {
            var settlement = new List<string>();

            Queue<KeyValuePair<string, int>> receivers = new Queue<KeyValuePair<string, int>>();
            Queue<KeyValuePair<string, int>> payers = new Queue<KeyValuePair<string, int>>();

            var total = d.Values.Sum();
            var persons = d.Count();
            var avg = total / persons;
            foreach (var person in d)
            {
                if (person.Value > avg)
                {
                    receivers.Enqueue(new KeyValuePair<string, int>(person.Key, person.Value - avg));
                }
                else if (person.Value < avg)
                {
                    payers.Enqueue(new KeyValuePair<string, int>(person.Key, Math.Abs(person.Value - avg)));
                }
            }

            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();
                var amount = Math.Min(payer.Value, receiver.Value);

                settlement.Add($"{payer.Key} {receiver.Key} {amount}");
                if (payer.Value > amount)
                    payers.Enqueue(new KeyValuePair<string, int>(payer.Key, Math.Abs(amount - payer.Value)));
                if (receiver.Value > amount)
                    receivers.Enqueue(new KeyValuePair<string, int>(receiver.Key, Math.Abs(amount - receiver.Value)));
            }

            return settlement;
        }

        static void Main(string[] args)
        {
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());
            //int max = Math.Max(a, b);
            //int min = Math.Min(a, b);
            //int c = (max-min) / 2;

            //diff(700, 900, 2000);
            //Console.WriteLine();
            //diff(700, 900, 2000, 7000);
            //Console.WriteLine();
            //diff(700, 900, 2000, 5000, 7000);

            Dictionary<string, int> d = new Dictionary<string, int>()
            {
                {"A",700},
                {"B",900},
                {"C",2000},
                {"D",5000},
                {"E",7000}
            };
            List<string> settlement = ExpenseShare(d);

            foreach (var payment in settlement)
                Console.WriteLine(payment);

        }
    }
}

