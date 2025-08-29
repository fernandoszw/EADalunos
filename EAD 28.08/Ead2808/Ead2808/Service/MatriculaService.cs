using System;
using Ead2808.Models;
using Ead2808.Repository;
using Microsoft.Identity.Client;

namespace Ead2808.Service
{
    public class MatriculaService
    {
        private readonly MatriculaRepository _matriculaRepository;
        private readonly AlunoRepository _alunoRepository;
        private readonly CursoRepository _cursoRepository;

        public MatriculaService()
        {
            _matriculaRepository = new MatriculaRepository();
            _alunoRepository = new AlunoRepository();
            _cursoRepository = new CursoRepository();
        }
        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1-Cadastrar Aluno");
                Console.WriteLine("2-Cadastrar Curso");
                Console.WriteLine("3-Listar Alunos");
                Console.WriteLine("4-Listar Cursos");
                Console.WriteLine("5-Matricular Aluno em Curso");
                Console.WriteLine("6-Consultar Alunos por Curso");
                Console.WriteLine("7-Consultar Cursos por Aluno");
                Console.WriteLine("0-Sair");

                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        CadastrarAluno();
                        break;
                    case 2:
                        CadastrarCurso();
                        break;
                    case 3:
                        ListarAlunos();
                        break;
                    case 4:
                        ListarCursos();
                        break;
                    case 5:
                        MatricularAluno();
                        break;
                    case 6:
                        ConsultarAlunosPorCurso();
                        break;
                    case 7:
                        ConsultarCursosPorAluno();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Executar();
            }

        }
        public void CadastrarAluno()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar Aluno");

            Aluno aluno = new Aluno();

            Console.Write("Nome: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Email: ");
            aluno.Email = Console.ReadLine();

            _alunoRepository.Add(aluno);
        }
        public void CadastrarCurso()
        {
            Console.Clear();
            Console.WriteLine("Cadastrar Curso");

            Curso curso = new Curso();

            Console.Write("Nome: ");
            curso.NomeCurso = Console.ReadLine();

            _cursoRepository.Add(curso);
        }
        public void ListarAlunos()
        {
            Console.Clear();
            Console.WriteLine("Listar Alunos");

            var alunos = _alunoRepository.GetAlunos();
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.IdAluno}, Nome: {aluno.Nome}, Email: {aluno.Email}");
            }
        }
        public void ListarCursos()
        {
            Console.Clear();
            Console.WriteLine("Listar Cursos");

            var cursos = _cursoRepository.GetCursos();
            foreach (var curso in cursos)
            {
                Console.WriteLine($"ID: {curso.IdCurso}, Nome: {curso.NomeCurso}");
            }
        }
        public void MatricularAluno()
        {
            Console.Clear();
            Console.WriteLine("Matricular Aluno");

            Console.Write("ID do Aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());

            _matriculaRepository.Add(new Matricula { IdAluno = idAluno, IdCurso = idCurso });
        }
        public void ConsultarAlunosPorCurso()
        {
            Console.Clear();
            Console.WriteLine("Consultar Alunos por Curso");

            Console.Write("ID do Curso: ");
            int idCurso = int.Parse(Console.ReadLine());

            var alunos = _matriculaRepository.ObterAlunosDoCurso(idCurso);
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.IdAluno}, Nome: {aluno.Nome}");
            }
        }
        public void ConsultarCursosPorAluno()
        {
            Console.Clear();
            Console.WriteLine("Consultar Cursos por Aluno");

            Console.Write("ID do Aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            var cursos = _matriculaRepository.ObterCursosDoAluno(idAluno);
            foreach (var curso in cursos)
            {
                Console.WriteLine($"ID: {curso.IdCurso}, Nome: {curso.NomeCurso}");
            }
        }
    }
}