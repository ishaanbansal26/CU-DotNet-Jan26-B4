namespace TrackingService.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string TruckNumber { get; set; }
        public string Model { get; set; }
        public int Distance { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
    }
}
