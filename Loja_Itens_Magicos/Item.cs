using System;
using System.Collections.Generic;

namespace Loja_Itens_Magicos
{
    public class Item
    {
        public string Nome;
        public Int32 Preco;
        public string Categoria;
        public string Descricao;
        public int Quantidade;
        public static Item CriarItem()
        {

            Item item = new Item();
            Console.WriteLine("Entre com o nome do item, Mercante: \n");
            item.Nome = Console.ReadLine();
            Console.WriteLine("\nEntre com o preço, Mercante: \n");
            item.Preco = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEntre com a categoria, Mercante: \n");
            item.Categoria = Console.ReadLine();
            Console.WriteLine("\nEntre com a descrição, Mercante: \n");
            item.Descricao = Console.ReadLine();
            Console.WriteLine("\nEntre com a quantidade do item, Mercante: \n");
            item.Quantidade = int.Parse(Console.ReadLine());

            return item;

        }
    }
}
