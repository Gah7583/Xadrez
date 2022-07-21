using Xadrez.SistemaTabuleiro;

namespace Xadrez.Xadrez
{
    internal class PosicaoXadrez
    {
        public int Linha { get; set; }
        public char Coluna { get; set; }

        public PosicaoXadrez(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public PosicaoXadrez(int linha, int coluna)
        {
            Linha = (8 - linha);
            Coluna = Convert.ToChar(coluna + 97);
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
