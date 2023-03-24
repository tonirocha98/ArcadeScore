using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace Fliperama.API.Repositories
{
    public class CacheModel
    {
        private static Cache _cache = null;
        private static Cache cache
        {

            get
            {

                if (_cache == null)
                    _cache = (System.Web.HttpContext.Current == null) ? System.Web.HttpRuntime.Cache : System.Web.HttpContext.Current.Cache;

                return _cache;
            }
            set
            {
                _cache = value;
            }


        }

        public static object Get(string key)
        {
            return cache.Get(key);
        }

        public static void Add(string key, object value)
        {
            //CacheItemPriority priority = CacheItemPriority.NotRemovable;
            //var expiration = TimeSpan.FromMinutes(10);
            cache.Insert(key, value);
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }



    }

    public class responseResult
    {
        public int Soma { get; set; }
        public int PartidasJogadas { get; set; }
        public float MediaPontuacao { get; set; }
        public int MaiorPontuacao { get; set; }
        public int MenorPontuacao { get; set; }
        public int QuantidadeVezesBateuProprioRecorde { get; set; }
        public double TempoDeJogo{ get; set; }
        public string TempoDeJogoTipo { get; set; }
        public List<Point> Pontos { get; set; }
    }
}