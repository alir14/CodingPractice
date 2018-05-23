using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringFramework.Interface
{
    public interface INumbersStringDataComponent
    {
        string GetBaseNumbersString(int index);

        string GetTensNumbersString(int index);
    }
}
