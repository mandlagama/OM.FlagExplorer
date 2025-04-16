using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OM.FlagExplorer.Services.Api.Entities;
using System.Data;

namespace OM.FlagExplorer.Data
{
    public interface ICountryDetailsReader
    {
        CountryDetails GetCountry(string name);
    }
    public class CountryDetailsReader : DataAccesBase, ICountryDetailsReader
    {
        public CountryDetailsReader() : base()
        {

        }
        public CountryDetails GetCountry(string name)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", name);
                dynamic country = connection.QuerySingle<CountryDetails>("spGetCountryByName", parameters, commandType: CommandType.StoredProcedure);
                return country;
            }
        }
    }
}
