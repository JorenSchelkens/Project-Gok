using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankDomain
{
    class Email
    {

        public async Task<IActionResult> SendEmail([FromServices]IFluentEmail email)
        {
            await email
                .To("test@test.test")
                .Subject("test email subject")
                .Body("This is the email body")
                .SendAsync();

            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
    }
}
