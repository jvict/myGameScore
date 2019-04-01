using Dominio.Dto;
using Modelo;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class LoginNegocio
    {
        private LoginRepositorio _loginRepositorio;

        public LoginNegocio()
        {
            _loginRepositorio = new LoginRepositorio();
        }

        public IEnumerable<LoginDto> SelecionarLogin(string emailJogador, string senhaJogador)
        {
            var obj = _loginRepositorio.SelecionarLogin(emailJogador, senhaJogador);
            if (obj == null)
            {
                throw new Exception("Não Encontrado Login");
            }
            else
            {
                return obj;
            }
        }
    }
}
