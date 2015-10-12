﻿namespace $ModuleNamespace$.DataAccess
{
    using $ModuleNamespace$.Models;
    using Se.Core.DataAccess.Sql;
    using Se.Core.Extensions.IDataRecord;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class $ServiceName$SqlProvider : CrudSqlProvider<$ServiceModelName$, long>, I$ServiceName$Provider
    {
        public $ServiceName$SqlProvider(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }

        protected override $ServiceModelName$ DataRecordToModel(IDataRecord r)
        {
            return new $ServiceModelName$
            {
                $TableColumns: { col 
                | $col.Name$ = r.TryGet<$col.DotNetType$>("$col.Name$");}; separator="\n"$
            };
        }

        protected override string TableName
        {
            get { return "$TableSchema$.$TableName$"; }
        }

        protected override void AddCommonModelParameters(IDbCommand cmd, $ServiceModelName$ model)
        {
            $TableColumns: { col 
            | DataAccessHelper.AddParameter(cmd, "@$col.Name$", model.$col.Name$);}; separator="\n"$
        }
    }
}
