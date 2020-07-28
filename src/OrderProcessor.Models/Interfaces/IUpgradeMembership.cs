namespace OrderProcessor.Models.Interfaces
{
    public interface IUpgradeMembership : INotifyByEmail
    {
        bool UpgradeMembership();
    }
}
