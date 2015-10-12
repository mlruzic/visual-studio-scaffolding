namespace $ModuleNamespace$.Models
{
    using Se.Core.Models;
    using ShoutEm.Common.Cloning;

    public class $ServiceModelName$ : ModelBase<long>, IShallowCloneable<$ServiceModelName$>
    {
        $TableColumns: {col 
        | public $col.DotNetType$ $col.Name$ { get; set; \}}; separator="\n\n"$

        public $ServiceModelName$ ShallowClone()
        {
            return MemberwiseClone() as $ServiceModelName$;
        }
    }
}
