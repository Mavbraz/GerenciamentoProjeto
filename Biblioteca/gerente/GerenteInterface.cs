using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.gerente
{
    public interface GerenteInterface
    {
        void Insert(Gerente gerente);
        void Update(Gerente gerente);
        void Delete(Gerente gerente);
        bool VerificaDuplicidade(Gerente gerente);
        List<Gerente> Select(Gerente filtro);

    }
}
