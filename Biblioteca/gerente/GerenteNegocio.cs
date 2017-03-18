using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.gerente
{
    public class GerenteNegocio : GerenteInterface
    {
        private const string ERRO_NUMERO = "Número do gerente inválido.";
        private const string ERRO_NOME = "Nome do gerente inválido.";

        public void Insert(Gerente gerente)
        {
            if (gerente.Codigo < 0)
            {
                throw new Exception(ERRO_NUMERO);
            }

            if (gerente.Nome == null && gerente.Nome.Trim().Equals(""))
            {
                throw new Exception(ERRO_NOME);
            }

            new GerenteDados().Insert(gerente);
        }

        public void Update(Gerente gerente)
        {
            if (gerente.Codigo < 0)
            {
                throw new Exception(ERRO_NUMERO);
            }

            if (gerente.Nome == null && gerente.Nome.Trim().Equals(""))
            {
                throw new Exception(ERRO_NOME);
            }

            new GerenteDados().Update(gerente);
        }

        public void Delete(Gerente gerente)
        {
            if (gerente.Codigo < 0)
            {
                throw new Exception(ERRO_NUMERO);
            }

            new GerenteDados().Delete(gerente);
        }

        public bool VerificaDuplicidade(Gerente gerente)
        {
            if (gerente.Codigo < 0)
            {
                throw new Exception(ERRO_NUMERO);
            }

            return new GerenteDados().VerificaDuplicidade(gerente);
        }

        public List<Gerente> Select(Gerente filtro)
        {
            return new GerenteDados().Select(filtro);
        }
    }
}
