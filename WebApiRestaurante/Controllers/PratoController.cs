using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiRestaurante.Models;
using WebApiRestaurante.Repositorio;

namespace WebApiRestaurante.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PratoController : ApiController
    {
        private PratoRepository pratoRepository;

        public PratoRepository PratoRepository
        {
            get
            {
                if (pratoRepository == null)
                    pratoRepository = new PratoRepository();
                return pratoRepository;

            }
            set { PratoRepository = value; }
        }

        //GET
        public List<PratoDTO> Get()
        {
            List<PratoDTO> lista = PratoRepository.Consulta();
            return lista;

        }
        //GET
        public Prato Get(int id, Prato entity)
        {
            entity = new Prato();
            entity = PratoRepository.ConsultaPorId(id);
            return entity;
        }

        //PUT
        public void Put([FromBody] Prato entity)
        {
            if (entity.PratoID > 0)
            {
                PratoRepository.Salvar(entity);
            }
        }


        //POST
        public void Post([FromBody] Prato entity)
        { 
            if (entity != null)
            {
                PratoRepository.Salvar(entity);
            }
        }

        //DELETE
        public void Delete(int id, Prato entity)
        {
            if (id > 0)
            {
                entity = PratoRepository.ConsultaPorId(id);
                PratoRepository.Excluir(entity);
            }
        }

    }
}
