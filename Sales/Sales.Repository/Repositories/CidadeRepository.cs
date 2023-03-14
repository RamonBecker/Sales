

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

        public int Atualizar(CidadeDTO model)
        {

            if (model.Id <= 0)
            {
                return 0;
            }


            var nomeDuplicado = DBContext.Cidades.Any(x => x.Ativo && x.Nome.ToUpper().Equals(model.Nome.ToUpper()) && x.Id != model.Id);

            if (nomeDuplicado)
            {
                return 0;
            }


            var entity = DBContext.Cidades.Find(model.Id);

            if (entity == null)
            {
                return 0;
            }



            entity.Nome = model.Nome;
            entity.Uf = model.Uf;
            entity.Ativo = model.Ativo;

            try
            {
                DBContext.Cidades.Update(entity);
                DBContext.SaveChanges();

                return entity.Id;

            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var entity = DBContext.Cidades.Find(id);

            if (entity == null)
            {
                return false;
            }

            try
            {
                DBContext.Cidades.Remove(entity);
                DBContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
            }

            return false;
        }
    }
}
