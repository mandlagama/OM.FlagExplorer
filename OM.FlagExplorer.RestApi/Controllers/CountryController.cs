using Microsoft.AspNetCore.Mvc;
using OM.FlagExplorer.Services.Api;
using OM.FlagExplorer.Services.Api.Entities;

namespace OM.FlagExplorer.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;
        public CountryController(ILogger<CountryController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [HttpGet]
        [Route("~/api/countries/{name}")]
        public CountryDetails Get(string name)
        {
            return _countryService.GetCountry(name);
        }

        [HttpGet]
        [Route("~/api/countries")]
        public List<CountryDetails> Get()
        {
            return _countryService.GetCountryDetails();
        }
    }
}
