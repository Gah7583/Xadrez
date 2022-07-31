using Xadrez.SistemaTabuleiro;
using Xadrez.Xadrez;

try
{
    PartidaDeXadrez partida = new();
    while (!partida.PartidaTerminada)
    {
        Console.Clear();
        Tela.ImprimirPartida(partida);
        Console.Write("Selecione a peça a ser movimentada: ");
        Posicao origem = Tela.LerPosicaoXadrez();
        partida.ValidarPosicaoDeOrigem(origem);
        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();
        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);
        Console.Write("Selecione o destino da peça: ");
        Posicao destino = Tela.LerPosicaoXadrez();
        partida.ValidarPosicaoDeDestino(origem, destino);
        partida.RealizarJogada(origem, destino);
    }
    Console.Clear();
    Tela.ImprimirPartida(partida);
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}