using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.CofR
{
    public class RegionalManager : Employee
    {
        private readonly CoFContext _context;

        public RegionalManager(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CustomerProcessViewModel request)
        {
            if (request.Price <= 500000)
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = " Berkan Kara - Bölge Müdürü ",
                    Description = "Para çekme işlemi başarıyla gerçekleşti , müşteriye para ödendi "
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();

            }
            else
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = " Berkan Kara - Bölge Müdürü ",
                    Description = "Para çekme işlemi başarısız oldu , müşteriye para ödenemedi "
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();
            }
        }
    }
}
