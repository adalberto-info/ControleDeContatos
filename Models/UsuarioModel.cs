using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário.")]
        public String  Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário.")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário.")]
        public String Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetsenhaHash()
        {
            Senha = Senha.GerarHash();
        }
        public string GeraNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha; 
        }
    }
}
