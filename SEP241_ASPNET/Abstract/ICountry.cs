using SEP241_ASPNET.Models;

namespace SEP241_ASPNET.Abstract
{
    public interface ICountry
    {
        IEnumerable<Country> GetCountry();
    }
}
