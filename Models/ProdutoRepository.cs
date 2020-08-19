using System.Collections.Generic;
using System.Data;
using MySqlConnector;

namespace CadProdutos.Models
{
    public class ProdutoRepository
    {
        string enderecoConexao = "Database=admprodutos;DataSource=localhost; User Id=root;";
        public void Insert(Produto novoProduto)
        {
            
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlInsert = "INSERT INTO produto (nome, fabricante, preco, dataCadastro, disponivel)"+
            "VALUES (@Nome, @Fabricante, @Preco, @DataCadastro, @Disponivel)";

            MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
            comando.Parameters.AddWithValue("@Nome", novoProduto.Nome);
            comando.Parameters.AddWithValue("@Fabricante", novoProduto.Fabricante);
            comando.Parameters.AddWithValue("@Preco", novoProduto.Preco);
            comando.Parameters.AddWithValue("@DataCadastro", novoProduto.DataCadastro);
            comando.Parameters.AddWithValue("@Disponivel", novoProduto.Disponivel);
            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<Produto> Query()
        {
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);

            conexao.Open();

            string sqlSelect = "SELECT * FROM produto";

            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader resultado = comandoQuery.ExecuteReader();
            
            List<Produto> lista = new List<Produto>();
            while (resultado.Read())
            {
                Produto produto = new Produto();
                produto.Id = resultado.GetInt32("id");

                if (!resultado.IsDBNull(resultado.GetOrdinal("Nome")))
                {
                    produto.Nome = resultado.GetString("Nome");
                }
                if (!resultado.IsDBNull(resultado.GetOrdinal("Fabricante")))
                {
                    produto.Fabricante = resultado.GetString("Fabricante");
                }
                if (!resultado.IsDBNull((int)resultado.GetDecimal("Preco")))
                {
                    produto.Preco = (double)resultado.GetDecimal("Preco");
                }
                if (!resultado.IsDBNull(resultado.GetOrdinal("DataCadastro"))) //Ver se funciona com GetOrdinal 
                {
                    produto.DataCadastro = resultado.GetDateTime("DataCadastro");
                }
                if (!resultado.IsDBNull(resultado.GetOrdinal("Disponivel"))) //Ver se funciona com GetOrdinal
                {
                    produto.Disponivel = resultado.GetBoolean("Disponivel");
                }

                lista.Add(produto);
            }
            
            conexao.Close();
            return lista;
        }
    }
}