using MemoriaVirtual.Controllers.Base;
using MemoriaVirtual.Model;
using MemoriaVirtual.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Controllers
{
    public class RelogioController : TradingController<Relogio>
    {
        public RelogioController(Relogio service) : base(service)
        {
        }

        public override void Add(string page)
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
