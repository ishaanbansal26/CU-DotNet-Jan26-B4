namespace CapstoneMiniProject.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }

        public  string Name { get; set; }
        public decimal Balance { get; set; }
        public  DateTime CreatedAt { get; set; }
    }
}
