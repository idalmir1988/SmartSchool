using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null)
            {
                return BadRequest("Professor não localizado");
            }
            return Ok(professor);
        }

        //[HttpGet("ByName")]
        //public IActionResult getByName(string nome)
        //{
        //    var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
        //    if (professor == null)
        //    {
        //        return BadRequest("Professor não localizado");
        //    }
        //    return Ok(professor);
        //}

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Cadastrado");
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var registro = _repo.GetProfessorById(id);
            if (registro == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Cadastrado");
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var registro = _repo.GetProfessorById(id);
            if (registro == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Cadastrado");
            }
            return BadRequest("Professor não cadastrado");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor Cadastrado");
            }
            return BadRequest("Professor não cadastrado");
        }
    }
}
