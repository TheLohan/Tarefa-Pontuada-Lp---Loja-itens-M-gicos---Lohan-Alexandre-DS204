using System;
using System.Collections.Generic;


namespace Loja_Itens_Magicos
{
    public class Personagem
    {
        public string Nome { get; set; }
        public int Ouro { get; set; }
        public List<Item> Inventario = new List<Item>();
        
        public Personagem()
        {
           Console.Clear();
           Console.WriteLine("Olá mercante, meu nome é: ");
           Nome = Console.ReadLine();
           Console.WriteLine("Mercante: Quantas moedas de ouro você possui, aventureiro ?");
           Ouro = Convert.ToInt32(Console.ReadLine());
        }

        public Personagem(string nome, int ouro)
        {
            Nome = nome;
            Ouro = ouro;
        }

        public String EscolherItem()
        {
            Console.Write("Eu quero comprar: ");
            string carrinho = Console.ReadLine();
            return carrinho;
        }

        public void ApresentarInventario()
        {
            Console.Clear();
            if(Inventario.Count == 0)
            {
                Console.WriteLine("\nMeu ouro: " + Ouro + "\n");
            }
            else
            {
                Console.WriteLine("\nMeu ouro: " + Ouro);
                foreach (var inventario in Inventario)
                {
                    Console.WriteLine("\nNome: " + inventario.Nome);
                    Console.WriteLine("Descrição: " + inventario.Descricao);
                    Console.WriteLine("Quantidade: " + inventario.Quantidade + "\n");
                }
            }
        }
        
    }
}
