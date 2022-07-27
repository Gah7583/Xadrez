using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool PartidaTerminada { get; private set; }
        public bool Xeque { get; private set; }
        private readonly HashSet<Peca> pecas;
        private readonly HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            pecas = new();
            capturadas = new();
            ColocarPecas();
        }
        public Peca MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.Peca(origem);
            peca.IncrementarQtdMovimento();
            Peca pecaCapturada = Tabuleiro.Peca(destino);
            Tabuleiro.RetirarPeca(destino);
            Tabuleiro.RetirarPeca(origem);
            Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = MovimentarPeca(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            JogadorAtual = JogadorAtual == Cor.Branca ? Cor.Preta : Cor.Branca;
            Turno++;

        }

        private void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tabuleiro.Peca(destino);
            peca.DecrementarQtdMovimento();
            Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, origem);
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new();
            foreach (Peca item in capturadas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new();
            foreach (Peca item in pecas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ColocarNovaPeca(int linha, int coluna, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new Posicao(linha, coluna));
            pecas.Add(peca);
        }
        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tabuleiro.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça na posição de origem não é sua!");
            }
            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (Tabuleiro.Peca(destino) is not null && Tabuleiro.Peca(destino).Cor == JogadorAtual)
            {
                throw new TabuleiroException("Você não pode comer sua própria peça!");
            }
            if (!Tabuleiro.Peca(origem).PossoMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino Inválida!");
            }
        }
        private static Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        public bool EstaEmXeque(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                Peca rei = Rei(cor);
                if (rei == null)
                {
                    throw new TabuleiroException("Não tem rei da cor " + cor + "no tabuleiro");
                }
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        private Peca Rei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }
        private void ColocarPecas()
        {
            //Peões
            for (int i = 0; i < 8; i++)
            {
                ColocarNovaPeca(6, i, new Peao(Cor.Branca));
                ColocarNovaPeca(1, i, new Peao(Cor.Preta));
            }

            //Torres
            ColocarNovaPeca(0, 0, new Torre(Cor.Preta));
            ColocarNovaPeca(0, 7, new Torre(Cor.Preta));
            ColocarNovaPeca(7, 0, new Torre(Cor.Branca));
            ColocarNovaPeca(7, 7, new Torre(Cor.Branca));

            //Cavalos
            ColocarNovaPeca(0, 1, new Cavalo(Cor.Preta));
            ColocarNovaPeca(0, 6, new Cavalo(Cor.Preta));
            ColocarNovaPeca(7, 1, new Cavalo(Cor.Branca));
            ColocarNovaPeca(7, 6, new Cavalo(Cor.Branca));

            //Bispos
            ColocarNovaPeca(0, 2, new Bispo(Cor.Preta));
            ColocarNovaPeca(0, 5, new Bispo(Cor.Preta));
            ColocarNovaPeca(7, 2, new Bispo(Cor.Branca));
            ColocarNovaPeca(7, 5, new Bispo(Cor.Branca));

            //Reis e Damas
            ColocarNovaPeca(0, 3, new Rei(Cor.Preta));
            ColocarNovaPeca(7, 3, new Rei(Cor.Branca));
            ColocarNovaPeca(0, 4, new Dama(Cor.Preta));
            ColocarNovaPeca(7, 4, new Dama(Cor.Branca));
        }
    }
}
