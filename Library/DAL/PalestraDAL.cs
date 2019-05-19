using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class PalestraDAL
    {
        ConnectionFactory cf;

        public void Insert(Palestra p)
        {

            string query = "FL_PALESTRA_INS";
            //Connection Factory: Classe que gerencia o local da conexão, tendo o método responsável por obter a conexão
            cf = new ConnectionFactory();

            //CreateCommand: Inicializa o objeto SqlCommand associando o Comando com a conexão do Banco onde será executado
            cf.Comando = cf.Conexao.CreateCommand();

            //Abaixo os parametros que no momento da execução serão substituídos pelos valor das propriedades

            cf.Comando.Parameters.AddWithValue("@TITULO", p.Titulo);
            cf.Comando.Parameters.AddWithValue("@DESCRICAO", p.Descricao);
            cf.Comando.Parameters.AddWithValue("@PALESTRANTE", p.Palestrante);
            cf.Comando.Parameters.AddWithValue("@DATA_PALESTRA", p.Data);
            cf.Comando.Parameters.AddWithValue("@HORA_PALESTRA", p.Hora);
            cf.Comando.Parameters.AddWithValue("@ENDERECO_PALESTRA", p.LocalPalestra);


            cf.Comando.Parameters.AddWithValue("@ID_OUT", 0).Direction = ParameterDirection.Output;

            //CommandType indica que o Comando será via procedure no banco de dados
            cf.Comando.CommandType = CommandType.StoredProcedure;

            //CommandText: Propriedade do objeto command que receberá o texto do Comando a ser executado.
            cf.Comando.CommandText = query.ToString();

            //Abre a conexão 
            cf.Conexao.Open();
            p.Id = 0;//Define o ID inicialmente como 0.

            cf.Comando.ExecuteNonQuery();//Execução do Comando no Banco de dados        
            object o = cf.Comando.Parameters["@ID_OUT"].Value;//Recuperando o ID salvo (que deverá ser > 0).
            cf.Conexao.Close();

            if (o != null)
                p.Id = Convert.ToInt32(o);
        }

        //Inicio da lista que retorna as palestras para o grid da pagina de listarpalestra.aspx
        public List<Palestra> FindAll()
        {
            //Consulta select com inner join
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT ID_PALESTRA, TITULO, PALESTRANTE FROM TB_PALESTRA ");

            cf = new ConnectionFactory();
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query.ToString();

            //Cria uma lista, que armazenárá os resultados da consulta  
            List<Palestra> listaPessoas = new List<Palestra>();

            cf.Conexao.Open();//Abre a conexão
            SqlDataReader reader = cf.Comando.ExecuteReader();//Executando o comando

            while (reader.Read())
            {
                Palestra p = new Palestra();//Instanciando o objeto da iteração
                //Preenchimento das propriedades a partir do que retornou no banco.
                p.Id = Convert.ToInt32(reader["ID_PALESTRA"]);
                p.Titulo = reader["TITULO"].ToString();
                p.Palestrante = reader["PALESTRANTE"].ToString();
                
                listaPessoas.Add(p);//Adicionando o objeto para a lista
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista já carregada.
            return listaPessoas;
        }

        public List<Palestra> FindAllList()
        {
            //Consulta select com inner join
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT ID_PALESTRA, TITULO, DESCRICAO, PALESTRANTE,ENDERECO_PALESTRA, DATA_PALESTRA, HORA_PALESTRA FROM TB_PALESTRA WHERE DATA_PALESTRA >= GETDATE() ORDER BY DATA_PALESTRA DESC ");

            cf = new ConnectionFactory();
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query.ToString();

            //Cria uma lista, que armazenárá os resultados da consulta  
            List<Palestra> listaPalestras = new List<Palestra>();

            cf.Conexao.Open();//Abre a conexão
            SqlDataReader reader = cf.Comando.ExecuteReader();//Executando o comando

            while (reader.Read())
            {
                Palestra p = new Palestra();//Instanciando o objeto da iteração
                //Preenchimento das propriedades a partir do que retornou no banco.
                p.Id = Convert.ToInt32(reader["ID_PALESTRA"]);
                p.Titulo = reader["TITULO"].ToString();
                p.Descricao = reader["DESCRICAO"].ToString();
                p.Palestrante = reader["PALESTRANTE"].ToString();
                p.Data = Convert.ToDateTime(reader["DATA_PALESTRA"].ToString());
                p.Hora = reader["HORA_PALESTRA"].ToString();
                p.LocalPalestra = reader["ENDERECO_PALESTRA"].ToString();

                listaPalestras.Add(p);//Adicionando o objeto para a lista
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista já carregada.
            return listaPalestras;
        }

        //public Palestra FindByIdPalestra(int id)
        //{
        //    string query = "SELECT ID_PALESTRA, TITULO, DESCRICAO, PALESTRANTE, DATA_PALESTRA, HORA_PALESTRA FROM TB_PALESTRA WHERE ID_PALESTRA = @ID_PALESTRA";

        //    //Cria um objeto do tipo Pessoa
        //    Palestra c = new Palestra();

        //    cf = new ConnectionFactory();
        //    cf.Comando = cf.Conexao.CreateCommand();
        //    cf.Comando.Parameters.AddWithValue("@ID_PALESTRA", id);
        //    cf.Comando.CommandType = CommandType.Text;
        //    cf.Comando.CommandText = query;

        //    cf.Conexao.Open();
        //    //Objeto SqlDataReader: Armazena um buffer dos resultados da consulta
        //    SqlDataReader reader = cf.Comando.ExecuteReader();

        //    //Se o buffer conter linhas, entrará no IF parar ler os dados da pessoa
        //    //e carregar o objeto que será devolvido pelo Método
        //    if (reader.Read())
        //    {
        //        c.Id = Convert.ToInt32(reader["ID_PALESTRA"]);
        //        c.Titulo = reader["TITULO"].ToString();
        //        c.Titulo = reader["DESCRICAO"].ToString();
        //        c.Titulo = reader["PALESTRANTE"].ToString();
        //        c.Data = Convert.ToDateTime(reader["DATA_PALESTRA"]);
        //        c.Hora = Convert.ToDateTime(reader["HORA_PALESTRA"]);
        //    }
        //    cf.Conexao.Close();
        //    return c; //Retorna o objeto do tipo Pessoa
        //}

        public Palestra FindById(int id)
        {
            string query = "FL_PALESTRA_SEL";

            //Cria um objeto do tipo Contato
            Palestra c = new Palestra();

            cf = new ConnectionFactory();
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.Parameters.AddWithValue("@ID_PALESTRA", id);
            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Comando.CommandText = query;

            cf.Conexao.Open();
            //Objeto SqlDataReader: Armazena um buffer dos resultados da consulta
            SqlDataReader reader = cf.Comando.ExecuteReader();

            //Se o buffer conter linhas, entrará no IF parar ler os dados do contato
            //e carregar o objeto que será devolvido pelo Método
            if (reader.Read())
            {
                c.Id = Convert.ToInt32(reader["ID_PALESTRA"]);
                c.Titulo = reader["TITULO"].ToString();
                c.Descricao = reader["DESCRICAO"].ToString();
                c.Palestrante = reader["PALESTRANTE"].ToString();
                c.Data = Convert.ToDateTime(reader["DATA_PALESTRA"].ToString());
                c.Hora = reader["HORA_PALESTRA"].ToString();
                c.LocalPalestra = reader["ENDERECO_PALESTRA"].ToString();
            }
            cf.Conexao.Close();
            return c; //Retorna o objeto do tipo Pessoa
        }

        public int Delete(int id)
        {
            cf = new ConnectionFactory();
            StringBuilder query = new StringBuilder();
            int linhasAfetadas = 0;

            query.AppendLine("DELETE FROM TB_PALESTRA ");
            query.AppendLine("WHERE ID_PALESTRA = @ID_PALESTRA ");

            cf.Comando = cf.Conexao.CreateCommand();

            //Parametro que é passado é apenas o ID que será exclído do banco
            cf.Comando.Parameters.AddWithValue("@ID_PALESTRA", id);

            cf.Comando.CommandType = System.Data.CommandType.Text;
            cf.Comando.CommandText = query.ToString();
            cf.Conexao.Open();

            //ExecuteNonQuery retorna o número de linhas afetadas no Banco de dados.
            linhasAfetadas = cf.Comando.ExecuteNonQuery();
            cf.Conexao.Close();

            return linhasAfetadas;
        }


        //FAZER ATUALIZAÇÃO DA PALESTRA
        public int Update(Palestra c)
        {
            cf = new ConnectionFactory();
            string query = "USP_TB_PALESTRA_UPD";

            //Variável guardará a quantidade de linhas afetadas
            int linhasAfetadas = 0;

            //PARAMETROS 
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.Parameters.AddWithValue("@TITULO", c.Titulo);
            cf.Comando.Parameters.AddWithValue("@DESCRICAO", c.Descricao);
            cf.Comando.Parameters.AddWithValue("@PALESTRANTE", c.Palestrante);
            cf.Comando.Parameters.AddWithValue("@DATA_PALESTRA", c.Data);
            cf.Comando.Parameters.AddWithValue("@HORA_PALESTRA", c.Hora);
            cf.Comando.Parameters.AddWithValue("@ENDERECO_PALESTRA", c.LocalPalestra);
            cf.Comando.Parameters.AddWithValue("@ID_PALESTRA", c.Id);//Necessário ID para saber que registro será atualizado

            cf.Comando.CommandType = CommandType.StoredProcedure;
            cf.Comando.CommandText = query;
            cf.Conexao.Open();
            //ExecuteNonQuery: Retorna o número de linhas afetadas no Banco de dados para a variável.
            linhasAfetadas = cf.Comando.ExecuteNonQuery();
            cf.Conexao.Close();

            //Este método retorna um número inteiro, conforme o que a assinatura pede.
            return linhasAfetadas;
        }

        //Ainda não está sendo utilizado
        //public int UpdateOld(Palestra P)
        //{
        //    try
        //    {
        //        cf = new ConnectionFactory();
        //        StringBuilder query = new StringBuilder();

        //        int linhasAfetadas = 0;

        //        query.AppendLine(" UPDATE TB_PALESTRA SET ");
        //        query.AppendLine("TITULO = @TITULO,");
        //        query.AppendLine("DESCRICAO = @DESCRICAO,");
        //        query.AppendLine("PALESTRANTE = @PALESTRANTE,");
        //        query.AppendLine("DATA_PALESTRA = @DATA_PALESTRA,");
        //        query.AppendLine("HORA_PALESTRA = @HORA_PALESTRA");
        //        query.AppendLine("WHERE ID_PALESTRA = @ID_PALESTRA");

        //        cf.Comando = cf.Conexao.CreateCommand();

        //        cf.Comando.Parameters.AddWithValue("@TITULO", P.Titulo);
        //        cf.Comando.Parameters.AddWithValue("@DESCRICAO", P.Descricao);
        //        cf.Comando.Parameters.AddWithValue("@PALESTRANTE", P.Palestrante);
        //        cf.Comando.Parameters.AddWithValue("@DATA_PALESTRA", P.Data);
        //        cf.Comando.Parameters.AddWithValue("@HORA_PALESTRA", P.Hora);
        //        cf.Comando.Parameters.AddWithValue("@ID_PALESTRA", P.Id);

        //        cf.Comando.CommandType = CommandType.Text;
        //        cf.Comando.CommandText = query.ToString();
        //        cf.Conexao.Open();

        //        linhasAfetadas = cf.Comando.ExecuteNonQuery();
        //        cf.Conexao.Close();

        //        return linhasAfetadas;
        //    }
        //    catch (Exception EX)
        //    {
        //        throw EX;
        //    }
        //}
    }
}
