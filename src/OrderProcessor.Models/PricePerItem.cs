using OrderProcessor.Models;

namespace OrderProcessor.Domain
{
    public class PricePerItem
    {
        public double GetPrice(OrderItem item)
        {
            var value = item switch
            {
                OrderItem.Book => 100.00,
                OrderItem.PhysicalProduct => 500.00,
                OrderItem.ActivateMembership => 999.00,
                OrderItem.UpgradeMembership => 1499.00,
                OrderItem.LearningVideo => 299.00,
                _ => 0.00,
            };
            return value;
        }
    }
}
