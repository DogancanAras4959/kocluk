namespace koclukyonetim.Models
{
    public class CalendarModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public bool AllDay { get; set; }
        public string? Color { get; set; }
        public string? TextColor { get; set; }
        public string? Student { get; set; }
        public string? BookingCode { get; set; }
    }
}
