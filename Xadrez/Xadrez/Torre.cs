using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Torre : Peca
    {
        public Torre(Cor cor) : base(cor) { }
        public override string ToString()
        {
            return "T";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (QuebrarMovimento(pos))
                {
                    break;
                }
                pos.Linha--;
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
            //esquerda
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
            return mat;
        }
    }
}
