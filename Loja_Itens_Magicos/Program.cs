using System;

namespace Loja_Itens_Magicos
{
    class Program
    {
        static void Main(string[] args)
        {

            int alternativa = 0;
            Loja loja = new Loja();

            do
            {
                Console.WriteLine("1 - Sou o Mercante");
                Console.WriteLine("2 - Sou cliente");
                Console.WriteLine("0 - encerrar \n");
                alternativa = Convert.ToInt16(Console.ReadLine());

                if (alternativa == 1)
                {
                    loja.AddCatalogo();

                }
                else if (alternativa == 2)
                {
                    Personagem aventureiro = new Personagem();
                    aventureiro.ClienteEscolha(loja, aventureiro);
                }
                else if (alternativa != 0)
                {
                    Console.WriteLine("Entrada Invalida");
                }
            } while (alternativa != 0);
            
        }

        

    }
}
