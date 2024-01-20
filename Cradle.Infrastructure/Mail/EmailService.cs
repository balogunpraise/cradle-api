using Cradle.Application.Contracts.Infrastructure;
using Cradle.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Infrastructure.Mail
{
    internal class EmailService : IEmailService
    {
        public Task<bool> SendEmailAsync(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
