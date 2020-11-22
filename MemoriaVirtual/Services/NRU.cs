using MemoriaVirtual.Interface;
using MemoriaVirtual.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class NRU : Manager
    {

        public List<Acess> FilaControle = new List<Acess>();

        public NRU()
        {
            Initialize();
        }

        public void AddNewPage(Acess acess)
        {

            var rp = FilaControle.Where(x => x.Page == acess.Page).ToList();

            if (rp.Count != 0)
            {
                if (rp.LastOrDefault().M == 1)
                {
                    acess.MovM();
                }
            }

            FilaControle.Add(acess);

            var updated = NewPage(() =>
            {
                var remove = SecondChance();
                OldValue = remove.Page;
                TradingPostion = Memory.IndexOf(OldValue);
                Memory[TradingPostion] = NewValue;
            },
            acess.Page);

            ResetBitR();

        }

        private Acess SecondChance()
        {
            int minClass = int.MaxValue;
            string page = string.Empty;

            foreach (var item in Memory)
            {
                var p = FilaControle.Where(x => x.Page == item).LastOrDefault();

                if (p != null)
                {
                    var s = p.Class;
                    page = s < minClass ? item : page;
                    minClass = s < minClass ? s : minClass;
                }
                else
                {
                    return new Acess(){ Page = item };
                }
            }

            return FilaControle.Where(x => x.Page == page).LastOrDefault();
        }

        public void ResetBitR()
        {
            if (IsDivisible(FilaControle.Count, R<int>.Period))
            {
                foreach (var x in FilaControle.ToArray())
                {
                    x.Atualize();
                }
            }
        }

        public bool IsDivisible(int x, int n)
        {
            return (x % n) == 0;
        }

    }
}
