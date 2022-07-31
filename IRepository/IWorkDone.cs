using HotelListing_API.Data;

namespace HotelListing_API.IRepository
{
    public interface IWorkDone: IDisposable
    {

        IGenericRepository<Country> countryRepository { get; }

        IGenericRepository<Hotel> HotelRepository { get; }

        Task Save();
    }
}
