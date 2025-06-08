using ClubeDaLeitura1._0.Amigo;
using ClubeDaLeitura1._0.Caixas;
using ClubeDaLeitura1._0.Compartilhado;
using ClubeDaLeitura1._0.Revistas;



namespace ClubeDaLeitura1._0.Emprestimo
{
    public class Emprestimo :EntidadeBase
    {
        public Amigos  Amigo {  get; set; }
        public Revistas.Emprestimo Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Status { get; set; }

        public Emprestimo(Amigos amigo, Revistas.Emprestimo revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
            Status = "Aberto";
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Status = "Concluido";
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Amigo == null)
                erros += "O campo \"Amigo\" é obrigatório!";

            if (Revista == null)
                erros += "O campo \"Emprestimo\" é obrigatório!";

            return erros;
        }
    }
}
