using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClubeDaLeitura1._0.Compartilhado;

namespace ClubeDaLeitura1._0.Amigo
{
    public class Amigos : EntidadeBase
    {
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }

        public Amigos(string nome, string nomeResponsavel, string telefone)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
        }

        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Amigos amigoAtualizado = (Amigos)registroAtualizado;

            this.Nome = amigoAtualizado.Nome;
            this.NomeResponsavel = amigoAtualizado.NomeResponsavel;
            this.Telefone = amigoAtualizado.Telefone;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Nome.Length < 3 || Nome.Length > 100)
                erros += "O campo \"Nome\" deve conter entre 3 e 100 caracteres.\n";

            if (NomeResponsavel.Length < 3 || NomeResponsavel.Length > 100)
                erros += "O campo \"Nome do Responsável\" deve conter entre 3 e 100 caracteres.\n";

            if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
                erros += "O campo \"Telefone\" deve seguir o padrão (DDD) 22222-2222.";

            return erros;
        }
    }
}
