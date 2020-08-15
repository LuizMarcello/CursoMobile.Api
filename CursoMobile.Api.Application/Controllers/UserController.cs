using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMobile.Api.Domain.DTO;
using CursoMobile.Api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoMobile.Api.Application.Controllers
{
    //Essa controller vai consumir um serviço, que por sua vêz
    //vai consumir um repositório, para fazer o acesso aos dados.

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser) =>
            _serviceUser = serviceUser;

        //Fazendo os "end-points", 03 para cada um dos métodos da interface "IServiceUser",
        //RecuperarTodos(Get),adicionar(Add) e deletar(delete):
        //Um comentario a toa, testando o git

        //RecuperarTodos(Get)
        [HttpGet]
        public async Task<ActionResult> Recover()
        {
            try
            {
                var datas = await _serviceUser.Get();
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //adicionar(Add)
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] UserDto userDto)
        {
            try
            {
                var data = await _serviceUser.Add(userDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //deletar(delete)
        [HttpDelete]
        [Route("{id}")]
        //public async Task<ActionResult> Remove(string id)
        public ActionResult Remove(string id)
        {
            try
            {
                _serviceUser.Delete(id);
                //await _serviceUser.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}



