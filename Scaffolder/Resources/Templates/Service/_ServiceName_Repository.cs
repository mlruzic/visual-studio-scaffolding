namespace $ModuleNamespace$.Service
{
    using Core.Repositories;
    using Models;
    using DataAccess;
    using System.Collections.Generic;

    public class $ServiceName$Repository :
        CrudRepository<$ServiceName$, $ServiceModelName$, long>,
        I$ServiceName$Repository
    {
         private readonly I$ServiceName$Provider provider;

         public $ServiceName$Repository(I$ServiceName$Provider provider)
        {
            this.provider = provider;
        }
    }
}
