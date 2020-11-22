using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Model
{
    public class Control
    {
        protected bool State { get; set; }
        protected string Quadro { get; set; }
        protected int SizeAt { get; set; }
        protected int Index { get; set; }
        protected int Count { get; set; }
        protected string NewValue { get; set; }
        protected string OldValue { get; set; }
        protected int TradingPostion { get; set; }


        public void Reset()
        {
            SizeAt = 0;
            Count = 0;
            Index = 0;
        }

        public Page CreateFrom(string item, bool? first = null)
        {
            var o = new Page
            {
                Initial = Index,
                Objective = Quadro == "0" ? "#" : "P",
                Size = Count,
            };

            Count = 1;
            Index = SizeAt;
            State = !State;
            Quadro = item;

            if (first != null)
            {
                o.Objective = Quadro == "0" ? "#" : "P";
            }

            return o;
        }
    }
}
