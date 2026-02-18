namespace Day34
{
    class Person
    {
        public string Name { get; set; }

        public List<Person> friends = new List<Person>();
        public Person(string name)
        {
            Name = name;
        }

        //public void AddFriend(Person person)
        //{
        //    if(!friends.Contains(person))
        //    {
        //        friends.Add(person);
        //        person.friends.Add(this);
        //    }
        //}
    }

    class SocialNetwork
    {
        private List<Person> _registrations = new List<Person>();

        public void AddMember(Person person)
        {
            _registrations.Add(person);
        }

        public void AddFriend(Person friend1, Person friend2)
        {
            if (!(_registrations.Contains(friend1) && _registrations.Contains(friend2)))
            {
                Console.WriteLine($"Any of the friend {friend1.Name} {friend2.Name} are not on social platform");
            }
            else
            {
                if (!friend1.friends.Contains(friend2))
                {
                    friend1.friends.Add(friend2);
                    friend2.friends.Add(friend1);
                }
            }
        }
        public void ShowNetwork()
        {
            foreach (var item in _registrations)
            {
                Console.Write(item.Name + "->");
                List<string> fr = new List<string>();
                foreach (var v in item.friends)
                {
                    fr.Add(v.Name);
                }
                Console.WriteLine($"{string.Join(", ", fr)}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();
            Person A = new Person("Aman");
            Person B = new Person("Bhaskar");
            Person C = new Person("Chetan");
            Person D = new Person("Divakar");
            Person E = new Person("EENA");

            network.AddMember(A);
            network.AddMember(B);
            network.AddMember(C);
            network.AddMember(D);

            network.AddFriend(A, B);
            network.AddFriend(A, C);
            network.AddFriend(A, D);
            network.AddFriend(B, C);
            network.AddFriend(B, D);

            //A.AddFriend(B);
            //A.AddFriend(C);
            //A.AddFriend(D);
            //B.AddFriend(C);
            //D.AddFriend(C);

            network.ShowNetwork();
        }
    }
}
