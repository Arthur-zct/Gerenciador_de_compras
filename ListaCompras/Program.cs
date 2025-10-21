namespace listacompras;
using System;

public class Program
{
    public static void Main()
    {
        string path = @"C:\Users\Arthur\Documents\c#\Gerenciador_de_compras\ListaCompras\";
        string fileName = "ListaDeCompras.txt";
        string filePath = path + fileName;

        List<string> shoopingList = new List<string>();


        if ( File.Exists(filePath))
        {
            shoopingList.AddRange(File.ReadAllLines(filePath));
        }

        while (true)
        {
            Console.WriteLine("\n === Lista de compras ===");
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item");
            Console.WriteLine("3. Exibir lista");
            Console.WriteLine("4. Completar modificações e exportar lista em .txt");
            Console.WriteLine("5. Limpar lista.");
            Console.Write("Escolha uma opção: ");
            string choiceUser = Console.ReadLine();

            switch(choiceUser)
            {
                case "1":
                    Console.Write("Digite o nome do item para adicionar: ");
                    string itemInsert = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemInsert))
                    {
                        shoopingList.Add(itemInsert);
                        Console.WriteLine($"Item '{itemInsert}' adicionado à lista.");
                    } 
                    else
                    {
                        Console.WriteLine("Item inválido. Tente novamente.");
                    }
                    break;

                case "2": 
                    Console.WriteLine("Digite o nome do item para remover: ");
                    string itemToRemove = Console.ReadLine();
                    if( shoopingList.Remove(itemToRemove) )
                    {
                        Console.WriteLine($"Item '{itemToRemove}' removido da lista.");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{itemToRemove}' não encontrado.");
                    }
                break;

                case "3":
                    Console.WriteLine("\n Itens na sua lista de compras: ");
                    if(shoopingList.Count ==0)
                    {
                        Console.WriteLine("Sua lista de compras está vazia.");
                    }
                    else
                    {
                        for(int i = 0; i < shoopingList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {shoopingList[i]}");
                        }
                    }
                break;

                case "4":
                    File.WriteAllLines(filePath, shoopingList);
                    Console.WriteLine("Lista salva. Saindo do programa...");
                    return;

                case "5":
                    shoopingList.Clear();
                    Console.WriteLine("Lista limpa."); 
                break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                break;
            }
        }
    }
}
