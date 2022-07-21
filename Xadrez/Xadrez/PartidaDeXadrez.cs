using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool PartidaTerminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8,8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            ColocarPecas();
        }
        public void MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.Peca(origem);
            peca.IncrementarQtdMovimento();
            Tabuleiro.RetirarPeca(destino);
            Tabuleiro.RetirarPeca(origem);
            Tabuleiro.ColocarPeca(peca, destino);
            turno++;
        }
        private void ColocarPecas()
        {
            //Peões
            for (int i = 0; i < 8; i++)
            {
                Posicao posicaoBranca = new(6, i);
                Posicao posicaoPreta = new(1, i);
                Tabuleiro.ColocarPeca(new Peao(Cor.Branca), posicaoBranca);
                Tabuleiro.ColocarPeca(new Peao(Cor.Preta), posicaoPreta);
            }

            //Torres
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta), new Posicao(0, 0));
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta), new Posicao(0, 7));
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca), new Posicao(7, 0));
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca), new Posicao(7, 7));

            //Cavalos
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta), new Posicao(0, 1));
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta), new Posicao(0, 6));
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca), new Posicao(7, 1));
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca), new Posicao(7, 6));

            //Bispos
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta), new Posicao(0, 2));
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta), new Posicao(0, 5));
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca), new Posicao(7, 2));
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca), new Posicao(7, 5));

            //Reis e Damas
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta), new Posicao(0, 4));
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca), new Posicao(7, 4));
            Tabuleiro.ColocarPeca(new Dama(Cor.Preta), new Posicao(0, 3));
            Tabuleiro.ColocarPeca(new Dama(Cor.Branca), new Posicao(7, 3));
        }
    }
}
