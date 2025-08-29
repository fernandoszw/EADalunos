using System.Data;
using Ead2808.Models;
using Microsoft.Data.SqlClient;
using Ead2808.Data;

namespace Ead2808.Repository
{
    public class MatriculaRepository
    {
        public void Add(Matricula matricula)
        {
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Matricula (IdAluno, IdCurso, DataMatricula) VALUES (@IdAluno, @IdCurso, @DataMatricula)";
            cmd.AddParameter("@IdAluno", matricula.IdAluno);
            cmd.AddParameter("@IdCurso", matricula.IdCurso);
            cmd.AddParameter("@DataMatricula", matricula.DataMatricula);
            cmd.ExecuteNonQuery();
        }
        public List<Curso> ObterCursosDoAluno(int idAluno)
        {
            var cursos = new List<Curso>();
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nome FROM Curso WHERE IdAluno = @IdAluno";
            cmd.AddParameter("@IdAluno", idAluno);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var curso = new Curso
                {
                    IdCurso = reader.GetInt32(0),
                    NomeCurso = reader.GetString(1)
                };
                cursos.Add(curso);
            }
            return cursos;
        }
        public List<Aluno> ObterAlunosDoCurso(int idCurso)
        {
            var alunos = new List<Aluno>();
            using var conn = Db.GetConnection();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT a.Id, a.Nome FROM Aluno a INNER JOIN Matricula m ON a.Id = m.IdAluno WHERE m.IdCurso = @IdCurso";
            cmd.AddParameter("@IdCurso", idCurso);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var aluno = new Aluno
                {
                    IdAluno = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };
                alunos.Add(aluno);
            }
            return alunos;
        }
    }
}