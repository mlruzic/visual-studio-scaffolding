// Guids.cs
// MUST match guids.h
using System;

namespace VSPackage.ScaffolderPackage
{
    static class GuidList
    {
        public const string guidSkafolderPkgString = "5ba0db21-702d-4787-811b-055b9240898d";
        public const string guidSkafolderCmdSetString = "02d4f19c-3df3-4c21-a6f1-c606a36aba2f";
        public const string guidToolWindowPersistanceString = "154f3126-7a36-4a4d-936c-89454908cc8e";

        public static readonly Guid guidSkafolderCmdSet = new Guid(guidSkafolderCmdSetString);
    };
}