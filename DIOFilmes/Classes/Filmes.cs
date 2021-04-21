using System;
using System.Collections.Generic;
using System.Text;

namespace DIOFilmes
{
    public class Filmes : EntidadeBase
    {

        private Genero Genero { get; set; }
        
        private String Título { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private string Trilogia { get; set; }

        private bool Excluido { get; set; }

        public Filmes(int id, Genero genero, string titulo, string descricao, int ano, string trilogia)
        {

            this.Id = id;
            this.Genero = genero;
            this.Título = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Trilogia = trilogia;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Título + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Pertence a Uma Trilogia? " + this.Trilogia + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Título;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }
 
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
