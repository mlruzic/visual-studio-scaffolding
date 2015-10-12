namespace $ModuleNamespace$.Service
{
    using Core.Repositories;
    using Models;
    
    public interface I$ServiceName$Repository :
        ICrudRepository<$ServiceName$, $ServiceModelName$, long>
    {
    }
}
