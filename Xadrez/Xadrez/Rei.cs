using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez Partida { get; set; }
        public Rei(Cor cor, PartidaDeXadrez partida) : base(cor)
        {
            Partida = partida;
        }
        public override string ToString()
        {
            return "R";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //roque pequeno
            if (QtdMovimento == 0 && !Partida.Xeque)
            {
                pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
                while (Tabuleiro.PosicaoValida(pos))
                {
                    if (Tabuleiro.Peca(pos) is Torre && Tabuleiro.Peca(pos).QtdMovimento == 0)
                    {
                        mat[pos.Linha, pos.Coluna - 1] = true;
                    }
                    if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor == Cor)
                    {
                        break;
                    }
                    pos.Coluna++;
                }

            }
            // roque grande
            if (QtdMovimento == 0 && !Partida.Xeque)
            {
                pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
                while (Tabuleiro.PosicaoValida(pos))
                {
                    if (Tabuleiro.Peca(pos) is Torre && Tabuleiro.Peca(pos).QtdMovimento == 0)
                    {
                        mat[pos.Linha, pos.Coluna +2] = true;
                    }
                    if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor == Cor)
                    {
                        break;
                    }
                    pos.Coluna--;
                }
            }
            return mat;
        }
    }
}
