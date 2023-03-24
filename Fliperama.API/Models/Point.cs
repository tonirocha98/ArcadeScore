using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fliperama.API.Repositories
{
    public class Point
    {
        public Point()
        {
            Id = Guid.NewGuid().ToString();
        }


        public string Id { get; private set; }
        public string Jogador { get; set; }
        
        public int Valor { get; set; }
        
        public string Data { get; set; }
        public DateTime DataPartida { get; set; }

    }
}

