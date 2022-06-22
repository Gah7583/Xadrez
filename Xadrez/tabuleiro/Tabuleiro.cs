namespace Xadrez.Tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { set; get; }
        public int Colunas  { set; get; }
        private Peca[,] Pecas { set; get; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
    }
}
