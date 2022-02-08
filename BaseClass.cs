using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace GeneralTypeClass
{
    public class BaseClass : AbstractClass
    {
        public int Id { get; set; }

        public int Age { get; set; }
        public int? Sex { get; set; }

        public virtual void Run() {
            Console.WriteLine("Running with two legs");
        }

        public override string GetSexName(int? num)
        {
            return Enum.GetName(typeof(SexType), num);
        }
    }
}
