// Guids.cs
// MUST match guids.h
using System;

namespace Company.VSMyskin
{
    static class GuidList
    {
        public const string guidVSMyskinPkgString = "fa0efca9-94d5-493b-bb21-0d6137772dd4";
        public const string guidVSMyskinCmdSetString = "18955626-8fa2-439c-a5ae-b2a712eda545";

        public static readonly Guid guidVSMyskinCmdSet = new Guid(guidVSMyskinCmdSetString);
    };
}