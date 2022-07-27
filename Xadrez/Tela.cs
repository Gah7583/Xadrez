using Xadrez.SistemaTabuleiro;
using Xadrez.Xadrez;

internal class Tela
{
    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                ImprimirPeca(tab.Peca(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }
    public static void ImprimirPartida(PartidaDeXadrez partida)
    {
        ImprimirTabuleiro(partida.Tabuleiro);
        ImprimirPecasCapturadas(partida);
        Console.WriteLine();
        Console.WriteLine("Turno: " + partida.Turno);
        Console.WriteLine("Aguardando jogador das peças da cor " + partida.JogadorAtual);
        if (partida.Xeque)
        {
            Console.WriteLine("Xeque!");
        }
    }

    private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
    {
        Console.WriteLine("Peças capturadas:");
        Console.Write("Brancas: ");
        ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
        Console.Write("Pretas: ");
        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        Console.ForegroundColor = aux;
    }

    private static void ImprimirConjunto(HashSet<Peca> pecas)
    {
        Console.Write("[");
        foreach (Peca item in pecas)
        {
            Console.Write(item+ " ");
        }
        Console.WriteLine("]");
    }

    public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posP)
    {
        ConsoleColor FundoOriginal = Console.BackgroundColor;
        ConsoleColor FundoAlterada = ConsoleColor.Red;


        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                if (posP[i, j])
                {
                    Console.BackgroundColor = FundoAlterada;
                }
                ImprimirPeca(tab.Peca(i, j));
                Console.BackgroundColor = FundoOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }

    public static Posicao LerPosicaoXadrez()
    {
        string? s = Console.ReadLine();
        if (string.IsNullOrEmpty(s))
        {
            throw new TabuleiroException("Digite a posição");
        }
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");
        return new PosicaoXadrez(linha, coluna).ToPosicao();
    }

    public static void ImprimirPeca(Peca peca)
    {
        if (peca == null)
        {
            Console.Write("- ");
        }
        else if (peca.Cor == Cor.Branca)
        {
            Console.Write(peca + " ");
        }
        else
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(peca + " ");
            Console.ForegroundColor = aux;
        }
    }
}
