using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Revistas
{
    public class RepositorioRevistas : RepositorioBase
    {
        public EntidadeBase[] SelecionarRevistasDisponiveis()
        {
            int contadorRevistasDisponiveis = 0;


            for (int i = 0; i < registros.Length; i++)
            {
                Revista revistaAtual = (Revista)registros[i];

                if (registros[i] == null)
                    continue;
               
                
                if (revistaAtual.Status == "Disponível")
                    contadorRevistasDisponiveis++;
            }

            EntidadeBase[] revistasDisponiveis = new EntidadeBase[contadorRevistasDisponiveis];

            int contadorAuxiliar = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Revista revistaAtual = (Revista)registros[i];

                if (revistaAtual == null)
                {
                    continue;
                }
                
                if (revistaAtual.Status == "Disponível")
                    revistasDisponiveis[contadorAuxiliar++] = registros[i];
            }
            return revistasDisponiveis;
        }
    }
}
