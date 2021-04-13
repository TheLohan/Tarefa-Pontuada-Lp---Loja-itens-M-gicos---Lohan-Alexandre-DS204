using System;
using System.Collections.Generic;

namespace Loja_Itens_Magicos
{
    public class Loja
    {
        public Dictionary<string, Item> Catalogo = new Dictionary<string, Item>();
        public void AddCatalogo()
        {

            Console.Clear();

            int alternativa = 0;
            do
            {
                Item item = Item.CriarItem();
                Catalogo.Add(item.Nome, item );
                Console.WriteLine("\nDeseja catalogar outro item, Mercante? Sim (1) - Não (0)");
                alternativa = int.Parse(Console.ReadLine());
                if(alternativa != 1 && alternativa != 0)
                {
                    Console.WriteLine("Opção Inválida!");
                }
                Console.Clear();
            } while (alternativa != 0);
            
        }

        public bool VerificarEstoque()
        {
            bool estoque = false;
            if (Catalogo.Count == 0)
            {
                estoque = false;
            }
            else if (Catalogo.Count > 0)
            {
                estoque = true;

            }
            return estoque;
        }

        public void ApresentarCatalogo()
        {
            Console.Clear();
            if (VerificarEstoque() == false)
            {
                Console.WriteLine("Vendedor: Não tenho nada no estoque no momento. Volte depois, Aventureiro\n");
            }else if(VerificarEstoque() == true)
            {
                Console.WriteLine("Olá Aventureiro! O que desejas: ");
                foreach(KeyValuePair<string, Item> item in Catalogo)
                {
                    Console.WriteLine("\nNome: " + item.Value.Nome);
                    Console.WriteLine("Preço: " + item.Value.Preco);
                    Console.WriteLine("Categoria: " + item.Value.Categoria);
                    Console.WriteLine("Descrição: " + item.Value.Descricao);
                    Console.WriteLine("Quantidade: " + item.Value.Quantidade + "\n");
                }
            }          
        }

        public void Vender(string carrinho, Personagem aventureiro)
        {     
            if(Catalogo.TryGetValue(carrinho, out Item item))
            {
                if (item.Quantidade == 0)
                {
                    Console.WriteLine("Mercante: Infelizmente não tenho mais esse item, Aventureiro!\n");
                    Catalogo.Remove(carrinho);
                }
                else if(item.Quantidade > 0)
                {
                    item.Quantidade = item.Quantidade - 1;
                    Item itemVendido = new Item();
                    itemVendido.Nome = item.Nome;
                    itemVendido.Preco = item.Preco;
                    itemVendido.Categoria = item.Categoria;
                    itemVendido.Descricao = item.Descricao;
                    itemVendido.Quantidade = 1;
                    List<Item> listaTemp = new List<Item>();

                    if (aventureiro.Inventario.Count == 0 && item.Preco < aventureiro.Ouro)
                    {
                        aventureiro.Inventario.Add(itemVendido);
                        aventureiro.Ouro -= item.Preco;
                    }
                    else if(aventureiro.Inventario.Count != 0 && item.Preco > aventureiro.Ouro)
                    {
                        Console.WriteLine("Você não tem ouro suficiente, Aventureiro!\n");
                    }
                    else if(aventureiro.Inventario.Count != 0 && item.Preco < aventureiro.Ouro)
                    {
                        foreach (var inventario in aventureiro.Inventario)
                        {
                            if (inventario.Nome == itemVendido.Nome)
                            {
                                inventario.Quantidade += 1;
                            }
                            else
                            {
                                listaTemp.Add(itemVendido);

                            }
                        }
                        foreach(var itemTemp in listaTemp)
                        {
                            aventureiro.Inventario.Add(itemTemp);
                        }
                        aventureiro.Ouro -= item.Preco;
                        Console.WriteLine("Item Vendido\n");
                    }                                    
                                   
                }
            }
        
            
        }
    }
}
