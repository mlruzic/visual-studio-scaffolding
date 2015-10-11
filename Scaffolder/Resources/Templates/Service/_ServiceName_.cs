namespace $ModuleNamespace$.Service
{
    using Api;
    using Models;
    using Se.Core.Service;
    using ShoutEm.Common.Cloning;

    public class $ServiceName$ : ServiceBase<$ServiceModelName$>,
        IUpdatable<$ServiceIoName$>, IShallowCloneable<$ServiceName$>
    {
        public $ServiceName$()
        {
            this.Model = new $ServiceModelName$();
        }

        public $ServiceName$($ServiceModelName$ model)
        {
            this.Model = model;
        }

        public void Update($ServiceIoName$ io)
        {
            $TableColumns: { col 
            | Model.$col.Name$ = io.$col.Name$;}; separator = "\n"$
        }

        public $ServiceName$ ShallowClone()
        {
            var clone = MemberwiseClone() as $ServiceName$;
            if (clone == null)
            {
                return null;
            }
            clone.Model = Model.ShallowClone();
            return clone;
        }
    }
}
