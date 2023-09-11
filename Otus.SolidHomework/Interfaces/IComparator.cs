using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.SolidHomework.Interfaces
{
    internal interface IComparator<T>
    {
        (bool result, string comment) Compare(T x, T y);
    }
}
