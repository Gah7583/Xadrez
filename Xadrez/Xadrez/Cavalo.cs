using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Cor cor) : base(cor){}
        public override string ToString()
        {
            return "C";
        }
    }
}
