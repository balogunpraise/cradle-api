﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Common.Authorization
{
    public class AppRoles
    {
        public const string Admin = "Admin";
        public const string Basic = "Basic";

        public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
        {
            Admin, Basic
        });

        public static bool IsDefault(string roleName)
            => DefaultRoles.Any(x => x.Equals(roleName));
    }
}
