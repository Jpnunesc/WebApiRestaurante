using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiRestaurante.Content;
using WebApiRestaurante.Models;

namespace WebApiRestaurante.Repositorio
{
    public class RestauranteRepository : BaseRepository
    {
        private RestaurantContext db = new RestaurantContext();

        private PratoRepository PratosRepository;

        public PratoRepository PratoRepository
        {
            get
            {
                if (PratosRepository == null)
                    PratosRepository = new PratoRepository();
                return PratosRepository;
            }
            set { PratosRepository = value; }
        }

        public Restaurante ConsultaPorId(int id)
        {
            return db.Restaurantes.FirstOrDefault(e => e.RestauranteID == id);

        }

        public List<Restaurante> Consulta()
        {
            return db.Restaurantes.ToList();
        }

        public void Excluir(Restaurante entity)
        {
            List<Prato> pratos = PratoRepository.GetByIdRestaurante(entity.RestauranteID);

            foreach (Prato p in pratos)
            {
                PratoRepository.Excluir(p);
            }

            db.Restaurantes.Remove(entity);
            db.SaveChanges();
        }

        public void Salvar(Restaurante entity)
        {
            db.Entry(entity).State = entity.RestauranteID == 0 ?
            EntityState.Added : System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Restaurante> ConsultarPorNome(String nome)
        {
            return db.Restaurantes.Where(x => x.NomeRestaurante.Contains(nome)).OrderBy(x => x.NomeRestaurante).ToList();
        }
    }
}