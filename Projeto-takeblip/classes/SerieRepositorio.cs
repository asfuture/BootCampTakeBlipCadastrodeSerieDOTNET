using System;
using System.Collections.Generic;
using projeto_takeblip;
using projeto_takeblip.interfaces;

namespace Projeto_takeblip
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();  
         }
        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }
        public List<Serie> Lista()
        {
            return listaSerie;
        }
        public int ProxmoId()
        {
            return listaSerie.Count;
        }
        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}