namespace Xadrez.SistemaTabuleiro
{
    internal abstract class Peca
    {
        public Posicao? Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtdMovimento { get; protected set; }
        public Tabuleiro? Tabuleiro { get; set; }

        public Peca(Cor cor)
        {
            Posicao = null;
            Tabuleiro = null;
            Cor = cor;
            QtdMovimento = 0;
        }
        public void IncrementarQtdMovimento()
        {
            QtdMovimento++;
        }
        public void DecrementarQtdMovimento()
        {
            QtdMovimento--;
        }
        public abstract bool[,] MovimentosPossiveis();

        protected bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        protected bool QuebrarMovimento(Posicao pos)
        {
            if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
            {
                return true;
            }
            return false;
        }
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PossoMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha,pos.Coluna];
        }
    }
}
