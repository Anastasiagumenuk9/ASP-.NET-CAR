using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
   public interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    }
}
