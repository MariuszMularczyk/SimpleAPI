namespace SimpleAPI
{

    public class Mail 
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
