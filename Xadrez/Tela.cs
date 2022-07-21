﻿using Xadrez.SistemaTabuleiro;
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
                if (tab.Peca(i, j) is not null)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                else
                {
                    Console.Write("- ");
                }
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
            throw new XadrezException("Digite a posição");
        }
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");
        return new PosicaoXadrez(linha, coluna).ToPosicao();
    }

    public static void ImprimirPeca(Peca peca)
    {
        if (peca.Cor == Cor.Branca)
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
