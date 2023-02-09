

namespace Sales.Repository
{
    public class BaseRepository 
    {

        protected const int TamanhoPagina = 5;

        protected readonly ApplicationDBContext DBContext;
        public BaseRepository(ApplicationDBContext dBContext)
        {
            DBContext = dBContext;
        }
    }
}
