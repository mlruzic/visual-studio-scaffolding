﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a scaffolding tool.
//     Runtime Version: $Version$
//     Date: $DateTimeNow$
// </auto-generated>
//------------------------------------------------------------------------------
namespace $ModuleNamespace$.Api
{
    using $ModuleNamespace$.Service;
    using Se.Core.Api;
    
    public class $ServiceIoName$ : IoBase
    {
        $TableColumns: {col
        | public $col.DotNetType$ $col.Name$ { get; set; \}}; separator="\n\n"$

        public $ServiceIoName$()
        {
        }

        public $ServiceIoName$($ServiceName$ service)
        {
            var model = service.Model;

            $TableColumns: { col 
            | $col.Name$ = model.$col.Name$;}; separator="\n"$
        }
    }
}
