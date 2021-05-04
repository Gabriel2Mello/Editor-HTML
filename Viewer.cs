using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public class Viewer
    {
        public static void Show(string text)
        {
            VisuTela();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Menu.DrawColumn(Dimensao.Coluna, '-');
            Console.Write('\n');
            Replace(text);
            Console.Write('\n');
            Menu.DrawColumn(Dimensao.Coluna, '-');
            Console.Write('\n');
            Console.Write("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
            Menu.Show(Dimensao.Linha, Dimensao.Coluna);
        }

        public static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            (
                                (words[i].LastIndexOf('<') - 1) -
                                words[i].IndexOf('>')
                            )
                        )
                    );
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Show(text);
            }
        }

        public static void VisuTela()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}