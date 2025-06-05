using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Caixas
{
    public class Caixa : EntidadeBase
    {
        public string Etiqueta;
        public string Cor;
        public int DiasEmprestimo;

        public Caixa(string etiqueta, string cor)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = 7;
        }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Caixa caixaAtualizada = (Caixa)registroAtualizado;

            this.Etiqueta = caixaAtualizada.Etiqueta;
            this.Cor = caixaAtualizada.Cor;
            this.DiasEmprestimo = caixaAtualizada.DiasEmprestimo;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (string.IsNullOrWhiteSpace(Etiqueta) || Etiqueta.Length > 50)
                erros += "O campo \"Etiqueta\" é obrigatório e recebe no máximo 50 caracteres.";

            if (string.IsNullOrWhiteSpace(Cor))
                erros += "O campo \"Cor\" é obrigatório.";

            if (DiasEmprestimo < 1)
                erros += "O campo \"Dias de Empréstimo\" deve conter um valor maior que 0.";

            return erros;
        }



    }
}
