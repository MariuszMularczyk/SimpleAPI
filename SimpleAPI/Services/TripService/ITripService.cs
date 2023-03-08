
namespace SimpleAPI
{
    public interface ITripService
    {
        Task<List<TripList>> AddTrip(Trip trip);
        Task<List<TripList>> GetAllTrips();
        Task<List<TripList>> GetTripsByCountry(CountriesEnum country);
        Task<Trip?> GetTrip(int id);
        Task<List<TripList>?> UpdateTrip(Trip trip);
        Task<List<TripList>?> DeleteTrip(int id);
        void TripRegister(TripMailVM model);
        void TripUnregister(TripMailVM model);
    }
}