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

            #region FIFO

            Console.WriteLine(" --------------------- FIFO -------------------------");

            var fifoMemory = new List<string>
            {
                "0",
                "0",
                "0"
            };

            var fifoList = new List<string>
            {
                "A2",
                "A3",
                "B2",
                "B3",
                "A1",
                "A2",
                "A3",
                "B2",
                "B1",
                "B3",
                "B2",
                "A3",
            };

            var fifo = new FIFOController(new FIFOService(fifoMemory.ToList()));
            fifo.Run(fifoList.ToList());
            #endregion FIFO

            #region OTIMO
            Console.WriteLine(" --------------------- OTIMO -------------------------");

            var otmMemory = new List<string>
            {
                "B1",
                "0",
                "0"
            };

            var otmList = new List<string>
            {
                "A2",
                "A3",
                "B2",
                "B3",
                "A1",
                "A2",
                "A3",
                "B2",
                "B1",
                "B3",
                "B2",
                "A3",
            };

            var otimo = new OTIMOController(new OTIMOService(otmMemory.ToList()));
            otimo.Run(otmList.ToList());
            #endregion OTIMO

            #region LRU
            Console.WriteLine(" --------------------- LRU -------------------------");

            var lruMemory = new List<string>
            {
                "0",
                "0",
                "0"
            };

            var lruList = new List<string>
            {
                "A1",
                "A2",
                "A3",
                "B2",
                "B3",
                "A1",
                "B2",
                "A3",
                "A2",
                "A1",
            };

            var lru = new LRUController(new LRUService(lruMemory.ToList()));
            lru.Run(lruList.ToList());
            #endregion LRU

            #region Relogio
            Console.WriteLine(" --------------------- Relogio -------------------------");

            var rlgMemory = new List<string>
            {
                "0",
                "0",
                "0"
            };

            var rlgList = new List<string>
            {
                "A1",
                "A2",
                "A3",
                "B2",
                "B3",
                "A1",
                "B2",
                "B3",
                "A2",
                "A1",
            };
            var Relogio = new RelogioController(new RelogioService(rlgMemory.ToList()));
            Relogio.Run(rlgList.ToList());
            #endregion Relogio

            #region NRU
            Console.WriteLine(" --------------------- NRU -------------------------");

            var nruMemory = new List<string>
            {
                "A1",
                "A2",
                "A3"
            };

            var nru = new NRUController(new NRUService(nruMemory.ToList()));
            var nruList = new List<Acess>()
            {
                Acess.CreateFrom("A1", "E"),
                Acess.CreateFrom("A2", "L"),
                Acess.CreateFrom("B1", "L"),
                Acess.CreateFrom("B2", "L"),
                Acess.CreateFrom("B3", "L"),
                Acess.CreateFrom("A1", "L"),
                Acess.CreateFrom("B2", "L"),
                Acess.CreateFrom("B3", "L"),
                Acess.CreateFrom("A2", "L"),
                Acess.CreateFrom("A1", "E"),
            };
            nru.Run(nruList.ToList());
            #endregion NRU

            #region WSClock
            Console.WriteLine(" --------------------- WSClock -------------------------");

            var wsMemory = new List<string>
            {
                "0",
                "0",
                "0"
            };

            var wsList = new List<Acess>()
            {
                Acess.CreateFrom("A1", "E"),
                Acess.CreateFrom("A2", "L"),
                Acess.CreateFrom("B1", "L"),
                Acess.CreateFrom("B2", "L"),
                Acess.CreateFrom("A1", "L"),
                Acess.CreateFrom("A1", "L"),
                Acess.CreateFrom("B2", "L"),
                Acess.CreateFrom("B3", "L"),
                Acess.CreateFrom("A2", "L"),
                Acess.CreateFrom("A1", "E"),
            };                  
            var wsClock = new WSClockController(new WSClockService(wsMemory.ToList(), wsList.ToList()));
            wsClock.Run(wsList.ToList());
            #endregion WSClock
        }
    }
}
