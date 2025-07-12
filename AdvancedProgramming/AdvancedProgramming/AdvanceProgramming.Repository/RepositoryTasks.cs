using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;

namespace AdvanceProgramming.Repository
{
    public interface IRepositoryTasks : IRepositoryBase<Tasks>
    {

    }

    public class RepositoryTasks : RepositoryBase<Tasks>, IRepositoryTasks
    {
        public RepositoryTasks() : base()
        {

        }

    }
}
