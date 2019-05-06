using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Palestra
    {
        private int id;
        private string titulo;
        private string descricao;
        private string palestrante;
        private DateTime data;
        private string hora;
        private int tipoPalestra;
        private string situacao;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Palestrante { get => palestrante; set => palestrante = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Hora { get => hora; set => hora = value; }
        public int TipoPalestra { get => tipoPalestra; set => tipoPalestra = value; }
        public string Situacao { get => situacao; set => situacao = value; }
    }
}
