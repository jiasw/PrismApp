using Prism.Application.Contract.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Application.Infrastructure
{
    public class LogHelper : ILogHelper
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
