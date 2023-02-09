

namespace Sales.Repository
{
    public class BaseRepository 
    {

        protected const int TamanhoPagina = 5;

        protected readonly ApplicationDBContext _dBContext;
        public BaseRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
