using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.Domain.Entity;
using TesteSenior.Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _usuarioService.GetAllUsuario();
        }


        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _usuarioService.Select(id);
;        }

        // GET api/<UsuarioController>/5
        [HttpPost("login")]
        public UsuarioDTO Login([FromBody] UsuarioDTO value)
        {
            return _usuarioService.GetUsuario(value);


        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] UsuarioDTO value)
        {
            _usuarioService.InsertDTO(value);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public void Put([FromBody] Usuario value)
        {
            _usuarioService.UpdateByDTO(value);
        }


        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _usuarioService.DeleteId(id);
        }
    }
}
