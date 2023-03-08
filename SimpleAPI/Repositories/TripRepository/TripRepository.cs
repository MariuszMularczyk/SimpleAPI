namespace SimpleAPI
{
    public class TripRepository : Repository<Trip, DatabaseContext>, ITripRepository
    {
        public TripRepository(DatabaseContext context) : base(context)
        { }

        public async Task<List<TripList>> GetAll()
        {
            return await Context.Trips.Select(x => new TripList()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                StartDate = x.StartDate,
                NumberOfSeats = x.NumberOfSeats,
            }).ToListAsync();
        }
        public async Task<List<TripList>> GetTripsByCountry(CountriesEnum country)
        {
            return await  Context.Trips.Where(x => x.Country == country).Select(x => new TripList()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                StartDate = x.StartDate,
                NumberOfSeats = x.NumberOfSeats,
            }).ToListAsync();
        }

    }
}
