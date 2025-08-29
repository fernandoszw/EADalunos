using System.Data;
using Ead2808.Models;
using Microsoft.Data.SqlClient;
using Ead2808.Data;

namespace Ead2808.Repository
{
    public class AlunoRepository
    {
        public void Add(Aluno aluno)
        {
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Aluno (Nome, Email, DataNascimento) VALUES (@Nome, @Email, @DataNascimento)";
            cmd.AddParameter("@Nome", aluno.Nome);
            cmd.AddParameter("@Email", aluno.Email);
            cmd.AddParameter("@DataNascimento", aluno.DataNascimento);

            cmd.ExecuteNonQuery();
        }
        public List<Aluno> GetAlunos()
        {
            var alunos = new List<Aluno>();
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nome, Email, DataNascimento FROM Aluno";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var aluno = new Aluno
                {
                    IdAluno = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    DataNascimento = reader.GetDateTime(3)
                };
                alunos.Add(aluno);
            }
            return alunos;
        }

        internal IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}