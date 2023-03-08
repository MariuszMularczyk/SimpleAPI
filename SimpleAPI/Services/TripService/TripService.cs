namespace SimpleAPI
{
    public class TripService : ITripService
    {

        public ITripRepository TripRepository { get; set; }
        public IMailRepository MailRepository { get; set; }


        public TripService(ITripRepository tripRepository, IMailRepository mailRepository)
        {
            TripRepository = tripRepository;
            MailRepository = mailRepository;
        }

        public async Task<List<TripList>> AddTrip(Trip trip)
        {
            if(TripRepository.Any(x => x.Name == trip.Name))
                throw new AppException("NameDuplicated");
            TripRepository.Add(trip);
            await TripRepository.SaveAsync();
            return await TripRepository.GetAll();
        }

        public async Task<List<TripList>> GetAllTrips()
        {
            return await TripRepository.GetAll();
        }

        public async Task<List<TripList>> GetTripsByCountry(CountriesEnum country)
        {
            return await TripRepository.GetTripsByCountry(country);
        }

        public async Task<Trip?> GetTrip(int id) {

            Trip trip = await  TripRepository.GetSingleAsync(x => x.Id == id);
            if (trip == null)
                return null;
            return trip;
        }

        public async Task<List<TripList>?> UpdateTrip(Trip request)
        {
            if (await TripRepository.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
                throw new AppException("NameDuplicated");
            Trip trip = await TripRepository.GetSingleAsync(x => x.Id == request.Id);
            if (trip is null)
                return null;

            trip.Name = request.Name;
            trip.Description = request.Description;
            trip.Country = request.Country;
            trip.StartDate = request.StartDate;
            trip.NumberOfSeats = request.NumberOfSeats;

            TripRepository.Edit(trip);
            await TripRepository.SaveAsync();

            return await TripRepository.GetAll();
        }

        public async Task<List<TripList>?> DeleteTrip(int id)
        {
            Trip trip = await TripRepository.GetSingleAsync(x => x.Id == id);
            if (trip is null)
                return null;

            TripRepository.Delete(trip);
            await TripRepository.SaveAsync();

            return await TripRepository.GetAll();
        }

        public async void TripRegister(TripMailVM model)
        {
            Trip trip = await TripRepository.GetSingleAsync(x => x.Id == model.TripId);
            if (trip == null)
            {
                throw new TripNotFoundException("Trip Not Found");
            }
            if (trip.Mails.Any(x => x.EMail == model.Mail.ToLower()))
            {
                throw new AppException("Alredy Registered");
            }

            MailRepository.Add(new Mail() { EMail = model.Mail.ToLower(), Trip = trip });
            await MailRepository.SaveAsync();
        }
        public async void TripUnregister(TripMailVM model)
        {
            Trip trip = await TripRepository.GetSingleAsync(x => x.Id == model.TripId);
            if (trip == null)
            {
                throw new TripNotFoundException("Trip Not Found");
            }
            Mail? mail = trip.Mails.Where(x => x.EMail == model.Mail.ToLower()).FirstOrDefault();
            if (mail == null)
            {
                throw new AppException("Alredy Registered");
            }

            MailRepository.Delete(mail);
            await MailRepository.SaveAsync();
        }


    }
}
