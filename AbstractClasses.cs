using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralTypeClass
{

    public abstract class AbstractClass
    {
        public abstract string GetSexName(int? num);

    }

    public abstract class DogYears
    {
        public abstract string CalculateDogYears(int year);
    }

    public class DogHelper : DogYears
    {
        public override string CalculateDogYears(int year)
        {
            return year switch
            {
                1 => "15 Human Years",
                2 => "24 Human Years",
                3 => "28 Human Years",
                4 => "32 Human Years",
                5 => "36 Human Years",
                6 => "40 Human Years",
                _ => "No accepted value",
            };
        }
    }
}
