using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTeste.Models
{
    public class DadosRepositorio : IDadosRepositorio
    {
        private List<Dados> dados = new List<Dados>();
        private int _nextId = 1;

        public DadosRepositorio()
        {
            Add(new Dados { Nome = "Fabrício", Idade = 31, Sexo = "Masculino" });
            Add(new Dados { Nome = "Andressa", Idade = 28, Sexo = "Feminino" });
            Add(new Dados { Nome = "Carlos", Idade = 42, Sexo = "Masculino" });
            Add(new Dados { Nome = "Antônio", Idade = 20, Sexo = "Masculino" });
            Add(new Dados { Nome = "Carmem", Idade = 36, Sexo = "Feminino" });
            Add(new Dados { Nome = "Fabio", Idade = 15, Sexo = "Masculino" });
            Add(new Dados { Nome = "Cintia", Idade = 25, Sexo = "Feminino" });
        }

        public Dados Add(Dados item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            dados.Add(item);
            return item;
        }

        public Dados Get(int id)
        {
            return dados.Find(p => p.Id == id);
        }

        public IEnumerable<Dados> GetAll()
        {
            return dados;
        }

        public void Remove(int id)
        {
            dados.RemoveAll(p => p.Id == id);
        }

        public bool Update(Dados item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = dados.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }

            dados.RemoveAt(index);
            dados.Add(item);
            return true;
        }
    }
}