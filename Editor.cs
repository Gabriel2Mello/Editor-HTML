using System;
using System.IO;
using System.Text;
using System.Threading;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show()
        {
            Viewer.VisuTela();
            Console.WriteLine("MODO EDITOR");
            Menu.DrawColumn(Dimensao.Coluna, '-');
            Console.Write('\n');
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();
            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Write("d");
            Menu.DrawColumn(Dimensao.Coluna, '-');
            Console.Write('\n');
            Console.WriteLine("Deseja salvar o arquivo?");
            string opcao = (Console.ReadLine()).ToLower();

            if (opcao == "sim")
                Salvar(file.ToString());
            else
                AlterandoVisu();

            Viewer.Show(file.ToString());
        }

        static void Salvar(string file)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var text = new StreamWriter(path))
            {
                text.Write(file);
            }

            Console.Clear();
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Thread.Sleep(1500);
            AlterandoVisu();
        }

        public static void AlterandoVisu()
        {
            Console.Write("Alterando para modo visualização");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }
}
