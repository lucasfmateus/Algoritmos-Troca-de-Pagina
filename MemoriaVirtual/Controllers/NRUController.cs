using MemoriaVirtual.Controllers.Base;
using MemoriaVirtual.Model;
using MemoriaVirtual.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Controllers
{
    public class NRUController : TradingController<NRU>
    {
        public NRUController(NRU service) : base(service)
        {
        }

        public void Run(List<Acess> entradas)
        {
            tradingService.ExecutionList = entradas.Select(x => x.Page).ToList();

            foreach (var item in entradas)
            {
                Add(item);
            }

            tradingService.ViewLog();
        }
        public override void Add(string page)
        {
            throw new NotImplementedException();
        }
        public void Add(Acess page)
        {
            tradingService.AddNewPage(page);
        }

        public override List<string> GetLog()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetMemory()
        {
            throw new NotImplementedException();
        }

        public override List<Page> GetQuadros()
        {
            throw new NotImplementedException();
        }
    }
}
