using Library.Model.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Usuario
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private PerfilEnum tipoUsuario;

        public PerfilEnum TipoUsuario
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }
        private DateTime ultimoAcesso;

        public DateTime UltimoAcesso
        {
            get { return ultimoAcesso; }
            set { ultimoAcesso = value; }
        }

        
    }
}
