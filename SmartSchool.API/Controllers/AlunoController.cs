using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context) 
        {
            _context = context;
        }

        /*
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno()
            {
                Id =  1,
                Nome = "Marcos",
                SobreNome = "Oliveira",
                Telefone =  "123456789"
            },
            new Aluno()
            {
                Id =  2,
                Nome = "Idalmir",
                SobreNome = "Oliveira",
                Telefone =  "7198837-4552"
            },
            new Aluno()
            {
                Id =  3,
                Nome = "Pietro",
                SobreNome = "Jesus",
                Telefone =  "78787878"
            },
        };
        */

        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não foi encontrado");
            }
            return Ok(aluno);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobreNome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.SobreNome.Contains(sobreNome)
            );

            if (aluno == null)
            {
                return BadRequest("Aluno não foi encontrado");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {            
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
