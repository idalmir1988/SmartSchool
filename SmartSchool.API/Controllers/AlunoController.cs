using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Teste
namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {        
        private readonly IRepository _repo;

        public AlunoController(IRepository repo) 
        {
            _repo = repo;          
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
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null)
            {
                return BadRequest("Aluno não foi encontrado");
            }
            return Ok(aluno);
        }

        //[HttpGet("ByName")]
        //public IActionResult GetByName(string nome, string sobreNome)
        //{
        //    var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => 
        //        a.Nome.Contains(nome) && a.SobreNome.Contains(sobreNome)
        //    );

        //    if (aluno == null)
        //    {
        //        return BadRequest("Aluno não foi encontrado");
        //    }
        //    return Ok(aluno);
        //}

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);            
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Cadastrado");
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var registro = _repo.GetAlunoById(id);
            if (registro == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Cadastrado");
            }
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var registro = _repo.GetAlunoById(id);
            if (registro == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno Cadastrado");
            }
            return BadRequest("Aluno não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }
            return BadRequest("Aluno não deletado");
        }
    }
}
