using MemoriaVirtual.Controllers.Base;
using MemoriaVirtual.Model;
using MemoriaVirtual.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoriaVirtual.Controllers
{
    public class FIFOController : TradingController<FIFOService>
    {
        public FIFOController(FIFOService service) : base(service)
        {
        }

        public override void Add(string page)
        {
            tradingService.AddNewPage(page);
        }

        public override List<Page> GetQuadros()
        {
            return tradingService.Quadros;
        }

        public override List<string> GetMemory()
        {
            return tradingService.Memory;
        }

        public override List<string> GetLog()
        {
            return tradingService.Log;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
