using MemoriaVirtual.Controllers.Base;
using MemoriaVirtual.Model;
using MemoriaVirtual.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Controllers
{
    public class WSClockController : TradingController<WSClockService>
    {
        public WSClockController(WSClockService service) : base(service)
        {
        }

        public void Run(List<Acess> entradas)
        {
            service.ExecutionList = entradas.Select(x => x.Page).ToList();
            foreach (var item in entradas)
            {
                Add(item);
            }

            service.ViewLog();
        }

        public void Add(Acess page)
        {
            service.AddNewPage(page);
        }

        public override void Add(string page)
        {
            throw new NotImplementedException();
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
