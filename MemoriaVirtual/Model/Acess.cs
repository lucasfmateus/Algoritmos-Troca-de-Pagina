using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriaVirtual.Model
{
    public class Acess
    {
        public static Acess CreateFrom(string page, string action)
        {
            var r = 1;
            var m = action == "E" ? 1 : 0;
            return new Acess()
            {
                Action = action,
                Page = page,
                R = r,
                M = m,
                Class = GetNumberFormBinary(r.ToString() + m.ToString()),
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

        public void SetM(int value)
        {
            M = value;
            Class = GetNumberFormBinary(R.ToString() + M.ToString());
        }

        public void SetR(int value)
        {
            R = value;
            Class = GetNumberFormBinary(R.ToString() + M.ToString());
        }
    }
}
