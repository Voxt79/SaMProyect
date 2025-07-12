using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;

namespace AdvanceProgramming.Repository
{
    public interface IRepositoryNotifications : IRepositoryBase<Notifications>
    {

    }

    public class RepositoryNotifications : RepositoryBase<Notifications>, IRepositoryNotifications
    {
        public RepositoryNotifications() : base()
        {

        }

    }
}
