namespace OrderProcessor.Models.Interfaces
{
    public interface ICommissionPayment
    {
        string PayCommissionToAgent(float percentage);
    }
}
