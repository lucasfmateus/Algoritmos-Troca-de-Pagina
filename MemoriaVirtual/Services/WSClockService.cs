﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class WSClockService : ManagementService
    {
        public WSClockService()
        {
            Initialize();
        }


        public void AddNewPage(string page)
        {
            NewPage(() =>
            {
                OldValue = SecondChance();
                TradingPostion = Memory.IndexOf(OldValue);
                Memory[TradingPostion] = NewValue;
            },
            page)
        }
    }
}
