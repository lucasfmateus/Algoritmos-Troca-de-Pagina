using MemoriaVirtual.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class WSClockService : ManagementService
    {
        private List<Acess> Pages { get; set; }
        public int K { get; private set; } = 2;
        private List<WSClockTable> Table { get; set; } = new List<WSClockTable>();

        public List<Acess> FilaControle = new List<Acess>();

        public WSClockService(List<Acess> acess)
        {
            Initialize();
            Pages = acess;
            var l = Pages.Select(x => x.Page).ToList();
            Table = l.Concat(Memory.Where(x => x != "0").ToList()).ToList().Distinct().Select(x => WSClockTable.CreateFrom(x)).ToList();
        }


        public void AddNewPage(Acess acess)
        {
            var t = new Acess();
            var rp = FilaControle.Where(x => x.Page == acess.Page).ToList();

            if (rp.Count != 0)
            {
                if (rp.LastOrDefault().M == 1)
                {
                    acess.MovM();
                }
            }

            FilaControle.Add(acess);


            NewPage(() =>
            {
                t = ValidTrade();
                OldValue = t.Page;
                TradingPostion = Memory.IndexOf(OldValue);
                Memory[TradingPostion] = NewValue;
            },
            acess.Page);

            foreach (var x in Table.ToArray ())
            {
                if (x.Page == t.Page) { x.Reset(); }
            }

            foreach (var item in Table.ToArray())
            {

                if (acess.Page == item.Page)
                {
                    item.Reset();
                }

                if (Memory.Contains(item.Page))
                {
                    item.Update();
                }

            }



            ResetBitR();
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

        public Acess ValidTrade(Acess acess = null)
        {
            var r = new Acess();

            foreach (var item in Fila.ToArray())
            {
                r = FilaControle.Where(x => x.Page == item).LastOrDefault();

                if (r.R == 1)
                {
                    r.SetR(0);
                }
                else
                {
                    if (Table.Where(x => x.Page == r.Page).Select(x => x.Count).FirstOrDefault() >= K)
                    {
                        if (r.M == 1)
                        {
                            r.SetM(0);
                            Fila.Add(Fila.FirstOrDefault());
                            Fila.RemoveAt(0);
                        }
                        else
                        {
                            return r;
                        }
                    }
                }
            }

            return ValidTrade(r);
        }
    }
}
