namespace HotelListing_API.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public string CountryShortName { get; set; }

        //including a list of hotels in a specific countries

        public virtual IList<Hotel> Hotels { get; set; }
    }
}
