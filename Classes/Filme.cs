using System;


namespace Cadastro_Series{
    public class Filme : EntidadeBase{
      private Genero Genero {get; set; }
      private string Titulo_Filme {get; set; }
      private string Descricao_Filme {get; set; }
      private int Ano_Filme {get; set; }
      private bool Excluido {get; set; }  
      
      public Filme(int id, Genero genero, string Titulo_Filme, string Descricao_Filme, int Ano_Filme ){
          this.Id = id;
          this.Genero  = genero;
          this.Titulo_Filme = Titulo_Filme;
          this.Descricao_Filme = Descricao_Filme;
          this.Ano_Filme = Ano_Filme;
          this.Excluido = false;

      } 
      public override string ToString(){
          string retorno = "";
          retorno += "Gênero do filme: " + this.Genero + Environment.NewLine;
          retorno += "Título do filme: " + this.Titulo_Filme + Environment.NewLine;
          retorno += "Descrição do filme: " + this.Descricao_Filme + Environment.NewLine;
          retorno += "Ano de Início do filme: " + this.Ano_Filme + Environment.NewLine;
          retorno += "Excluido" + this.Excluido;
          return retorno;
      }

      public string retornaTitulo(){
          return this.Titulo_Filme;
      }
      public int retornaId(){
          return this.Id;
      }
      public bool retornaExcluido(){
           return this.Excluido;
      }
      public void Excluir(){
          this.Excluido = true;
      }

    }
}