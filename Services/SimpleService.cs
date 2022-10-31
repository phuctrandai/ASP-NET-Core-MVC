namespace ASP_NET_Core_MVC.Services
{
    public class SimpleService : IScopedService
    {
        private readonly Guid ID;

        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        public SimpleService(ITransientService transientService1, ITransientService transientService2)
        {
            ID = Guid.NewGuid();

            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }

        public Guid GetID()
        {
            return ID;
        }

        public Guid GetChildService1ID()
        {
            return _transientService1.GetID();
        }

        public Guid GetChildService2ID()
        {
            return _transientService2.GetID();
        }
    }
}
