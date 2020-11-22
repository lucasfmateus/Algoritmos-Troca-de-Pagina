using MemoriaVirtual.Controllers;
using MemoriaVirtual.Model;
using MemoriaVirtual.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MemoriaVirtual
{
    class Program
    {
        static void Main(string[] args)
        {

            var entradas = System.IO.File.ReadAllLines(@"entrada.txt");

            #region FIFO

            //var fifo = new FIFOController(new FIFO());

            //fifo.Run(entradas.ToList());

            #endregion FIFO


            #region OTIMO
            //var otimo = new OTIMOController(new OTIMO());

            //otimo.Run(entradas.ToList());

            #endregion OTIMO


            #region LRU
            //var lru = new LRUController(new LRU());

            //lru.Run(entradas.ToList());

            #endregion LRU

            #region Relogio
            //var Relogio = new RelogioController(new Relogio());

            //Relogio.Run(entradas.ToList());

            #endregion Relogio

            #region NRU
            var nru = new NRUController(new NRU());

            var listAcess = new List<Acess>()
            {
                new Acess(entradas[0], "E"),
                new Acess(entradas[1], "L"),
                new Acess(entradas[2], "L"),
                new Acess(entradas[3], "L"),
                new Acess(entradas[4], "L"),
                new Acess(entradas[5], "L"),
                new Acess(entradas[6], "L"),
                new Acess(entradas[7], "L"),
                new Acess(entradas[8], "L"),
                new Acess(entradas[8], "E"),
            };

            nru.Run(listAcess);

            #endregion NRU
        }
    }
}
