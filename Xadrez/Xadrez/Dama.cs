using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Dama : Peca
    {
        public Dama(Cor cor) : base(cor) { }
        public override string ToString()
        {
            return "D";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1,Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha--;
            }
            //nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha--;
                pos.Coluna++;
            }
            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Coluna++;
            }
            //sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha++;
                pos.Coluna++;
            }
            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha++;
            }
            //sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha++;
                pos.Coluna--;
            }
            //oeste
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Coluna--;
            }
            //noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha--;
                pos.Coluna--;
            }

            return mat;
        }
    }
}
