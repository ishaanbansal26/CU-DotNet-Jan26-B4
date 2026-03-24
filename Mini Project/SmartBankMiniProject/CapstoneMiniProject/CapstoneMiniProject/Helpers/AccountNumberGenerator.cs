namespace CapstoneMiniProject.Helpers
{
    public class AccountNumberGenerator
    {
        public static string Generate(int id)
        {
            var year = DateTime.Now.Year;
            return $"SB-{year}-{id:D6}";
        }
    }
}
