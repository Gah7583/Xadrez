using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Cor cor) : base(cor) { }
        public override string ToString()
        {
            return "B";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0,0);

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
            //sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
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
