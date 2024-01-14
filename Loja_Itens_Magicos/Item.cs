using System;
using System.Collections.Generic;

namespace Loja_Itens_Magicos
{
    public class Item
    {
        public string Nome;
        public int Preco;
        public string Categoria;
        public string Descricao;
        public int Quantidade;

        public Item()
        {
        }

        public Item(string nome, int preco, string categoria, string descricao, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            Descricao = descricao;
            Quantidade = quantidade;
        }
        

        public static Item CopiaItem(Item itemCopia, int quantidade)
        {
            Item itemVendido = new Item();
            itemVendido.Nome = itemCopia.Nome;
            itemVendido.Preco = itemCopia.Preco;
            itemVendido.Categoria = itemCopia.Categoria;
            itemVendido.Descricao = itemCopia.Descricao;
            itemVendido.Quantidade = quantidade;

            return itemVendido;
        }
    }
}
