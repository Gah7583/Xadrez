using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Peao : Peca
    {
        public Peao(Cor cor) : base(cor) { }
        public override string ToString()
        {
            return "P";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            if (Cor == Cor.Branca)
            {
                if (QtdMovimento == 0)
                {
                    pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                    if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) == null)
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) == null)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                if (QtdMovimento == 0)
                {
                    pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                    if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) == null)
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) == null)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

            }
            return mat;
        }
    }
}
