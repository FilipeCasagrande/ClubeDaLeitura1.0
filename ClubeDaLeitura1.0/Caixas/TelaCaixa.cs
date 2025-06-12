using ClubeDaLeitura1._0.Compartilhado;
using Microsoft.Win32;

namespace ClubeDaLeitura1._0.Caixas
{
    public class TelaCaixa : TelaBase
    {
        public TelaCaixa(RepositorioCaixa repositorio) : base("Caixa", repositorio)
        {
        }
        public override void CadastrarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastro de {nomeEntidade}");

            Console.WriteLine();

            Caixa novoRegistro = (Caixa)ObterDados();

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
                Caixa amigoRegistrado = (Caixa)registros[i];

                if (amigoRegistrado == null)
                    continue;

                if (amigoRegistrado.Etiqueta == novoRegistro.Etiqueta)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Esta etiqueta ja foi cadastrada!");
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

            Console.WriteLine("Visualização de Caixas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                "Id", "Etiqueta", "Cor", "Dias de Empréstimo"
            );

            EntidadeBase[] caixas = repositorio.SelecionarRegistros();

            for (int i = 0; i < caixas.Length; i++)
            {
                Caixa c = (Caixa)caixas[i];

                if (c == null)
                    continue;

                Console.WriteLine(
                  "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                    c.Id, c.Etiqueta, c.Cor, c.DiasEmprestimo
                );
            }

            Console.ReadLine();
        }
        protected override EntidadeBase ObterDados()
        {
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Dias de Empréstimo (opcional): ");
            bool conseguiuConverter = int.TryParse(Console.ReadLine(), out int diasEmprestimo);

            Caixa caixa;

            if (conseguiuConverter)
                caixa = new Caixa(etiqueta, cor, diasEmprestimo);
            else
                caixa = new Caixa(etiqueta, cor);

            return caixa;
        }

    }
}
