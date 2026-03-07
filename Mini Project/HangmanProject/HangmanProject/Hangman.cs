namespace HangmanProject
{
    internal class Hangman
    {
        static void Main(string[] args)
        {
            List<string> l1 = new List<string>();
            l1.Add("HELLO");
            l1.Add("WHATSAPP");
            l1.Add("FACEBOOK");
            l1.Add("INSTAGRAM");

            Random r = new Random();
            int index = r.Next(0, l1.Count);

            char[] word = new char[l1[index].Length];
            for (int i = 0; i < l1[index].Length; i++)
            {
                word[i] = '_';
            }

            int lives = 6;
            List<char> guessed = new List<char>();

            while (lives > 0)
            {
                Console.Write("WORD :");
                Console.Write(string.Join(" ", word));
                Console.WriteLine();

                Console.WriteLine("Lives Left :" + lives);

                Console.Write("Guessed :");
                Console.Write(string.Join(",", guessed));
                Console.WriteLine();

                Console.Write("Guess a Letter :");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;

                char c = char.ToUpper(input[0]);

                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Enter a valid character");
                    continue;
                }

                if (guessed.Contains(c))
                {
                    Console.WriteLine("You have already guessed the character : " + c);
                    continue;
                }
                else
                {
                    guessed.Add(c);
                }

                if (!l1[index].Contains(c))
                {
                    lives--;
                }

                for (int i = 0; i < l1[index].Length; i++)
                {
                    if (l1[index][i] == c)
                    {
                        word[i] = c;
                    }
                }

                if (new string(word).Equals(l1[index]))
                {
                    Console.WriteLine("Game Completed.");
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
