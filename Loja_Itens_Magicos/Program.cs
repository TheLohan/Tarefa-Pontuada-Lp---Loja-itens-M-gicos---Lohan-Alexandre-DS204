using System;

namespace Loja_Itens_Magicos
{
    class Program
    {
        public static void ApresentarEscolhasDoCliente(Loja loja, Personagem aventureiro)
        {
            
            Console.Clear();
            int alternativa;
            
            do
            {
                Console.WriteLine("1 - Apresente-me o Catálogo.");
                Console.WriteLine("2 - Quero Comprar."); 
                Console.WriteLine("3 - Meu Inventário");
                Console.WriteLine("0 - voltar");
                alternativa = Convert.ToInt16(Console.ReadLine());
                switch (alternativa)
                {
                    case 1:
                        loja.ApresentarCatalogo();
                        break;
                    case 2:
                        if (loja.VerificarEstoque())
                        {
                            loja.ApresentarCatalogo();
                            loja.Vender(aventureiro.EscolherItem(), aventureiro);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nVendedor: Não tenho nada no estoque no momento. Volte depois, Aventureiro");
                        }
                        break;
                    case 3:
                        aventureiro.ApresentarInventario();
                        break;
                    default:
                        Console.WriteLine("Entrada Invalida");
                        break;
                }
            } while (alternativa != 0);
            Console.Clear();
        }
        
        static void Main(string[] args)
        {

            int alternativa;
            Loja loja = new Loja();

            do
            {
                Console.WriteLine("1 - Sou o Mercante");
                Console.WriteLine("2 - Sou cliente");
                Console.WriteLine("0 - encerrar \n");
                alternativa = Convert.ToInt16(Console.ReadLine());
                switch (alternativa)
                {
                    case 0:
                        break;
                    case 1:
                        loja.AdicionarAoCatalogo();
                        break;
                    case 2:
                        Personagem aventureiro = new Personagem();
                        ApresentarEscolhasDoCliente(loja, aventureiro);
                        break;
                    default:
                        Console.WriteLine("Entrada Invalida");
                        break;
                }
            } while (alternativa != 0);
            
        }

        

    }
}
