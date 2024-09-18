using CrudDapper.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CrudDapper
{
    public class Program
    {
        const string connectionString = @"Data Source=DESKTOP-2N71M20\SQLEXPRESS;Initial Catalog=EstudoIT4;Integrated Security=True;Trust Server Certificate=True";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                LoadScreean(connection);
            }
        }

        static void LoadScreean(SqlConnection connection)
        {
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("SEJA BEM VINDO AO SISTEMA CRUD DAPPER");
            Console.WriteLine("=====================================================");
            Console.WriteLine("");
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Listar todos.");
            Console.WriteLine("2 - Listar único.");
            Console.WriteLine("3 - Cadastrar.");
            Console.WriteLine("4 - Atualizar.");
            Console.WriteLine("5 - Deletar.");
            Console.WriteLine("6 - Sair.");

            int selectOption = int.Parse(Console.ReadLine());

            switch (selectOption)
            {
                case 1: ListAllUser(connection); break;
                case 2: GetUser(connection); break;
                case 3: CreateUser(connection); break;
                case 4: UpdateUser(connection); break;
                case 5: DeleteUser(connection); break;
                case 6: System.Environment.Exit(0); break;
                default: LoadScreean(connection); break;
            }
        }
        static void ListAllUser(SqlConnection connection)
        {
            Console.Clear();
            var usuarios = connection.GetAll<Usuario>();

            Console.WriteLine("Lista de todos os usuarios:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Id - {usuario.Id} | Nome - {usuario.Nome} | Email - {usuario.Email}");
                Console.WriteLine("---------------------------------------------------------------------");
            }

            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Voltar ao menu principal.");
            Console.WriteLine("2 - Finalizar a aplicação.");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: LoadScreean(connection); break;
                case 2: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }

        }
        static void GetUser(SqlConnection connection)
        {
            Console.Clear();

            Console.Write("Digite o id do usuario que deseja buscar: ");
            int idUser = int.Parse(Console.ReadLine());

            var user = connection.Get<Usuario>(idUser);

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Id - {user.Id} | Nome - {user.Nome} | Email - {user.Email}");
            Console.WriteLine("---------------------------------------------------------------------");

            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Voltar ao menu principal.");
            Console.WriteLine("2 - Finalizar a aplicação.");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: LoadScreean(connection); break;
                case 2: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }

        }
        static void CreateUser(SqlConnection connection)
        {
            Console.Clear();
            var user = new Usuario();

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Cadastro de usuario!");
            Console.WriteLine("-------------------------------------------");

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();

            user.Nome = nome;
            user.Email = email;

            var rowsAffected = connection.Insert<Usuario>(user);

            if (rowsAffected < 1)
                Console.WriteLine("Ocorreu um erro ao cadastrar");

            Console.WriteLine("Usuario cadastrado com sucesso!");

            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Voltar ao menu principal.");
            Console.WriteLine("2 - Finalizar a aplicação.");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: LoadScreean(connection); break;
                case 2: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }
        }
        static void UpdateUser(SqlConnection connection)
        {
            var user = new Usuario();

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Atualização de usuario!");
            Console.WriteLine("-------------------------------------------");

            Console.Write("Digite o id do usuario: ");
            int idUser = int.Parse(Console.ReadLine());

            var userUpadte = connection.Get<Usuario>(idUser);

            Console.WriteLine("Usuario encontrado:");
            Console.WriteLine($"Id: {userUpadte.Id} | Nome: {userUpadte.Nome} | Email: {userUpadte.Email}");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("O que deseja atualizar?");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - Email");

            var optionUpdate = int.Parse(Console.ReadLine());

            switch (optionUpdate)
            {
                case 1:
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    userUpadte.Nome = nome;
                    connection.Update<Usuario>(userUpadte);
                    break;
                case 2:
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    userUpadte.Email = email;
                    connection.Update<Usuario>(userUpadte);
                    break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }

            Console.WriteLine("Usuario atualizado com sucesso!");
            Console.WriteLine("----------------------------------------------------");


            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Voltar ao menu principal.");
            Console.WriteLine("2 - Finalizar a aplicação.");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: LoadScreean(connection); break;
                case 2: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }
        }
        static void DeleteUser(SqlConnection connection)
        {
            Console.Clear();

            Console.Write("Digite o id do usuario que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());

            var DeleteUser = connection.Get<Usuario>(id);
            Console.WriteLine("Usuario encontrado:");
            Console.WriteLine($"Id: {DeleteUser.Id} | Nome: {DeleteUser.Nome} | Email: {DeleteUser.Email}");
            Console.WriteLine("-------------------------------------------");


            Console.WriteLine($"Deseja realmente excluir o usuario  {DeleteUser.Nome} ?");
            Console.WriteLine("1 - Sim, desejo excluir");
            Console.WriteLine("2 - Não, quero manter esse usuario.");

            int optionDeleted = int.Parse(Console.ReadLine());

            switch(optionDeleted)
            {
                case 1: 
                    connection.Delete<Usuario>(DeleteUser); 
                    Console.WriteLine("Usuario deletado com sucesso!");
                    Console.WriteLine("----------------------------------------------------");
                    break;

                case 2: Console.WriteLine("Operação cancelada, voltando para o menu principal...");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }



            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Voltar ao menu principal.");
            Console.WriteLine("2 - Finalizar a aplicação.");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: LoadScreean(connection); break;
                case 2: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Opção invalida, estamos voltando para o menu principal");
                    Thread.Sleep(2500);
                    LoadScreean(connection);
                    break;
            }


        }   
    
    }
}
