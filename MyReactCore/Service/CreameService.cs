using Dapper;
using MyReactCore.Abstract;
using MyReactCore.Model;
using System.Data.SqlClient;

namespace MyReactCore.Service
{
    public class CreameService : ICream
    {
        IConfiguration config;
        public CreameService(IConfiguration config)
        {
            this.config = config;
        }
        public IEnumerable<IceCream> GetIceCream()
        {
            using (var db = new SqlConnection(config["db"]))
            {
                return db.Query<IceCream>("pice_cream", commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
