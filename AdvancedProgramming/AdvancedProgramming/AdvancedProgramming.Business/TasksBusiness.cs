using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedProgramming.Data;
using AdvanceProgramming.Repository;


namespace AdvancedProgramming.Business
{
    public class TasksBusiness
    {
        private readonly RepositoryTasks repositoryTasks;


        public TasksBusiness()
        {
            repositoryTasks = new RepositoryTasks();
        }
        public IEnumerable<Tasks> Get(int? id)
        {
            var tasks = new List<Tasks>();
            if (id != null)
                tasks.Add(repositoryTasks.GetById((int)id)); 

            else tasks.AddRange(repositoryTasks.GetAll());

            return tasks;
        }


        public void Save(int id, Tasks entity) 
        {
          


            if (id <= 0)
                repositoryTasks.Add(entity);
            else
                repositoryTasks.Update(entity);
        }


        public void Delete(int id)
        {
            repositoryTasks.Delete(id);

        }
    }
}



