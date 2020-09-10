using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security.Cryptography;

namespace APIContagem
{
    public class Contador
    {
        private static readonly string _LOCAL;
        private static readonly string _KERNEL;
        private static readonly string _TARGET_FRAMEWORK;

        static Contador()
        {
            _LOCAL = Environment.MachineName;
            _KERNEL = Environment.OSVersion.VersionString;
            _TARGET_FRAMEWORK = Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;
        }

        private int _valorAtual = 0;

        public int ValorAtual { get => _valorAtual; }
        public string Local { get => _LOCAL; }
        public string Kernel { get => _KERNEL; }
        public string TargetFramework { get => _TARGET_FRAMEWORK; }
        public string host = "192.168.0.1";
        public string password = "*123";
        public static List<String> strings3 = new List<String>();  // Noncompliant

        AesManaged aes4 = new AesManaged
        {
            KeySize = 128,
            BlockSize = 128,
            Mode = CipherMode.ECB, // Noncompliant
            Padding = PaddingMode.PKCS7
        };


        public void Incrementar()
        {
            _valorAtual++;
        }

        public void Decrementar()
        {
            try
            {
                _valorAtual--;
            }
            catch (Exception exc) 
            { 

            }
        }

        public void executa(string acao)
        {
            if (acao == "I")
            {
                _valorAtual++;
            }
            else
            {
                _valorAtual++;
            }
        }

        public void xml(System.IO.Stream stream)
        {
            var myBinaryFormatter = new BinaryFormatter();
            myBinaryFormatter.Deserialize(stream); // Noncompliant: a binder is not used to limit types during deserialization
        }

        public string Randomico()
        {
            var random = new Random(); // Sensitive use of Random
            byte[] data = new byte[16];
            random.NextBytes(data);
            return BitConverter.ToString(data); // Check if this value is used for hashing or encryption

        }

        public void Foo(string param)
        {
            SqlConnection conn = new SqlConnection();
            string query = $"SELECT * FROM mytable WHERE mycol=";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Concat(query, param);
            cmd.CommandTimeout = 15;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}
