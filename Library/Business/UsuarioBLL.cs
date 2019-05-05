using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class UsuarioBLL
    {
        public bool Insert(Usuario u)
        {
            bool salvou = false;
            new UsuarioDAL().Insert(u);

            //Se o ID for maior que zero, indica que o dado foi salvo
            if (u.Id > 0)
            {
                salvou = true;
            }
            return salvou;            
        }

        public Usuario FindByLogin(string login, string senha)
        {
            UsuarioDAL uDAL = new UsuarioDAL();
            return uDAL.FindByLogin(login, senha);            
        }

        public DataTable FindAll()
        {
            UsuarioDAL uDAL = new UsuarioDAL();
            return uDAL.FindAll();
        }
        public int Update(Usuario u)
        {
            UsuarioDAL uDAL = new UsuarioDAL();
            return uDAL.Update(u);
        }
        
        public int Remove(int id)
        {
            UsuarioDAL uDAL = new UsuarioDAL();
            return uDAL.Remove(id);
        }

    }
}
