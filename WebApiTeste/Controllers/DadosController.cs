using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTeste.Models;

namespace WebApiTeste.Controllers
{
    public class DadosController : ApiController
    {
        static readonly IDadosRepositorio repositorio = new DadosRepositorio();

        public IEnumerable<Dados> GetAllDados()
        {
            return repositorio.GetAll();
        }

        public Dados GetDados(int id)
        {
            Dados item = repositorio.Get(id);
            if (item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Dados> GetDadosPorNome(string nome)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Nome, nome, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostDados(Dados item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Dados>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutDados(int id, Dados dados)
        {
            dados.Id = id;
            if (!repositorio.Update(dados))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteDados(int id)
        {
            Dados item = repositorio.Get(id);

            if (item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}
