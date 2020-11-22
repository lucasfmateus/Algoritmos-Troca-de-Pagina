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
            //var fifo = new FIFOController(new FIFOService());
            //fifo.Run(entradas.ToList());
            #endregion FIFO

            #region OTIMO
            //var otimo = new OTIMOController(new OTIMOService());
            //otimo.Run(entradas.ToList());
            #endregion OTIMO

            #region LRU
            //var lru = new LRUController(new LRUService());
            //lru.Run(entradas.ToList());
            #endregion LRU

            #region Relogio
            //var Relogio = new RelogioController(new RelogioService());
            //Relogio.Run(entradas.ToList());
            #endregion Relogio

            #region NRU
            var nru = new NRUController(new NRUService());
            var listAcess = new List<Acess>()
            {
                Acess.CreateFrom(entradas[0], "E"),
                Acess.CreateFrom(entradas[1], "L"),
                Acess.CreateFrom(entradas[2], "L"),
                Acess.CreateFrom(entradas[3], "L"),
                Acess.CreateFrom(entradas[4], "L"),
                Acess.CreateFrom(entradas[5], "L"),
                Acess.CreateFrom(entradas[6], "L"),
                Acess.CreateFrom(entradas[7], "L"),
                Acess.CreateFrom(entradas[8], "L"),
                Acess.CreateFrom(entradas[8], "E"),
            };
            nru.Run(listAcess);
            #endregion NRU

            #region WSClock
            var wsClock = new WSClockController(new WSClockService());
            wsClock.Run(entradas.ToList());
            #endregion WSClock
        }
    }
}
