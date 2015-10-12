﻿namespace $ModuleNamespace$
{
    using Autofac;
    using Se.Core.Api;
    using DataAccess;
    using Service;
    using Api;

    public class $ModuleName$ : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<$ServiceName$>();
            builder.RegisterType<$ServiceIoName$> ();

            builder.RegisterType<$ServiceName$SqlProvider> ().AsSelf().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<$ServiceName$Repository> ().AsImplementedInterfaces().SingleInstance();
            builder.RegisterController<$ServiceName$Controller> ();
        }
    }
}
