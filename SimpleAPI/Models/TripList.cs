namespace SimpleAPI
{
    public class TripList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountriesEnum Country { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
    }
}

