using Xadrez.SistemaTabuleiro;
using Xadrez.Xadrez;

try
{
    PartidaDeXadrez partida = new();
    while (!partida.PartidaTerminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tabuleiro);
        Console.Write("Selecione a peça a ser movimentada: ");
        Posicao origem = Tela.LerPosicaoXadrez();
        Console.Write("Selecione o destino da peça: ");
        Posicao destino = Tela.LerPosicaoXadrez();
        partida.MovimentarPeca(origem, destino);
    }  
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}