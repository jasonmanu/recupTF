using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoanService : BaseService<Loan>, ILoanService
    {
        private readonly ILoanRepository loanRepository;
        private readonly ISubscriptionService subscriptionService;
        private readonly ISubscriptionTypeService subscriptionTypeService;

        public LoanService(ILoanRepository loanRepository, ISubscriptionService subscriptionService, ISubscriptionTypeService subscriptionTypeService) : base(loanRepository)
        {
            this.loanRepository = loanRepository;
            this.subscriptionService = subscriptionService;
            this.subscriptionTypeService = subscriptionTypeService;
        }

        public override void Create(Loan entity)
        {
            Subscription userSubscription = subscriptionService.GetAll().FirstOrDefault(x => x.UserId == entity.UserId);

            if (userSubscription == null)
            {
                throw new Exception("Necesitas tener una subscripcion activa para hacer un prestamo de libro");
            }

            SubscriptionType subscriptionType = subscriptionTypeService.GetById(userSubscription.SubscriptionTypeId);
            DateTime endDate = DateTime.Now.AddDays(subscriptionType.LoanDays);

            base.Create(new Loan()
            {
                BookId = entity.BookId,
                StartDate = DateTime.Now,
                EndDate = endDate,
                ReturnDate = null,
                UserId = entity.UserId,
                PuedeRetirar = entity.PuedeRetirar,
            });
        }
    }
}
