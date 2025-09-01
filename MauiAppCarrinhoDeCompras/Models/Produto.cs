using SQLite;

namespace MauiAppCarrinhoDeCompras.Models
{
    public class Produto
    {
        string _descricao;
        double _quantidade;
        double _preco;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao 
        { get => _descricao;
            set  
            {
                if(string.IsNullOrWhiteSpace(value)) // se o cliente não preencher a descrição, dispara uma exceção
                {
                    throw new Exception("Por favor, preencha a descrição");
                }
                _descricao = value;
            }
        }
        public double Quantidade 
        { get => _quantidade;
            set 
            {
                if(value == null || value <= 0)   // se o valor for nulo ou menor ou igual a zero, dispara uma exceção
                {
                    throw new Exception("A quantidade deve ser maior que zero!");
                }

                _quantidade = value;
            }
        }
        public double Preco 
        { get => _preco;
            set 
            {
                if(value == null || value <= 0)   // se o valor for nulo ou menor ou igual a zero, dispara uma exceção
                {
                    throw new Exception("O preço deve ser maior que zero!");
                }
                
                _preco = value;
            }
        }
        public double Total 
        {
            get => Quantidade * Preco;
        }
    }
}
