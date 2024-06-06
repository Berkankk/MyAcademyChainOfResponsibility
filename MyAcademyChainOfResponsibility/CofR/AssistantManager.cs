using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.CofR
{
    public class AssistantManager : Employee
    {
        private readonly CoFContext _context;

        public AssistantManager(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CustomerProcessViewModel request)
        {
            if (request.Price <= 100000)
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Orhan Savaş - Müdür Yardımcısı ",
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
                    EmployeeName = "Orhan Savaş - Müdür Yardımcısı ",
                    Description = "Para çekme işlemi başarısız oldu , müşteri müdüre yönlendirildi."
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();

                NextApprover.Process(request);
            }


        }
    }
}
