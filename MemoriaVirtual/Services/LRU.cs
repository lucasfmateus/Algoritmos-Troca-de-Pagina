using MemoriaVirtual.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoriaVirtual.Services
{
    public class LRU : Manager
    {
        public List<List<string>> Matriz = new List<List<string>>();

        public override void Initialize()
        {
            base.Initialize();

            var l = new List<string>();            
            Memory.ForEach(x => l.Add("0"));
            Memory.ForEach(x => Matriz.Add(l));
        }

        public LRU()
        {
            Initialize();
        }


        public void AddNewPage(string page)
        {
            var index = GetNumberFormBinary(Matriz);
            var i = Memory.IndexOf(ExecutionList.FirstOrDefault());
            
            ManipulaMatriz(i);

            NewPage(() =>
            {
                TradingPostion = index;
                OldValue = Memory[TradingPostion];
                Memory[TradingPostion] = NewValue;
            },
            page);

            if (i == -1)
            {
                ManipulaMatriz(Memory.IndexOf(NewValue));
            }
        }

        private void ManipulaMatriz(int p)
        {
            if (p != -1)
            {
                Matriz[p] = Matriz[p].Select(x => "1").ToList();
                Matriz.ForEach(x => x[p] = "0");
            }
        }

        private int GetNumberFormBinary(List<List<string>> matriz)
        {
            List<int> listP = new List<int>();

            foreach (var array in matriz)
            {
                string result = "";
                int _base = 2;
                for (int i = 0; i < array.Count; i++)
                {
                    int intValue = Convert.ToInt32(array[i], _base);
                    result += intValue.ToString();
                }

                listP.Add(Convert.ToInt32(result, 2));
            }

            return listP.IndexOf(listP.Min());
        }
    }
}
