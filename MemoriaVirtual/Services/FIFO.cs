﻿using MemoriaVirtual.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class FIFO : Manager
    {
        public FIFO()
        {
            Initialize();
        }

        public void AddNewPage(string page)
        {

            NewPage(() => 
                {
                    OldValue = Fila.FirstOrDefault();
                    TradingPostion = Memory.IndexOf(OldValue);
                    Memory[TradingPostion] = NewValue;
                    Fila.Add(NewValue);
                    Fila.RemoveAt(0);
                },
                page);
        }

    }
}