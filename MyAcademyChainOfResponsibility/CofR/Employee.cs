using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.CofR
{
    public abstract class Employee
    {
        //abstract sınıf interface de ki metotları burada dolduracağız. burradan miras alan sınıflarda override ediyoruz.

        protected Employee NextApprover;

        public void SetNextAprover(Employee supervisor)
        {
            this.NextApprover = supervisor;   //ikisini birbirine eşitledik
        }
        public abstract void Process(CustomerProcessViewModel request);
        




    }
}
