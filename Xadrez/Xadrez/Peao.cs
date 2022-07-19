using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Peao : Peca
    {
        public Peao(Cor cor) : base(cor){}
        public override string ToString()
        {
            return "P";
        }
    }
}
