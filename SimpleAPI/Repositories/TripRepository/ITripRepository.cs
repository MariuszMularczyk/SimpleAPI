namespace SimpleAPI
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<List<TripList>> GetAll();
        Task<List<TripList>> GetTripsByCountry(CountriesEnum country);
    }
}
