using MauiAppCarrinhoDeCompras.Models;
using SQLite;

namespace MauiAppCarrinhoDeCompras.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _bancodedados;


        // <------------------- Construtor da classe ------------------->
        public SQLiteDataBaseHelper(string caminhoDB)
        {
            _bancodedados = new SQLiteAsyncConnection(caminhoDB);

            // Cria a tabela Produto, caso ela não exista
            _bancodedados.CreateTableAsync<Produto>().Wait();
        }



        // <------------------- Métodos CRUD ------------------->

        // Métodos são tarefas assíncronas, que permitem que a tarefas sejam executadas em segundo plano de nosso aplicativo, enquanto a nossa interface continua responsiva.

        public Task<int> Insert(Produto produto) // O insert utiliza int, pois o retorno é o Id do produto inserido
        {
            return _bancodedados.InsertAsync(produto);
        }

        public Task<List<Produto>> Update(Produto produto)
        {
            // Atualiza o produto com base no Id, utilizando o padrão de consulta SQL
            string sql = "UPDATE Produto SET Descricao = ?, Quantidade = ?, Preco = ? WHERE Id = ?";

            return _bancodedados.QueryAsync<Produto>(sql, produto.Descricao, produto.Quantidade, produto.Preco, produto.Id);
        }

        public Task<int> Delete(int id) // O delete também utiliza int, já que o retorno é a quantidade de linhas afetadas
        {
            return _bancodedados.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetAll()
        {
            return _bancodedados.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string data)
        {
            string sql = "SELECT * FROM Produto WHERE Descricao Like '%" + data + "%' ";

            return _bancodedados.QueryAsync<Produto>(sql);
        }
    }
}
