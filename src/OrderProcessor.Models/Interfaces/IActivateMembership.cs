namespace OrderProcessor.Models.Interfaces
{
    public interface IActivateMembership : INotifyByEmail
    {
        bool ActivateMembership();
    }
}
