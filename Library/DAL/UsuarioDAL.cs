using Library.Model;
using Library.Model.Enuns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class UsuarioDAL
    {
        ConnectionFactory cf;

        public Usuario FindByLogin(string login, string senha)
        {
            Usuario u = null;

            //Connection Factory: Classe que gerencia o local da conexão, tendo o método responsável por obter a conexão
            cf = new ConnectionFactory();
            
            string query = "USP_TB_USUARIOS_SEL";
            cf.Comando = cf.Conexao.CreateCommand();
            
            //PRINCIPAL MUDANÇA
            //Linha abaixo indica que será executado por procedure
            //Ao invés de Command Text como no semestre passado
            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Comando.CommandText = query;

            cf.Comando.Parameters.AddWithValue("@LOGIN", login);
            cf.Comando.Parameters.AddWithValue("@SENHA", senha);

            cf.Conexao.Open();

            SqlDataReader reader = cf.Comando.ExecuteReader();

            if (reader.Read())//Indicado que achou um registro.
            {
                u = new Usuario();
                u.Id = Convert.ToInt32(reader["USUA_ID"]);
                u.Login = reader["USUA_DE_LOGIN"].ToString();
                u.Senha = reader["USUA_DE_SENHA"].ToString();                                
                //Conversão para o ENUM já que o atributo do objeto é do tipo PerfilEnum
                u.TipoUsuario = (PerfilEnum) Convert.ToInt32(reader["USUA_ID_PERFIL"]);
                u.UltimoAcesso = Convert.ToDateTime(reader["USUA_DT_ULTIMO_ACESSO"]);
            }
            cf.Conexao.Close();
            return u;
        }

        public void Insert(Usuario u)
        {
            cf = new ConnectionFactory();
            string query = "USP_TB_USUARIOS_INS";

            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.Parameters.AddWithValue("@DE_LOGIN", u.Login);
            cf.Comando.Parameters.AddWithValue("@DE_SENHA", u.Senha);
            cf.Comando.Parameters.AddWithValue("@ID_PERFIL", u.TipoUsuario);

            //Criação do parâmetro e indicação que é parâmetro de saída.
            cf.Comando.Parameters.AddWithValue("@ID_OUT", 0).Direction = ParameterDirection.Output;

            //Atribuindo o nome da procedure para o texto do comando.
            cf.Comando.CommandText = query;

            //CommandType indica que o comando será executado por procedure
            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Conexao.Open();

            cf.Comando.ExecuteNonQuery();//Execução do Comando no Banco de dados        
            object o = cf.Comando.Parameters["@ID_OUT"].Value;//Recuperando o ID salvo.
            cf.Conexao.Close();

            if (o != null)
                u.Id = Convert.ToInt32(o);
        }

        public DataTable FindAll()
        {
            cf = new ConnectionFactory();

            string query = "USP_TB_USUARIOS_OBTER_TODOS";

            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Comando.CommandText = query;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cf.Comando);

            cf.Conexao.Open();
            da.Fill(dt);
            cf.Conexao.Close();

            return dt;
        }

        public int Update(Usuario u)
        {
            cf = new ConnectionFactory();
            int linhasAfetadas = 0;

            //Para garantir que o comando estará correto, copie as linhas do quadro abaixo desta figura e cole abaixo.
            string query = "USP_TB_USUARIO_UPD";
                        
            cf.Comando = cf.Conexao.CreateCommand();
            //PARAMETROS 
            cf.Comando.Parameters.AddWithValue("@DE_LOGIN", u.Login);
            cf.Comando.Parameters.AddWithValue("@DE_SENHA", u.Senha);
            cf.Comando.Parameters.AddWithValue("@ID_PERFIL", u.TipoUsuario);
            cf.Comando.Parameters.AddWithValue("@ID", u.Id);//Necessário ID para saber qual registro será atualizado

            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Comando.CommandText = query.ToString();
            cf.Conexao.Open();
            //ExecuteNonQuery: Retorna o número de linhas afetadas no Banco de dados para a variável.
            linhasAfetadas = cf.Comando.ExecuteNonQuery();
            cf.Conexao.Close();

            //Este método retorna um número inteiro, conforme o que a assinatura pede.
            return linhasAfetadas;
        }

        public int Remove(int usuarioID)
        {
            cf = new ConnectionFactory();
            int linhasAfetadas = 0;
            string query = "USP_TB_USUARIOS_DEL";
                        
            cf.Comando = cf.Conexao.CreateCommand();
            //PARAMETROS 
            cf.Comando.Parameters.AddWithValue("@ID", usuarioID);
            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Comando.CommandText = query.ToString();

            cf.Conexao.Open();
            linhasAfetadas = cf.Comando.ExecuteNonQuery();
            cf.Conexao.Close();

            return linhasAfetadas;
        }




    }
}
