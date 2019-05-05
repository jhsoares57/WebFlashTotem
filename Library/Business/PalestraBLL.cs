using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class PalestraBLL
    {
        public bool Insert(Palestra p)
        {
            bool salvou = false;
            new PalestraDAL().Insert(p);

            //Se o ID for maior que zero, indica que o dado foi salvo
            if (p.Id > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Palestra> FindAll()
        {
            PalestraDAL pDAL = new PalestraDAL();
            return pDAL.FindAll();
        }

        public List<Palestra> FindAllList()
        {
            PalestraDAL pDAL = new PalestraDAL();
            return pDAL.FindAllList();
        }
        public Palestra FindById(int Id)
        {
            PalestraDAL dal = new PalestraDAL();
            return dal.FindById(Id);
        }

        public bool Delete(int id)
        {
            bool deletou = false;
            PalestraDAL pDAL = new PalestraDAL();
            if (pDAL.Delete(id) > 0)
            {
                deletou = true;
            }
            return deletou;
        }

        public bool Update(Palestra P)
        {
            bool atualizou = false;
            PalestraDAL pDAL = new PalestraDAL();

            //if (P.Id == 0)
            //{
            //    throw new Exception("Selecione uma pessoa para atualizar.");
            //}

            if (pDAL.Update(P) > 0)
            {
                //Este IF verificará se o retorno do método será maior que 0,
                //ou seja, se a atualização foi feita pela classe que acessa o Banco
                //se sim vai mudar para TRUE a variável e retornar para quem chamou este método.
                atualizou = true;
            }
            return atualizou;
        }
    }
}
