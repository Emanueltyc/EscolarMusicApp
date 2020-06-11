using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolarMusicApp
{
    public class Curso
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public double Valor { get; set; }

        public Curso()
        {
            CargaHoraria = 0;
        }
        public Curso(int id, string nome, int cargaHoraria, double valor)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            Valor = valor;
        }
        public Curso(string nome, int cargaHoraria, double valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            Valor = valor;
        }
        public void Inserir(Curso curso)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_curso values(null, @nome, @carga, @valor);";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = curso.Nome;
            cmd.Parameters.Add("@carga", MySqlDbType.Int32).Value = curso.CargaHoraria;
            cmd.Parameters.Add("@valor", MySqlDbType.Decimal).Value = curso.Valor;

            cmd.ExecuteNonQuery();
        }
        public void Alterar(Curso curso)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_curso set nome_curso=@nome, carga_horaria_curso = @carga, valor_curso=@valor where id_curso =@id";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = curso.Id;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = curso.Nome;
            cmd.Parameters.Add("@carga", MySqlDbType.Int32).Value = curso.CargaHoraria;
            cmd.Parameters.Add("@valor", MySqlDbType.Decimal).Value = curso.Valor;

            cmd.ExecuteNonQuery();
        }
        public List<Curso> ListarTodos()
        {
            List<Curso> cursos = new List<Curso>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_curso ";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cursos.Add(
                    new Curso(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetInt32(2),
                        dr.GetDouble(3)
                        ));
            }
            return cursos;
        }
        public void ObterPorId(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_curso where id_curso = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                CargaHoraria = dr.GetInt32(2);
                Valor = dr.GetDouble(3);
            }
        }
    }
}