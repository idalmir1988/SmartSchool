﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public Aluno() {}

        public Aluno(int id, string nome, string sobreNome, string telefone)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobreNome;
            Telefone = telefone;
        }
    }
}
