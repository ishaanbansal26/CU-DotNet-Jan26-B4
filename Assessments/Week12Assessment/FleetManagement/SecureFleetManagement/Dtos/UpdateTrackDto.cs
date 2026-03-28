namespace TrackingService.Dtos
{
    public class UpdateTrackDto
    {
        public string Model { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public int Distance { get; set; }
    }
}
