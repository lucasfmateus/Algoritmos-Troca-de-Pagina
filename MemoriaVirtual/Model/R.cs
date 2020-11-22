using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Model
{
    public class R<T>
    {
        public const int Period = 3;
        public List<T> Value { get; set; } = new List<T>();
        public int Reset { get; set; } = 0;
    }
}
