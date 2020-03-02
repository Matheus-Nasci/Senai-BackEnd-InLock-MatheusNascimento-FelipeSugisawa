using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Interface;
using Senai.InLock.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[Controller]")]

    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            //Status Code - 200 
            return Ok(_jogosRepository.Listar());
        }
    }
}
