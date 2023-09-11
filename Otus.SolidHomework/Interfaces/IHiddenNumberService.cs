using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.SolidHomework.Interfaces
{
    public interface IHiddenNumberService
    {
        int GetHiddenNumber(int minValue, int maxValue);
    }
}
