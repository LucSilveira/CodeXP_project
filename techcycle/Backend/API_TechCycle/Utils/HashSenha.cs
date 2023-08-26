using System.Security.Cryptography;
using System.Text;

namespace API_TechCycle.Utils
{
    public class HashSenha
    {
        private HashAlgorithm algorithm;

        public HashSenha(HashAlgorithm algoritmo)
        {
            algorithm = algoritmo;
        }

        public string HasheandoSenha(string senha)
        {
            var recebendoSenha = Encoding.UTF8.GetBytes(senha);
            var hasheando = algorithm.ComputeHash(recebendoSenha);

            var stringBuilder  = new StringBuilder();
            foreach(var texto in hasheando)
            {
                stringBuilder.Append(texto.ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }
}