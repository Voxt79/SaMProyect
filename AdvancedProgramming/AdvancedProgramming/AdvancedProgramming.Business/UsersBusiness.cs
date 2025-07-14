using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;
using AdvanceProgramming.Repository;
////se crea el users bussiness
namespace AdvancedProgramming.Business
{
    public class UsersBusiness
    {
        private readonly RepositoryUsers repositoryUsers;


        public UsersBusiness()
        {
            repositoryUsers = new RepositoryUsers();
        }
        public IEnumerable<Users> Get(int? id)
        {
            var tasks = new List<Users>();
            if (id != null)
                tasks.Add(repositoryUsers.GetById((int)id));

            else tasks.AddRange(repositoryUsers.GetAll());

            return tasks;
        }


        public void Save(int id, Users entity)
        {



            if (id <= 0)
                repositoryUsers.Add(entity);
            else
                repositoryUsers.Update(entity);
        }


        public void Delete(int id)
        {
            repositoryUsers.Delete(id);

        }
    }
}





