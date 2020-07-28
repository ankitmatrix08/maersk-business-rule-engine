using OrderProcessor.Models;
using OrderProcessor.Models.Implementations;
using OrderProcessor.Models.Interfaces;
using OrderProcessor.Models.Models;

namespace OrderProcessor.Domain
{
    public class OrderFacade
    {
        private Order order;
        protected IProcessesFacade facadeProcessor;
        public OrderFacade(Order _order)
        {
            order = _order;
            PrepareObject(order.OrderType);
        }

        public void StartProcessing()
        {
            if (facadeProcessor != null)
                facadeProcessor.Process();
        }

        private void PrepareObject(OrderItem orderItem)
        {
            IProcessesFacade value = orderItem switch
            {
                OrderItem.Book => new BookOrder(order),
                OrderItem.PhysicalProduct => new PhysicalProductOrder(order),
                OrderItem.ActivateMembership => new ActivateMembershipOrder(order),
                OrderItem.UpgradeMembership => new UpgradeMembershipOrder(order),
                OrderItem.LearningVideo => new LearnVideo(order),
                _ => null,
            };
            facadeProcessor = value;
        }
    }
}
