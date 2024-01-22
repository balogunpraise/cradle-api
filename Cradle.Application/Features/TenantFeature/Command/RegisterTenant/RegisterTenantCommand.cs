using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Features.TenantFeature.Command.RegisterTenant
{
    public class RegisterTenantCommand : IRequest
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public bool DedicatedDb { get; set; }
    }
}
