using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralTypeClass
{
    public class CRUD<TFirst> : ICRUD<TFirst> where TFirst : BaseClass
    {

        public List<TFirst> FirstList { get; set; }
        public CRUD()
        {
            this.FirstList = new List<TFirst>();
        }

        public ICollection<TFirst> Read()
        {
            return FirstList;
        }

        public TFirst Create(TFirst entity)
        {
            FirstList.Add(entity);
            return entity;
        }
        public TFirst Update(TFirst n)
        {
            FirstList[n.Id] = n;
            return n;
        }
        public bool Delete(int id)
        {
            var deleted = GetById(id);
            if (deleted == null)
            {
                return false;
            }

            FirstList.Remove(deleted);
            return true;
        }
        public TFirst GetById(int id)
        {
            var entity = FirstList.FirstOrDefault(l => l.Id == id);
            return entity;
        }

        public int ListLength() => FirstList.Count;
    }
}
