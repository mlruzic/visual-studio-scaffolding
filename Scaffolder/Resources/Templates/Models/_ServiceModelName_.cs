﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a scaffolding tool.
//     Runtime Version: $Version$
//     Date: $DateTimeNow$
// </auto-generated>
//------------------------------------------------------------------------------
namespace $ModuleNamespace$.Models
{
    using Se.Core.Models;
    using ShoutEm.Common.Cloning;

    public class $ServiceModelName$ : ModelBase<long>, IShallowCloneable<$ServiceModelName$>
    {
        $rest(TableColumns): {col 
        | public $col.DotNetType$ $col.Name$ { get; set; \}}; separator="\n\n"$

        public $ServiceModelName$ ShallowClone()
        {
            return MemberwiseClone() as $ServiceModelName$;
        }
    }
}
