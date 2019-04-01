using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Dto;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;

namespace myGameScore.Controllers
{   
    
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private LoginNegocio loginNegocio;

        public LoginController()
        {
            loginNegocio = new LoginNegocio();
        }
        ///<sumary>
        ///Metodo de login no sistema
        ///</sumary>
        ///<returns></returns>
        [HttpGet]
        [Route("{emailJogador}/{senhaJogador}")]
        [ProducesResponseType(typeof(string),200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get([FromRoute]string emailJogador,[FromRoute]string senhaJogador)
        {
            return Ok(loginNegocio.SelecionarLogin(emailJogador,senhaJogador));
        }

    }
}
