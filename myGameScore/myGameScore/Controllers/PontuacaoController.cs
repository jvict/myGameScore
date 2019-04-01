using Dominio;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;


namespace myGameScore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Pontuacao")]
    public class PontuacaoController : Controller
    {
        private PontuacaoNegocio pontuacaoNegocio;

        public PontuacaoController()
        {
            pontuacaoNegocio = new PontuacaoNegocio();
        }
        /// <summary>
        /// Método que mostra todas pontuações cadastradas
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(string), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public IActionResult Get()
        //{
        //    return Ok(pontuacaoNegocio.Selecionar());
        //}
        /// <summary>
        /// Insere Pontução do Jogador
        /// </summary>
        /// <param name="input"></param> 
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Pontuacao), 201)]
        [ProducesResponseType(402)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]PontucaoInput input)
        {
            var objPontuacao = new Pontuacao()
            {
                dataPontuacao = input.dataPontuacao,
                pontos = input.pontos
               

            };
            return CreatedAtRoute("", pontuacaoNegocio.Inserir(objPontuacao));
        }
        /// <summary>
        /// Método que mostra tudo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            return pontuacaoNegocio.SelecionarInfo();
        }
    }
}
