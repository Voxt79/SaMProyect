using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;

namespace AdvanceProgramming.Repository
{
    public interface IRepositoryTaskLogs : IRepositoryBase<TaskLogs>
    {

    }

    public class RepositoryTaskLogs : RepositoryBase<TaskLogs>, IRepositoryTaskLogs
    {
        public RepositoryTaskLogs() : base()
        {

        }

    }
}
