namespace TrackingService.Dtos
{
    public class CreateTrackDto
    {
        public string Model { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public int Distance { get; set; }
    }
}
