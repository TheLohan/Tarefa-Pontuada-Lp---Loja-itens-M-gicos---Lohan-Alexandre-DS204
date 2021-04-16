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

        public static int VerificarQuantidade()
        {
            Console.WriteLine("Quantos vai querer, Aventureiro!");
            return int.Parse(Console.ReadLine());
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
                int quantidade; 
                if (item.Quantidade <= 1)
                {
                    Console.WriteLine("Mercante: Infelizmente não tenho mais esse item, Aventureiro!\n");
                    Catalogo.Remove(carrinho);
                }
                else if(item.Quantidade > 0)
                {
                    quantidade = VerificarQuantidade();
                    List<Item> listaTemp = new List<Item>();
                    if (quantidade > item.Quantidade)
                    {
                        Console.WriteLine("Não tenho isso tudo, Aventureiro!\n");
                    }
                    else
                    {
                        item.Quantidade = item.Quantidade - quantidade;
                        if (aventureiro.Inventario.Count == 0 && item.Preco < aventureiro.Ouro)
                        {
                            aventureiro.Inventario.Add(Item.CopiaItem(item, quantidade));
                            Console.WriteLine("Item Vendido!\n");
                            aventureiro.Ouro -= item.Preco * quantidade;
                        }
                        else if (aventureiro.Inventario.Count != 0 && item.Preco > aventureiro.Ouro)
                        {
                            Console.WriteLine("Você não tem ouro suficiente, Aventureiro!\n");
                        }
                        else if (aventureiro.Inventario.Count != 0 && item.Preco < aventureiro.Ouro)
                        {
                            foreach (var inventario in aventureiro.Inventario)
                            {
                                if (inventario.Nome == item.Nome)
                                {
                                    inventario.Quantidade += 1*quantidade;
                                }
                                else
                                {
                                    listaTemp.Add(Item.CopiaItem(item, quantidade));

                                }
                            }
                            foreach (var itemTemp in listaTemp)
                            {
                                aventureiro.Inventario.Add(itemTemp);
                            }
                            aventureiro.Ouro -= item.Preco*quantidade;
                            Console.WriteLine("Item Vendido\n");
                        }

                    } 
                                   
                }
            }
        
            
        }
    }
}
