namespace Xadrez.SistemaTabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { set; get; }
        public int Colunas { set; get; }
        private Peca[,] Pecas { set; get; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
            p.Tabuleiro = this;
        }
    }
}
