using System;
using System.Collections.Generic;
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

        public void xml(string stream)
        {
            var myBinaryFormatter = new BinaryFormatter();
            myBinaryFormatter.Deserialize(stream); // Noncompliant: a binder is not used to limit types during deserialization
        }
    }
}
