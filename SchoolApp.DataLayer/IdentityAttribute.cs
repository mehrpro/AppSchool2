﻿

using System;

namespace SchoolApp.DataLayer
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public class IdentityAttribute:Attribute
    {
    }
}
