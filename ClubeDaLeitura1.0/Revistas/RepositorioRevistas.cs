using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Revistas
{
    public class RepositorioRevistas : RepositorioBase
    {
        public Revistas[] SelecionarRevistasDisponiveis()
        {
            int contadorRevistasDisponiveis = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Revistas revistaAtual = (Revistas)registros[i];

                if (registros[i] == null)
                    continue;
                
                if (revistaAtual.Status == "Disponível")
                    contadorRevistasDisponiveis++;
            }

            Revistas[] revistasDisponiveis = new Revistas[contadorRevistasDisponiveis];

            int contadorAuxiliar = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Revistas revistaAtual = (Revistas)registros[i];

                if (revistaAtual == null)
                {
                    continue;
                }
                
                if (revistaAtual.Status == "Disponível")
                    revistasDisponiveis[contadorAuxiliar++] = (Revistas)registros[i];
            }
            return revistasDisponiveis;
        }
    }
}
