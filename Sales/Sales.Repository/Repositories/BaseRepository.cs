

namespace Sales.Repository
{
    public class BaseRepository 
    {
        protected readonly ApplicationDBContext _dBContext;
        public BaseRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
