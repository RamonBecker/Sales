

using Microsoft.EntityFrameworkCore;
using Sales.Domain;
using Sales.Interface;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sales.Repository
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }


        public dynamic Get()
        {
            return DBContext.Cidades
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Uf,
                    x.Ativo
                }).ToList();
        }

        public int Criar(CidadeDTO model)
        {
            // Evitando duplicação de dados
            if (model.Id > 0)
            {
                return 0;
            }

            var nomeDuplicado = DBContext.Cidades.Any(x => x.Ativo && x.Nome.ToUpper().Equals(model.Nome.ToUpper()));


            if (nomeDuplicado)
            {
                return 0;
            }

            var entity = new Cidade()
            {
                Nome = model.Nome,
                Uf = model.Uf,
                Ativo = model.Ativo
            };


            try
            {
                DBContext.Cidades.Add(entity);
                DBContext.SaveChanges();
                return entity.Id;
            }
            catch (Exception e)
            {
            }

            return 0;
        }
    }
}
