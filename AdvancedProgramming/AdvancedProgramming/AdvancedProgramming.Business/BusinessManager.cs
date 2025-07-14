using AdvancedProgramming.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Business
{
    public class BusinessManager<T> where T : class, IEntityBase, new()
    {
        public T GetEntityBaseObject()
        {
            return new T();
        }
           
    }
}
