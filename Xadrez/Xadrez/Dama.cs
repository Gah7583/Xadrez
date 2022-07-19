using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class Dama : Peca
    {
        public Dama(Cor cor) : base(cor) { }
        public override string ToString()
        {
            return "D";
        }
    }
}
