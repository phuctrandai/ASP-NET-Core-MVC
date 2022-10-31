namespace ASP_NET_Core_MVC.Services
{
    public class ImplementService : ITransientService, IScopedService, ISingletonService
    {
        private readonly Guid ID;

        public ImplementService()
        {
            ID = Guid.NewGuid();
        }

        public Guid GetChildService1ID()
        {
            throw new NotImplementedException();
        }

        public Guid GetChildService2ID()
        {
            throw new NotImplementedException();
        }

        public Guid GetID()
        {
            return ID;
        }
    }
}
