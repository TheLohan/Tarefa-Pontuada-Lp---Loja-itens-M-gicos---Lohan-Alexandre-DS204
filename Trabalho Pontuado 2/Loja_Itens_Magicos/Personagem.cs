using System;
using System.Collections.Generic;


namespace Loja_Itens_Magicos
{
    public class Personagem
    {
        public string Nome;
        public Int32 Ouro;
        public List<Item> Inventario = new List<Item>();

        public void ApresentaçãoAventureiro(Personagem aventureiro)
        {
            Console.Clear();
           Console.WriteLine("Olá mercante, meu nome é: ");
           aventureiro.Nome = Console.ReadLine();
           Console.WriteLine("Mercante: Quantas moedas de ouro você possui, aventureiro ?");
           aventureiro.Ouro = int.Parse(Console.ReadLine());
        }

        public String Comprar()
        {
            
            Console.Write("Eu quero comprar: ");
            string carrinho = Console.ReadLine();
            return carrinho;
        }

        public void ClienteEscolha(Loja loja, Personagem aventureiro)
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
                if (alternativa == 1)
                {
                    loja.ApresentarCatalogo();
                }
                else if (alternativa == 2 && loja.VerificarEstoque() == true)
                {
                    Console.Clear();
                    loja.ApresentarCatalogo();
                    loja.Vender(aventureiro.Comprar(), aventureiro);
                }else if(alternativa == 3)
                {
                    Console.Clear();
                    if(aventureiro.Inventario.Count == 0)
                    {
                        Console.WriteLine("\nMeu ouro: " + aventureiro.Ouro + "\n");
                    }
                    else
                    {
                        Console.WriteLine("\nMeu ouro: " + aventureiro.Ouro);
                        foreach (var inventario in aventureiro.Inventario)
                        {
                            Console.WriteLine("\nNome: " + inventario.Nome);
                            Console.WriteLine("Descrição: " + inventario.Descricao);
                            Console.WriteLine("Quantidade: " + inventario.Quantidade + "\n");
                        }
                    }
                }
                else if (loja.VerificarEstoque() == false)
                {
                    Console.Clear();
                    Console.WriteLine("\nVendedor: Não tenho nada no estoque no momento. Volte depois, Aventureiro");
                }
                else if (alternativa != 0)
                {
                    Console.WriteLine("Entrada Invalida");
                }

            } while (alternativa != 0);
            Console.Clear();
        }
    }
}
