using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTeste.Models
{
    public interface IDadosRepositorio
    {
        IEnumerable<Dados> GetAll();
        Dados Get(int id);
        Dados Add(Dados item);
        void Remove(int id);
        bool Update(Dados item);
    }
}
