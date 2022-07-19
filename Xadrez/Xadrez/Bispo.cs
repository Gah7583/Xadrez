using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Cor cor) : base(cor){}
        public override string ToString()
        {
            return "B";
        }
    }
}
