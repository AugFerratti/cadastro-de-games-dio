using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO.Games.Interfaces;

namespace DIO.Games
{
    public class GameRepositorio : IRepositorio<Game>
    {
        public void Atualiza(int id, Game entidade)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Game entidade)
        {
            throw new NotImplementedException();
        }

        public List<Game> Lista()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public Game RetornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
