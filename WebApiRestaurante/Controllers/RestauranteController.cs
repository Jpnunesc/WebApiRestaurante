using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiRestaurante.Content;
using WebApiRestaurante.Models;
using WebApiRestaurante.Repositorio;

namespace WebApiRestaurante.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RestauranteController : ApiController
    {
        private RestauranteRepository restauranteRepository;

        public RestauranteRepository RestauranteRepository
        {
            get
            {
                if (restauranteRepository == null)
                    restauranteRepository = new RestauranteRepository();
                return restauranteRepository;

            }
            set { restauranteRepository = value; }
        }

        //GET
        public List<Restaurante> Get()
        {
            List<Restaurante> lista = new List<Restaurante>();
            lista = RestauranteRepository.Consulta();
            return lista;

        }
        private RestaurantContext db = new RestaurantContext();
        //GET
        public Restaurante Get(int id, Restaurante entity)
        {
            entity = new Restaurante();
            entity = RestauranteRepository.ConsultaPorId(id);
            return entity;
        }

        //PUT
        public void Put([FromBody] Restaurante entity)
        {
            if (entity.RestauranteID > 0)
            {
                RestauranteRepository.Salvar(entity);
            }
        }


        //POST
        public void Post([FromBody] Restaurante entity)
        {
            if (!string.IsNullOrEmpty(entity.NomeRestaurante))
            {
                RestauranteRepository.Salvar(entity);
            }
        }

        //DELETE
        public void Delete(int id, Restaurante entity)
        {
            if (id > 0)
            {
                entity = RestauranteRepository.ConsultaPorId(id);
                RestauranteRepository.Excluir(entity);
            }
        }

    }
}
