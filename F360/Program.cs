using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F360
{
    public static class Program
    {
        
        static string textoB = File.ReadAllText(@"klingon-textoB.txt");

        static string[] foo = { "s", "l", "f", "w", "k" };

        static string[] valoresUnicos = textoB.Split(' ');

        static List<string> KlingonAlphabet = new List<string>()
            {
                "k", "b", "w", "r", "q", "d", "n", "f", "x", "j", "m", "l", "v", "h", "t", "c", "g", "z", "p", "s"
            };

        static void Main(string[] args)
        {
            Console.WriteLine("No texto B existem " + Exercicio1().Count + " preposições. \n");

            Console.WriteLine("No texto B existem " + Exercicio2().Count + " verbos. \n");

            Console.WriteLine("No texto B existem " + Exercicio3().Count + " verbos em primeira pessoa. \n");

            Console.WriteLine("Lista de vocabularios do texto B: " + string.Join(" ", Exercicio4()) + " \n");

            Console.WriteLine("No texto B existem " + Exercicio5().Count + " números bonitos. \n");
        }

        public static List<string> Exercicio1()
        {
                List<string> PreposicaoFinal = new List<string>();

                for (var i = 0; i < valoresUnicos.Length; i++)
                {
                    string str1 = valoresUnicos[i];

                    bool result = foo.Any(x => str1.EndsWith(x));

                    if (valoresUnicos[i].Length <= 3 && !(valoresUnicos[i].Contains("d")) && result == false)
                    {
                        PreposicaoFinal.Add(valoresUnicos[i]);
                    }
                }

            return PreposicaoFinal;
        }

        public static List<string> Exercicio2()
        {
                List<string> VerbosFinal2 = new List<string>();
                List<string> VerbosPPFinal = new List<string>();

                for (var i = 0; i < valoresUnicos.Length; i++)
                {
                    string str2 = valoresUnicos[i];

                    bool result = foo.Any(x => str2.EndsWith(x)); // Termina com Foo = True/False
                    bool result1 = foo.Any(x => str2.StartsWith(x)); // Começa com Foo = True/False

                    if (valoresUnicos[i].Length >= 8 && result == true)
                    {
                        VerbosFinal2.Add(valoresUnicos[i]);
                    }
                }

            return VerbosFinal2;
        }

        public static List<String> Exercicio3()
        {
            List<string> VerbosFinal = new List<string>();
            List<string> VerbosPPFinal = new List<string>();

            for (var i = 0; i < valoresUnicos.Length; i++)
            {
                string str = valoresUnicos[i];

                bool result = foo.Any(x => str.EndsWith(x)); // Termina com Foo = True/False
                bool result1 = foo.Any(x => str.StartsWith(x)); // Começa com Foo = True/False

                if (valoresUnicos[i].Length >= 8 && result == true && result1 == false)
                {
                    VerbosPPFinal.Add(valoresUnicos[i]);
                }
                else if (valoresUnicos[i].Length >= 8 && result == true)
                {
                    VerbosFinal.Add(valoresUnicos[i]);
                }
            }

            return VerbosPPFinal;
        }

        public static List<String> Exercicio4()
        {
            List<string> KlingnonFinal4 = new List<string>();

            List<string> NoDuplicates4 = valoresUnicos.Distinct().ToList(); // Texto X em lista sem duplicados

            for (var i = 0; i < KlingonAlphabet.Count; i++)
            {
                string KliLetra4 = KlingonAlphabet[i];

                for (var b = 0; b < NoDuplicates4.Count; b++)
                {
                    string PalavraVocabulario4 = NoDuplicates4[b];

                    string PLetraVocabulario4 = PalavraVocabulario4.Substring(0, 1);

                    if (PLetraVocabulario4 == KliLetra4)
                    {
                        KlingnonFinal4.Add(PalavraVocabulario4);
                    }
                }
                

            }

            return KlingnonFinal4;
        }

        public static List<Int64> Exercicio5()
        {
            List<Int64> PalavrasBonitas = new List<Int64>();

            for (var i = 0; i < valoresUnicos.Length; i++) // le cada palavra do texto
            {
                string Letra = valoresUnicos[i]; //armazena o numero de caracteres de uma palavra

                var y = 0;

                List<Int64> PalavraTotalValue = new List<Int64>();

                foreach (char c in Letra) // letra em (c) 
                {
                    int posicaoAlfabeto = KlingonAlphabet.IndexOf(c.ToString());

                    Int64 pesoPosicao = (int)(long)Math.Pow(20, y);

                    Int64 valorLetra = posicaoAlfabeto * pesoPosicao;

                    PalavraTotalValue.Add(valorLetra);

                    y++;
                }

                Int64 total = PalavraTotalValue.Sum(x => Convert.ToInt64(x));

                if (total >= 440566 && total % 3 == 0)
                {
                    PalavrasBonitas.Add(total);
                }

            }

            return PalavrasBonitas;
        }
    }
}









