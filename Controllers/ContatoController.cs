using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MODULOAPI.Context;
using MODULOAPI.Entities;

namespace MODULOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly  AgendaContext _Context;
        public ContatoController(AgendaContext Context)
        {
            _Context = Context;
        }
        [HttpPost]
        public IActionResult Create(Contatos contato)
        {
            _Context.Add(contato);
            _Context.SaveChanges();
            return Ok(contato);
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _Context.Contatos.Find(id);
            if(contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _Context.Contatos.Where(x => x.Nome.Contains(nome));
            
            return Ok(contatos);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contatos contato)
        {
             var contatoBanco = _Context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();

                contatoBanco.Nome = contato.Nome;
                contatoBanco.Telefone = contato.Telefone;
                contatoBanco.Ativo = contato.Ativo;

                 _Context.Contatos.Update(contatoBanco);
                _Context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
             var contatoBanco = _Context.Contatos.Find(id);

            if(Deletar == null)
                return NotFound();

              _Context.Contatos.Remove(contatoBanco);
              _Context.SaveChanges();

              return NoContent();
        }
    }
}