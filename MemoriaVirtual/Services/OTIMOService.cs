using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class OTIMOService : ManagementService
    {
        public OTIMOService()
        {
            Initialize();
        }

        public void AddNewPage(string page)
        {
            var position = Memory.Select(x => ExecutionList.IndexOf(x)).ToList();

            NewPage(() =>
            {
                var p = position.FindIndex(x => x == -1);
                TradingPostion = p == -1 ? Memory.IndexOf(ExecutionList[position.Max()]) : p;
                Memory[TradingPostion] = NewValue;
                OldValue = Fila[TradingPostion];
            },
            page);
        }
    }
}
