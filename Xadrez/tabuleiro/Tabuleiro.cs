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
        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
            p.Tabuleiro = this;
        }
        public void RetirarPeca(Posicao pos)
        {
            if (ExistePeca(pos))
            {
                Peca aux = Peca(pos);
                aux.Posicao = null;
                Pecas[pos.Linha, pos.Coluna] = null;
            }
        }
        public static bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha > 7 || pos.Linha < 0 || pos.Coluna > 7 || pos.Coluna < 0)
            {
                return false;
            }
            return true;
        }
        public static void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }
    }
}
