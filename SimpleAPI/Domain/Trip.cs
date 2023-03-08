namespace SimpleAPI
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountriesEnum Country { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfSeats { get; set; }
        public virtual List<Mail> Mails { get; set; }
    }
}
