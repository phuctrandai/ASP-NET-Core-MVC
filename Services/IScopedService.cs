namespace ASP_NET_Core_MVC.Services
{
    public interface IScopedService
    {
        Guid GetID();
        Guid GetChildService1ID();
        Guid GetChildService2ID();
    }
}
