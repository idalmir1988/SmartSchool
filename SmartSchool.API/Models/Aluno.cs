using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public Aluno() {}

        public Aluno(int id, int matricula, string nome, string sobreNome, string telefone, DateTime dataNasc)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            SobreNome = sobreNome;
            Telefone = telefone;
            DataNasc = dataNasc;
        }
    }
}
