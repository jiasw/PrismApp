using Prism.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Application.ShowData
{
    public class ShowData : IShowData
    {
        public string ShowDataMsg()
        {
            return "This is the ShowData class";
        }
    }
}
