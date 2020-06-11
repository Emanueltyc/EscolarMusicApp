using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolarMusicApp
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Situacao { get; set; }

        public User(int id, string nome, string email, string senha, string situacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Situacao = situacao;
        }

        public User(string nome, string email, string senha, string situacao)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Situacao = situacao;
        }

        public User(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public User(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public User()
        {

        }

        public bool EfetuarLogin(User user)
        {
            bool valido = false;
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "SELECT * FROM tb_usuario WHERE senha_usuario = md5(@senha) AND email_usuario = @email;";

            cmd.Parameters.Add("@senha",MySqlDbType.VarChar).Value = user.Senha;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.Email;

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Situacao = dr.GetString(4);

                valido = true;
            }
            return valido;
        }
    }
}
