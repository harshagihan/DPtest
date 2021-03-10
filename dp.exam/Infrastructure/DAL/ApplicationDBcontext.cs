using dp.exam.Models.DbEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dp.exam.Infrastructure.DAL
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeFamily> EmployeeFamilies { get; set; }
    }
}
