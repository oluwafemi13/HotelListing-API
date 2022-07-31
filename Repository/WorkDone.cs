using HotelListing_API.Data;
using HotelListing_API.IRepository;

namespace HotelListing_API.Repository
{
    public class WorkDone : IWorkDone
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Country> _countryRepository;

       private IGenericRepository<Hotel> _hotelRepository;


        public WorkDone(DatabaseContext context)
        {
            _context = context; 
        }

        public IGenericRepository<Country> countryRepository => _countryRepository ??= new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> HotelRepository => _hotelRepository ??= new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            //GC = garbage collector
            GC.SuppressFinalize(this);
        }

       
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
