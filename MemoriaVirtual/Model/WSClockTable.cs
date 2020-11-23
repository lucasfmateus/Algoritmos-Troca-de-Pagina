using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Model
{
    public class WSClockTable 
    {
        public string Page { get; set; }
        public int Count { get; set; }

        public static WSClockTable CreateFrom(string page)
        {
            return new WSClockTable()
            {
                Page = page,
                Count = 0
            };
        }

        public void Update()
        {
            ++Count;
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}
