using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Torre : Peca
    {
        public Torre(Cor cor) : base(cor){}
        public override string ToString()
        {
            return "T";
        }
    }
}
