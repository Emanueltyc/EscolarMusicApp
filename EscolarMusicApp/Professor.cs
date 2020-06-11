using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolarMusicApp
{
    public class Professor
    { // CRC - Colaboração responsabilidade Classe
        public int Id { get; set; } //propriedade
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        public Professor()
        {

        }
        public Professor(string nome, string cpf, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }
        public Professor(int id, string nome, string cpf, string email, string telefone, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }
        public void Inserir(Professor professor)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_professor values(null, @nome_professor, @cpf_professor, @email_professor, @telefone_professor, default);";
            cmd.Parameters.Add("@nome_professor", MySqlDbType.VarChar).Value = professor.Nome;
            cmd.Parameters.Add("@cpf_professor", MySqlDbType.VarChar).Value = professor.Cpf;
            cmd.Parameters.Add("@email_professor", MySqlDbType.VarChar).Value = professor.Email;
            cmd.Parameters.Add("@telefone_professor", MySqlDbType.VarChar).Value = professor.Telefone;
            cmd.ExecuteNonQuery();
        }
        public void Alterar(Professor professor)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_professor set nome_professor=@nome_professor, telefone_professor=@telefone_professor where id_professor=@id_professor";
            cmd.Parameters.Add("@nome_professor", MySqlDbType.VarChar).Value = professor.Nome;
            cmd.Parameters.Add("@id_professor", MySqlDbType.Int32).Value = professor.Id;
            cmd.Parameters.Add("@telefone_professor", MySqlDbType.VarChar).Value = professor.Telefone;
            cmd.ExecuteNonQuery();

        }
        public List<Professor> ListarTodos()
        {
            List<Professor> professores = new List<Professor>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_professor ";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                professores.Add(
                    new Professor(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetDateTime(5)
                        ));
            }
            return professores;
        }
        public void ObterPorId(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_professor where id_professor = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Cpf = dr.GetString(2);
                Email = dr.GetString(3);
                Telefone = dr.GetString(4);
                DataCadastro = dr.GetDateTime(5);
            }
        }
    }
}
