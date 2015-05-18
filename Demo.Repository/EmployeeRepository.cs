using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Entity;
using Demo.IRepository;
using System.Data.Entity;

namespace Demo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DemoContext demoContext = new DemoContext();

        public IEnumerable<Employee> GetAll()
        {
            return demoContext.Employees;
        }

        public Employee GetById(int id)
        {
            return demoContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
        }

        public void Add(Employee employee)
        {
            demoContext.Employees.Add(employee);
            demoContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            demoContext.Entry(employee).State = EntityState.Modified;
            demoContext.SaveChanges();
        }

        public void Delete(int id) 
        {
            Employee employee = demoContext.Employees.Find(id);
            demoContext.Employees.Remove(employee);
            demoContext.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (demoContext != null)
                {
                    demoContext.Dispose();
                    demoContext = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


    public class DemoContext : DbContext 
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
