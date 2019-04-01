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

    [Produces("application/json")]
    [Route("api/Jogador")]
    public class JogadorController : Controller
    {

        private JogadorNegocio jogadorNegocio;

        public JogadorController()
        {
            jogadorNegocio = new JogadorNegocio();
        }

        /// <summary>
        /// Método que mostra todas pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return Ok(jogadorNegocio.Selecionar());
        }
        /// <summary>
        /// Método que seleciona um usuario..
        /// </summary>
        /// <param name="idJogador"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetId([FromRoute]int idJogador)
        {
            return Ok(jogadorNegocio.SelecionarPorId(idJogador));
        }


        ///<sumary>
        /// Metodo que insere uma pessoa
        ///</sumary>
        ///<param name="input"></param>
        ///<return></return>
        [HttpPost]
        [ProducesResponseType(typeof(Jogador), 201)]
        [ProducesResponseType(402)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]JogadorInput input)
        {

            var objJogador = new Jogador()
            {
                nomeJogador = input.nomeJogador,
                timeJogador = input.timeJogador,
                emailJogador = input.emailJogador,
                senhaJogador = input.senhaJogador

            };
            
            return CreatedAtRoute("", jogadorNegocio.Inserir(objJogador));
        }


      

 
    }
}