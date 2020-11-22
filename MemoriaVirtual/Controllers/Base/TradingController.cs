using MemoriaVirtual.Model;
using MemoriaVirtual.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Controllers.Base
{
    public abstract class TradingController<T> where T : ManagementService
    {
        protected T service { get; set; }

        public TradingController(T service)
        {
            this.service = service;
        }

        public virtual void Run(List<string> entradas)
        {
            service.ExecutionList = entradas.ToList();

            foreach (var item in entradas)
            {
                Add(item);
            }

            service.ViewLog();
        }
        public abstract void Add(string page);
        public abstract List<Page> GetQuadros();
        public abstract List<string> GetMemory();
        public abstract List<string> GetLog();
    }
}
