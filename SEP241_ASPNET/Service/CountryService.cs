using Dapper;
using SEP241_ASPNET.Abstract;
using SEP241_ASPNET.Models;
using System.Data.SqlClient;

namespace SEP241_ASPNET.Service
{
    public class CountryService : ICountry
    {
        IConfiguration config;
        public CountryService(IConfiguration config)
        {
            this.config = config;
        }
        public IEnumerable<Country> GetCountry()
        {
            using(SqlConnection db = new SqlConnection(config["db"]))
            {
                return db.Query<Country>("pcountry", commandType:System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
/*
 https://github.com/mbaibatyr/SEP241_ASPNET.git
 */