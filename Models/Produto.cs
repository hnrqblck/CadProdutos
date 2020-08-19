using System;

namespace CadProdutos.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Fabricante {get; set;}
        public double Preco {get; set;}
        public DateTime DataCadastro {get; set;}
        public bool Disponivel {get; set;}
    }
}