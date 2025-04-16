using OM.FlagExplorer.Services.Api.Entities;

namespace OM.FlagExplorer.Services.Api
{
    public interface ICountryService
    {
        CountryDetails GetCountry(string name);
        List<Country> GetCountries();
        List<CountryDetails> GetCountryDetails();
    }
}
