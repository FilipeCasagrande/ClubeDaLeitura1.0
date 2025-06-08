using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClubeDaLeitura1._0.Caixas;
using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Revistas
{
    public class Revistas : EntidadeBase
    {
        public string Titulo;
        public int NumeroEdicao;
        public int AnoPublicacao;
        public Caixa Caixa;

        public string Status;

        public Revistas(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            AnoPublicacao = anoPublicacao;
            Caixa = caixa;
            Status = "Disponível";
        }


        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Revistas revistaAtualizada = (Revistas)registroAtualizado;

            Titulo = revistaAtualizada.Titulo;
            NumeroEdicao = revistaAtualizada.NumeroEdicao;
            AnoPublicacao = revistaAtualizada.AnoPublicacao;
            Caixa = revistaAtualizada.Caixa;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Titulo.Length < 2 || Titulo.Length > 100)
                erros += "O campo \"Título\" deve conter entre 2 e 100 caracteres.";

            if (NumeroEdicao < 1)
                erros += "O campo \"Número da Edição\" deve conter um valor maior que 0.";

            if (AnoPublicacao < DateTime.MinValue.Year || AnoPublicacao > DateTime.Now.Year)
                erros += "O campo \"Ano de Publicação\" deve conter um valor válido no passado ou presente.";

            if (Caixa == null)
                erros += "O campo \"Caixa\" é obrigatório.";

            return erros;
        }


    }
}
