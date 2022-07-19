namespace Xadrez.SistemaTabuleiro
{
    internal class Peca
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
    }
}
