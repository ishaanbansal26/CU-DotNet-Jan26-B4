namespace TrackingService.Helpers
{
    public class TruckNumberGenerate
    {
        public static string Generate(int id)
        {
            return $"TR{id:D2}-{id:D4}";
        }
    }
}
