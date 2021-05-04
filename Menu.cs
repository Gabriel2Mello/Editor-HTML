using System;

namespace EditorHtml
{
    public static class Menu
    {
        public static void Show(int lines, int columns)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Menu.DrawScreen(lines, columns);
            Menu.WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen(int lines, int columns)
        {
            Console.Write("+");
            DrawColumn(columns, '-');
            Console.Write("+");
            Console.Write("\n");

            DrawLine(lines, columns);

            Console.Write("+");
            DrawColumn(columns, '-');
            Console.Write("+");
            Console.Write("\n");

        }

        public static void DrawColumn(int size, char caractere)
        {
            for (int i = 0; i <= size; i++)
            {
                Console.Write(caractere);
            }
        }

        public static void DrawLine(int lines, int columns)
        {
            for (int i = 0; i <= lines - 1; i++)
            {
                Console.Write("|");
                DrawColumn(columns, ' ');
                Console.Write("|");
                Console.Write("\n");
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(Dimensao.Coluna / 2 - 5, 1);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(1, 2);
            Console.Write('+');
            DrawColumn(Dimensao.Coluna - 2, '-');
            Console.Write('+');
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Selecione uma opção abaixo:");
            Console.SetCursorPosition(4, 4);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(4, 5);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(4, 7);
            Console.WriteLine("3 - Mudar tamanho do menu");
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(2, 9);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Viewer.Abrir(); break;
                case 3: AlteraMenu(); break;
                case 0:
                    {
                        Console.Clear();
                        System.Environment.Exit(0);
                        break;
                    }
                default: Show(Dimensao.Linha, Dimensao.Coluna); break;
            }
        }

        private static void AlteraMenu()
        {
            Console.Clear();
            Console.WriteLine("Quantas linhas você quer no menu?");
            Dimensao.Linha = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantas colunas você quer no menu?");
            Dimensao.Coluna = int.Parse(Console.ReadLine());
            Editor.AlterandoVisu();
            Menu.Show(Dimensao.Linha, Dimensao.Coluna);
        }
    }
}