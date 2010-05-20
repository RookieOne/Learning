using System;
using Conventions.WhatShouldBeRegistered;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.TypeRules;

namespace Conventions.Conventions
{
    public class ControllerConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.CanBeCastTo(typeof (IController)))
                return;

            string name = GetName(type);

            registry.AddType(typeof (IController), type, name);
        }

        static string GetName(Type type)
        {
            return type.Name.Replace("Controller", "");
        }
    }
}