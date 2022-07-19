using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Rei : Peca
    {
        public Rei(Cor cor) : base(cor){}
        public override string ToString()
        {
            return "R";
        }
    }
}
