using DIOFilmes.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIOFilmes
{
    public class FilmeRepositorio : IRepositorio<Filmes>
    {

        private List<Filmes> listaFilme = new List<Filmes>();
        public void Atualiza(int id, Filmes entidade)
        {
            listaFilme[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filmes entidade)
        {
            listaFilme.Add(entidade);
        }

        public List<Filmes> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filmes RetornaPorId(int id)
        {
            return listaFilme[id];
        }
     
    }  

}
