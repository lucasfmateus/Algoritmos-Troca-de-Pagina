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
            service.AddNewPage(page);
        }

        public override List<Page> GetQuadros()
        {
            return service.Quadros;
        }

        public override List<string> GetMemory()
        {
            return service.Memory;
        }

        public override List<string> GetLog()
        {
            return service.Log;
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
