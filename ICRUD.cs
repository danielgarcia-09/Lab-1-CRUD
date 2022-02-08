using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralTypeClass
{
    public interface ICRUD<TFirst> where TFirst : BaseClass
    {

        ICollection<TFirst> Read();

        TFirst Create(TFirst entity);

        TFirst Update(TFirst n);

        bool Delete(int id);

        TFirst GetById(int id);
    }
}
