using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OM.FlagExplorer.Services.Api.Entities;
using System.Data;

namespace OM.FlagExplorer.Data
{
    public interface ICountryReader
    {
        List<Country> GetCountries();
    }
    public class CountryReader : DataAccesBase, ICountryReader
    {
        public CountryReader() : base()
        {

        }
        public List<Country> GetCountries()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                dynamic countries = connection.Query<Country>("spGetCountries", commandType: CommandType.StoredProcedure);
                return countries;
            }
        }
    }
}
