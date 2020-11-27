using MemoriaVirtual.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class RelogioService : ManagementService
    {
        private R<int> R = new R<int>();

        public List<string> FilaControle = new List<string>();

        public RelogioService(List<string> memory)
        {
            Initialize(memory);
        }

        public void AddNewPage(string page)
        {
            if (Memory.Contains("0"))
            {
                FilaControle.Add(page);
            }
            else
            {
                Fila.Add(page);
            }

            ResetBitR();

            var updated = NewPage(()=> 
            {
                OldValue = SecondChance();
                TradingPostion = Memory.IndexOf(OldValue);
                Memory[TradingPostion] = NewValue;                
            },
            page);

            if (updated)
            {
                FilaControle.RemoveAt(0);
                FilaControle.Add(page);
            }

            R.Value.Add(1);
            R.Reset++;
        }

        private string SecondChance()
        {
            foreach (var item in FilaControle.ToArray())
            {
                if (R.Value[Fila.LastIndexOf(item)] == 0)
                {
                    return item;
                }
                else
                {
                    FilaControle.Add(item);
                    FilaControle.RemoveAt(0);
                    R.Value[FilaControle.LastIndexOf(item)] = 0;
                }
            }

            return SecondChance();
        }

        public void ResetBitR()
        {
            if (R.Reset == R<int>.Period)
            {
                R.Value = R.Value.Select(x => x = x == 1 ? 0 : x).ToList();
                R.Reset = 0;
            }
        }
    }
}
