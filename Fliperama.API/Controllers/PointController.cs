using Fliperama.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Fliperama.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PointController : ApiController
    {
        // GET: Point
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public object Get()
        {
            var result = CacheModel.Get("pontos");
            return result;
        }

        public Point CreatePoint([FromBody]Point payload)
        {
            var split = payload.Data.Split('/');
            var day = Convert.ToInt32(split[0]);
            var month = Convert.ToInt32(split[1]);
            var year = Convert.ToInt32(split[2]);
            var ponto = new Point() { Jogador = payload.Jogador, Valor = payload.Valor, DataPartida = new DateTime(year, month, day) };
            //CacheModel.Add("9b531ef27e7a421293af292606b2555c", ponto);

            List<Point> cachePontos = CacheModel.Get("pontos") as List<Point>;
            List<Point> pontos = new List<Point>();
            if (cachePontos != null && cachePontos.Count() >= 0)
            {
                pontos = cachePontos;
                pontos.Add(ponto);
            }
            else
            {
                pontos.Add(ponto);
            }
            CacheModel.Remove("pontos");
            CacheModel.Add("pontos", pontos);

            return ponto;
        }

        public object GetById(string id)
        {
            List<Point> pontos = CacheModel.Get("pontos") as List<Point>;
            if (pontos == null)
            {
                return null;
            }
            var pontosJogador = pontos.Where(x => x.Jogador == id).ToList();
            responseResult result = new responseResult();
            var soma = 0;
            var maiorPontuacao = 0;
            var menorPontuacao = int.MaxValue;
            var qtdVezesBateuRecorde = 0;
            var primeiraPartida = DateTime.Now;
            var UltimaPartida = DateTime.Now;
            foreach (var ponto in pontosJogador)
            {
                soma += ponto.Valor;

                if(ponto.Valor > maiorPontuacao)
                {
                    maiorPontuacao = ponto.Valor;
                    qtdVezesBateuRecorde++;
                }
                if (ponto.Valor < menorPontuacao)
                {
                    menorPontuacao= ponto.Valor;
                }
                if(ponto.DataPartida < primeiraPartida)
                {
                    primeiraPartida = ponto.DataPartida;
                }
                if(ponto.DataPartida > UltimaPartida)
                {
                    UltimaPartida = ponto.DataPartida;
                }
            }
            result.Soma = soma;
            result.Pontos = pontosJogador;
            result.PartidasJogadas = pontosJogador.Count();
            result.MediaPontuacao = soma / result.PartidasJogadas;
            result.MaiorPontuacao = maiorPontuacao;
            result.MenorPontuacao = menorPontuacao;
            result.QuantidadeVezesBateuProprioRecorde = qtdVezesBateuRecorde;
            var tempoDeJogoDias = (UltimaPartida - primeiraPartida).TotalDays;            
            result.TempoDeJogo = (int)Math.Round(tempoDeJogoDias);
            result.TempoDeJogoTipo = "dias";
            if (tempoDeJogoDias > 30) {
                var totalMonths = (int)Math.Round(tempoDeJogoDias % 365 / 30);
                result.TempoDeJogo = totalMonths;
                result.TempoDeJogoTipo = "meses";
            }
            return result;
        }

    }
}
