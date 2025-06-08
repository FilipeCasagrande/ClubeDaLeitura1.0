using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Revistas
{
    public class RepositorioRevistas : RepositorioBase
    {
        public Emprestimo[] SelecionarRevistasDisponiveis()
        {
            int contadorRevistasDisponiveis = 0;


            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo revistaAtual = (Emprestimo)registros[i];

                if (registros[i] == null)
                    continue;
               
                
                if (revistaAtual.Status == "Disponível")
                    contadorRevistasDisponiveis++;
            }

            Emprestimo[] revistasDisponiveis = new Emprestimo[contadorRevistasDisponiveis];

            int contadorAuxiliar = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo revistaAtual = (Emprestimo)registros[i];

                if (revistaAtual == null)
                {
                    continue;
                }
                
                if (revistaAtual.Status == "Disponível")
                    revistasDisponiveis[contadorAuxiliar++] = (Emprestimo)registros[i];
            }
            return revistasDisponiveis;
        }
    }
}
