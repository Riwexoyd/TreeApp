namespace TreeApp.Entities.Services
{
    public interface IConnectionStringResolver
    {
        bool CanResolve();

        string ResolveConnectionString();
    }
}
