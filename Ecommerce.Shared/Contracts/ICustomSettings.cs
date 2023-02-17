using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Contracts
{
    public interface ICustomSettings
    {
        string GetSetting(string name);
    }
}
