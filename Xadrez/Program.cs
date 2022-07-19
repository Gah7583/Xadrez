using Xadrez.SistemaTabuleiro;
using Xadrez.Xadrez;

Tabuleiro tab = new(8, 8);

//Peões
for (int i = 0; i < 8; i++)
{
    Posicao posicaoBranca = new(6, i);
    Posicao posicaoPreta = new(1, i);
    tab.ColocarPeca(new Peao(Cor.Branca), posicaoBranca);
    tab.ColocarPeca(new Peao(Cor.Preta), posicaoPreta);
}

//Torres
tab.ColocarPeca(new Torre(Cor.Preta), new Posicao(0, 0));
tab.ColocarPeca(new Torre(Cor.Preta), new Posicao(0, 7));
tab.ColocarPeca(new Torre(Cor.Branca), new Posicao(7, 0));
tab.ColocarPeca(new Torre(Cor.Branca), new Posicao(7, 7));

//Cavalos
tab.ColocarPeca(new Cavalo(Cor.Preta), new Posicao(0, 1));
tab.ColocarPeca(new Cavalo(Cor.Preta), new Posicao(0, 6));
tab.ColocarPeca(new Cavalo(Cor.Branca), new Posicao(7, 1));
tab.ColocarPeca(new Cavalo(Cor.Branca), new Posicao(7, 6));

//Bispos
tab.ColocarPeca(new Bispo(Cor.Preta), new Posicao(0, 2));
tab.ColocarPeca(new Bispo(Cor.Preta), new Posicao(0, 5));
tab.ColocarPeca(new Bispo(Cor.Branca), new Posicao(7, 2));
tab.ColocarPeca(new Bispo(Cor.Branca), new Posicao(7, 5));

//Reis e Damas
tab.ColocarPeca(new Rei(Cor.Preta), new Posicao(0, 4));
tab.ColocarPeca(new Rei(Cor.Branca), new Posicao(7, 4));
tab.ColocarPeca(new Dama(Cor.Preta), new Posicao(0, 3));
tab.ColocarPeca(new Dama(Cor.Branca), new Posicao(7, 3));

Tela.ImprimirTabuleiro(tab);
Console.ReadLine();