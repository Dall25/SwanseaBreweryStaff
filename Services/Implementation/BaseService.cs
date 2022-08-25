using Data;

namespace Services.Implementation
{
    public class BaseService
    {
        protected readonly BreweryContext _breweryContext;

        public BaseService(BreweryContext breweryContext)
        {
            _breweryContext = breweryContext;

        }
    }
}
