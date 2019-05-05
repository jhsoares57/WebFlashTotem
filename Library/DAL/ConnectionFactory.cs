using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ConnectionFactory :  IDisposable//Adicione a interface IDisposable 
    {
        //Declarando o Variável com o nome da Chave contida no WebConfig.
        static string conectionName = "ConexaoHugo";

        private SqlConnection conexao;
        private SqlCommand comando;

        //Atributo do tipo SQL Transaction
        public SqlTransaction transacao;

        //Variável de verificação para a transação
        bool transacaoAberta = false;

        public SqlCommand Comando { get => comando; set => comando = value; }
        public SqlConnection Conexao { get => conexao; set => conexao = value; }

        public ConnectionFactory()
        {
            //Variável armazenará o caminho do Banco no WebConfig 
            //de acordo com a Chave passada na variável conectionName       
            string strConn = ConfigurationManager.ConnectionStrings[conectionName].ConnectionString;

            //Instancia um Objeto de Conexão.
            Conexao = new SqlConnection(strConn);
        }

        /// <summary>
        /// Abre uma conexão com o banco de dados.
        /// </summary>      
        public void AbrirConexao()
        {
            if (Conexao.State != ConnectionState.Closed)
                Conexao.Close();

            Conexao.Open();
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// A conexão não será fechada caso haja uma transação em aberto.
        /// </summary>
        public void FecharConexao()
        {
            if (transacaoAberta)
                return;

            if (Conexao.State != ConnectionState.Closed)
                this.Conexao.Close();
        }

        /// <summary>
        /// Inicia uma transação com o banco de dados.
        /// Utiliza o nível de isolação mais alto (Serializable).
        /// </summary>
        public void IniciarTransacao()
        {
            transacao = Conexao.BeginTransaction(IsolationLevel.Serializable);
            transacaoAberta = true;
        }

        /// <summary>
        /// Executa um comando sql e retorna a quantidade de linhas afetadas.
        /// </summary>        
        /// <returns>int</returns>
        public int ExecNonQuery()
        {
            int retorno = 0;
            Comando.Connection = Conexao;

            if (transacaoAberta)
                Comando.Transaction = transacao;

            retorno = Comando.ExecuteNonQuery();

            return retorno;
        }

        /// <summary> 
        /// Executa um comando sql e retorna a primeira coluna da primeira linha do resultado.
        /// </summary>
        /// <param name="sql">Comando sql a ser executado.</param>
        /// <returns>object</returns>
        public object ExecScalar()
        {
            Comando.Connection = Conexao;

            if (transacaoAberta)
                Comando.Transaction = transacao;

            object o = Comando.ExecuteScalar();

            return o;
        }


        /// <summary>
        /// Inicia uma transação com o banco de dados.
        /// </summary>
        /// <param name="iso">Nível de isolamento a ser utilizado.</param>
        public void IniciarTransacao(IsolationLevel iso)
        {
            transacao = Conexao.BeginTransaction(iso);
            transacaoAberta = true;
        }

        /// <summary>
        /// Método para fechar uma transação
        /// </summary>
        private void FecharTransacao()
        {
            if (transacaoAberta)
                transacaoAberta = false;
        }


        /// <summary>
        /// Confirma as operações executadas no banco de dados.
        /// </summary>
        public void ConfirmarTransacao()
        {
            transacao.Commit();
            FecharTransacao();
        }
        
        /// <summary>
        /// Desfaz todas as operações executadas no banco de dados.
        /// </summary>
        public void DesfazerTransacao()
        {
            transacao.Rollback();
            FecharTransacao();
        }

        /// <summary>
        /// Destrutor. Instrução para remoção do objeto Connection Factory        
        /// </summary>
        ~ConnectionFactory()
        {
            try
            {
                if (Conexao != null && Conexao.State != ConnectionState.Closed)
                    Conexao.Close();
            }
            catch { }
        }

        /// <summary>
        /// Instrução para Remoção da conexão após muito tempo instanciada, mas inativa.
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (Conexao != null && Conexao.State != ConnectionState.Closed)
                    Conexao.Close();
            }
            catch { }
        }

        public bool TestarConexao()
        {
            bool conectado = false;

            try
            {
                Conexao.Open();
                if (Conexao.State == ConnectionState.Open)
                {
                    conectado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
            return conectado;
        }
               
    }
}
