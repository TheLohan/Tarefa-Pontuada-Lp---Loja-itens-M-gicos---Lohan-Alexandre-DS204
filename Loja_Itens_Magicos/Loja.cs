using System;
using System.Collections.Generic;

namespace Loja_Itens_Magicos
{
    public class Loja
    {
        public Dictionary<string, Item> Catalogo = new Dictionary<string, Item>();

        public void AdicionarAoCatalogo()
        {
            Console.Clear();
            
            int alternativa;
            do
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
                
                Catalogo.Add(item.Nome, item);
                Console.WriteLine("\nDeseja catalogar outro item, Mercante? Sim (1) - Não (0)");
                alternativa = int.Parse(Console.ReadLine());
                if (alternativa != 1 && alternativa != 0)
                {
                    Console.WriteLine("Opção Inválida!");
                }

                Console.Clear();
            } while (alternativa != 0);
        }

        public bool VerificarEstoque()
        {
            return Catalogo.Count > 0;
        }

        public static int VerificarQuantidade()
        {
            Console.WriteLine("Quantos vai querer, Aventureiro!");
            return int.Parse(Console.ReadLine());
        }


        public void ApresentarCatalogo()
        {
            Console.Clear();
            
            if (!VerificarEstoque())
            {
                Console.WriteLine("Vendedor: Não tenho nada no estoque no momento. Volte depois, Aventureiro\n");
                return;
            }
            Console.WriteLine("Olá Aventureiro! O que desejas: ");
            foreach (KeyValuePair<string, Item> item in Catalogo)
            {
                Console.WriteLine("\nNome: " + item.Value.Nome);
                Console.WriteLine("Preço: " + item.Value.Preco);
                Console.WriteLine("Categoria: " + item.Value.Categoria);
                Console.WriteLine("Descrição: " + item.Value.Descricao);
                Console.WriteLine("Quantidade: " + item.Value.Quantidade + "\n");
            }
        }

        public void Vender(string itemEscolhido, Personagem aventureiro)
        {
            if (!Catalogo.TryGetValue(itemEscolhido, out Item item))
            {
                Console.WriteLine("não tenho esse produto, Aventureiro\n");
                return;
            }
            
            if (item.Quantidade <= 0)
            {
                Console.WriteLine("Mercante: Infelizmente não tenho mais esse item, Aventureiro!\n");
                Catalogo.Remove(itemEscolhido);
                return;
            }

            int quantidadeEscolhida = VerificarQuantidade();
            List<Item> listaTemp = new List<Item>();
            if (quantidadeEscolhida > item.Quantidade)
            {
                Console.WriteLine("Não tenho isso tudo, Aventureiro!\n");
                return;
            }
  
            item.Quantidade = item.Quantidade - quantidadeEscolhida;
            if (aventureiro.Inventario.Count == 0 && item.Preco < aventureiro.Ouro)
            {
                aventureiro.Inventario.Add(Item.CopiaItem(item, quantidadeEscolhida));
                Console.WriteLine("Item Vendido!\n");
                aventureiro.Ouro -= item.Preco * quantidadeEscolhida;
            }
            else if (aventureiro.Inventario.Count != 0 && item.Preco > aventureiro.Ouro)
            {
                Console.WriteLine("Você não tem ouro suficiente, Aventureiro!\n");
            }
            else if (aventureiro.Inventario.Count != 0 && item.Preco < aventureiro.Ouro)
            {
                foreach (var itemDoInventario in aventureiro.Inventario)
                {
                    if (itemDoInventario.Nome == item.Nome)
                    {
                        itemDoInventario.Quantidade += 1 * quantidadeEscolhida;
                    }
                    else
                    {
                        listaTemp.Add(Item.CopiaItem(item, quantidadeEscolhida));
                    }
                }

                foreach (var itemTemp in listaTemp)
                {
                    aventureiro.Inventario.Add(itemTemp);
                }

                aventureiro.Ouro -= item.Preco * quantidadeEscolhida;
                Console.WriteLine("Item Vendido\n");
            }
            
            
        }
    }
}