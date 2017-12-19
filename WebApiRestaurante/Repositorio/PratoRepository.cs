using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApiRestaurante.Content;
using WebApiRestaurante.Models;

namespace WebApiRestaurante.Repositorio
{
    public class PratoRepository : BaseRepository
    {
        private RestaurantContext db = new RestaurantContext();


        public RestauranteRepository RestauranteRepository
        {
            get
            {
                if (RestauranteRepository == null)
                    RestauranteRepository = new RestauranteRepository();
                return RestauranteRepository;
            }
            set { RestauranteRepository = value; }
        }

        public Prato ConsultaPorId(int id)
        {

            return db.Pratos.FirstOrDefault(e => e.PratoID == id);

        }

        public List<Prato> Consultar()
        {
            return db.Pratos.ToList();
        }

        public List<Prato> GetByIdRestaurante(int id)
        {
            return db.Pratos.Where(x => x.RestauranteID == id).ToList();
        }

        public void Excluir(Prato entity)
        {
            db.Pratos.Remove(entity);
            db.SaveChanges();

        }
        public void Salvar(Prato entity)
        {

            db.Entry(entity).State = entity.PratoID == 0 ?
                EntityState.Added : EntityState.Modified;
            db.SaveChanges();

        }

        public List<Prato> ConsultarPorNome(string name)
        {
            return db.Pratos.Where(e => e.NomePrato == name).ToList();
        }


        private static readonly Expression<Func<Prato, PratoDTO>> AsPratoDTO =
            dto => new PratoDTO
            {
                PratoID = dto.PratoID,
                NomePrato = dto.NomePrato,
                PrecoPrato = dto.PrecoPrato,
                RestauranteID = dto.RestauranteID,
                NomeRestaurante = dto.Restaurante.NomeRestaurante
            };

        public PratoDTO ConsultarPorID(int id)
        {
            PratoDTO prato = db.Pratos.Include(pt => pt.Restaurante)
                    .Where(pt => pt.PratoID == id)
                    .Select(AsPratoDTO)
                    .FirstOrDefault();
            return prato;
        }

        public List<PratoDTO> Consulta()
        {
            return db.Pratos.Include(rt => rt.Restaurante).Select(AsPratoDTO).ToList();
        }
    }
}