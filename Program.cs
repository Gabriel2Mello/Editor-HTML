using System;

namespace EditorHtml
{
    public static class Dimensao
    {
        private static int m_linha = 9;
        public static int Linha
        {
            get { return m_linha; }
            set { m_linha = value; }
        }

        private static int m_coluna = 30;
        public static int Coluna
        {
            get { return m_coluna; }
            set { m_coluna = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu.Show(Dimensao.Linha, Dimensao.Coluna);
        }
    }
}
