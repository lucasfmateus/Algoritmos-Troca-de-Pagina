using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Model
{
    public class Acess
    {
        public static Acess CreateFrom(string page, string action)
        {
            return new Acess()
            {
                Action = action,
                Page = page,
                R = 1,
                M = action == "E" ? 1 : 0,
                Class = GetNumberFormBinary(R.ToString() + M.ToString()),
            };
        }


        public string Action { get; set; }
        public string Page { get; set; }
        public int R { get; set; }
        public int M { get; set; }
        public int Class { get; set; }

        private static int GetNumberFormBinary(string rm)
        {
            return Convert.ToInt32(rm, 2); ;
        }

        public void Atualize() 
        {
            R = R == 1 ? 0 : R;
            Class = GetNumberFormBinary(R.ToString() + M.ToString());
        }

        public void MovM()
        {
            M = 1;
            Class = GetNumberFormBinary(R.ToString() + M.ToString());
        }
    }
}
