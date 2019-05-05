using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{
    public class Criptografia
    {
        public static string GerarMD5(string valor)
        {
            MD5 md5Hasher = MD5.Create();

            //Criptografa o valor passado
            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[1].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
