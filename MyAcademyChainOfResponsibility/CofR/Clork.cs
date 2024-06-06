using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.CofR
{
    public class Clork : Employee
    {
        private readonly CoFContext _context;

     

        public Clork(CoFContext context)
        {
            _context = context;
        }

        public override void Process(CustomerProcessViewModel request) // employe sınıfında ki metodumu implement ettim
        {
            if (request.Price<=50000) 
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Cemalettin Altntaş - Gişe Memuru ",
                    Description = "Para çekme işlemi başarıyla gerçekleşti , müşteriye para ödendi "
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();

            }
            else if(NextApprover!=null)
            {
                var custormeProcess = new CustomerProcess
                {
                    Name = request.Name,
                    Price = request.Price,
                    EmployeeName = "Cemalettin Altntaş - Gişe Memuru ",
                    Description = "Para çekme işlemi başarısız oldu , müşteri müdür yardımcısına yönlendirildi."
                };

                _context.Add(custormeProcess);
                _context.SaveChanges();

                NextApprover.Process(request);
            }


        }
    }
}
