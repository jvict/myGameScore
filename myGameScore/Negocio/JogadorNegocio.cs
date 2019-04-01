using Modelo;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Dto;
using Dominio;

namespace Negocio
{
    public class JogadorNegocio
    {

        private JogadorRepositorio _jogadorRepositorio;

        public JogadorNegocio()
        {
            _jogadorRepositorio = new JogadorRepositorio();
        }


        public IEnumerable<JogadorModelo> Selecionar()
        {
            return _jogadorRepositorio.Selecionar();
        }

        public JogadorDto SelecionarPorId(int idJogador)
        {
            var obj = _jogadorRepositorio.SelecionarPorId(idJogador);
            if(obj == null)
                throw new Exception("Não Encontrado Id");
            return obj;
        }

        public Boolean Inserir(Jogador entity)
        {
            
            if (entity.emailJogador != null && entity.senhaJogador != null)
            {
                var result = _jogadorRepositorio.Inserir(entity);
                if(result > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("Não foi possivel inserir com dados nulos");
            }
            
        }
    }
}
