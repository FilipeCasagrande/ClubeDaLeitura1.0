using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Amigo
{
     public class TelaAmigo : TelaBase
    {
    public TelaAmigo(RepositorioBase repositorio) : base("Amigos", repositorio)
        {

        }

        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            Amigos novoRegistro = (Amigos)ObterDados();

            string erros = novoRegistro.Validar();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                CadastrarRegistro();

                return;
            }

            EntidadeBase[] registros = repositorio.SelecionarRegistros();

            for (int i = 0; i < registros.Length; i++)
            {
                Amigos amigoRegistrado = (Amigos)registros[i];

                if (amigoRegistrado == null)
                    continue;

                if (amigoRegistrado.Nome == novoRegistro.Nome || amigoRegistrado.Telefone == novoRegistro.Telefone)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    CadastrarRegistro();
                    return;
                }
            }

            repositorio.CadastrarRegistro(novoRegistro);

            Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
            Console.ReadLine();
        }
        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            if (exibirCabecalho == true)
                ExibirCabecalho();

            Console.WriteLine("Visualização de Amigos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -20}",
                "Id", "Nome", "Responsável", "Telefone"
            );

            EntidadeBase[] amigos = repositorio.SelecionarRegistros();

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigos a = (Amigos)amigos[i];

                if (a == null)
                    continue;

                Console.WriteLine(
                  "{0, -10} | {1, -30} | {2, -30} | {3, -20}",
                    a.Id, a.Nome, a.NomeResponsavel, a.Telefone
                );
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterDados()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável pelo amigo: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo ou responsável: ");
            string telefone = Console.ReadLine();

            Amigos amigo = new Amigos(nome, nomeResponsavel, telefone);

            return amigo;
        }
    }
}
