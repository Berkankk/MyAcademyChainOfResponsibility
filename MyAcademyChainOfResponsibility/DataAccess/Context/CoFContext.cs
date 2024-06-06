using Microsoft.EntityFrameworkCore;
using MyAcademyChainOfResponsibility.DataAccess.Entities;

namespace MyAcademyChainOfResponsibility.DataAccess.Context
{
    public class CoFContext : DbContext
    {
        //burada base ile yaptığımız sınıfla ilgili yaplıan ayarlama varsa ayarlamaları dahil ettiriyor.
        public CoFContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }



    }
}
