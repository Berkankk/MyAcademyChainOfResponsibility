using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.CofR
{
    public class Manager: Employee
    {
        private readonly CoFContext _context;

        public Manager(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CustomerProcessViewModel request)
        {
            if (request.Price <= 250000)
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = " Çağla Kıral - Şube Müdürü ",
                    Description = "Para çekme işlemi başarıyla gerçekleşti , müşteriye para ödendi "
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();

            }
            else if (NextApprover != null)
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = " Çağla Kıral - Şube Müdürü ",
                    Description = "Para çekme işlemi başarısız oldu , müşteri bölge müdürüne yönlendirildi."
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();

                NextApprover.Process(request);
            }

        }
    }
}
