using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Emprestimo
{
    public class RepositorioEmprestimo : RepositorioBase
    {
        internal Emprestimo[] SelecionarEmprestimosAtivos()
        {
            int contadorEmprestimosDisponiveis = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo EmprestimoAtual = (Emprestimo)registros[i];

                if (registros[i] == null)
                    continue;

                if (EmprestimoAtual.Status == "Aberto" || EmprestimoAtual.Status == "Atrasado")
                    contadorEmprestimosDisponiveis++;
            }

            Emprestimo[] emprestimosDisponiveis = new Emprestimo[contadorEmprestimosDisponiveis];

            int contadorAuxiliar = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo emprestimoAtual = (Emprestimo)registros[i];

                if (emprestimoAtual == null)
                {
                    continue;
                }

                if (emprestimoAtual.Status == "Aberto")
                    emprestimosDisponiveis[contadorAuxiliar++] = (Emprestimo)registros[i];
            }
            return emprestimosDisponiveis;
        }
    }
}
