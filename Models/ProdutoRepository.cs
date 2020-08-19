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
            comando.Parameters.AddWithValue("@Fabricante", novoProduto.Fabricante;
            comando.Parameters.AddWithValue("@Preco", novoProduto.Preco);
            comando.Parameters.AddWithValue("@DataCadastro", novoProduto.DataCadastro);
            comando.Parameters.AddWithValue("@Disponivel", novoProduto.Disponivel);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}