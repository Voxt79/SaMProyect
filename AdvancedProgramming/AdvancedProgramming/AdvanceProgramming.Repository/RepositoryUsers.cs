using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;

namespace AdvanceProgramming.Repository
{
    public interface IRepositoryUsers : IRepositoryBase<Users>
    {

    }

    public class RepositoryUsers : RepositoryBase<Users>, IRepositoryUsers
    {
        public RepositoryUsers() : base()
        {

        }

    }
}
