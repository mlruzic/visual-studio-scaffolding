namespace $ModuleNamespace$.Service
{
    using Core.Repositories;
    using Models;
    using System.Collections.Generic;

    public interface I$ServiceName$Repository :
        ICrudRepository<$ServiceName$, $ServiceModelName$, long>
    {
    }
}
