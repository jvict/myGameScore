using Dominio;
using Dominio.Dto;
using Modelo;
using Modelo.ModelInput;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class PontuacaoNegocio
    {
        private PontuacaoRepositorio _pontuacaoRepositorio;
        
        public PontuacaoNegocio()
        {
            _pontuacaoRepositorio = new PontuacaoRepositorio();
        }

        public IEnumerable<PontuacaoModelo> Selecionar()
        {
            return _pontuacaoRepositorio.Selecionar();
        }
        public Boolean Inserir(Pontuacao entity)
        {
            if(entity.dataPontuacao != null && entity.dataPontuacao != null)
            {
                var result = _pontuacaoRepositorio.Inserir(entity);
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

        public IEnumerable<InfoModelo> SelecionarInfo()
        {
          


            return _pontuacaoRepositorio.SelecionarInfo();

        }

    }
}
