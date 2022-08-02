using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez Partida { get; set; }
        public Peao(Cor cor, PartidaDeXadrez partida) : base(cor)
        {
            Partida = partida;
        }
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
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && PodeMover(esquerda) && Partida.vulneravelEnPassant == Tabuleiro.Peca(esquerda))
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    if (Tabuleiro.PosicaoValida(direita) && PodeMover(direita) && Partida.vulneravelEnPassant == Tabuleiro.Peca(direita))
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
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
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao direita = new(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && PodeMover(esquerda) && Partida.vulneravelEnPassant == Tabuleiro.Peca(esquerda))
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    if (Tabuleiro.PosicaoValida(direita) && PodeMover(direita) && Partida.vulneravelEnPassant == Tabuleiro.Peca(direita))
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }

            }

            return mat;
        }
    }
}
