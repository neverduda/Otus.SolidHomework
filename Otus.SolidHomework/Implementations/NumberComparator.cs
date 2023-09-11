using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otus.SolidHomework.Interfaces;

namespace Otus.SolidHomework.Implementations
{
    internal class NumberComparator : IComparator<int>
    {
        public (bool result, string comment) Compare(int x, int y)
        {
            var dif = x - y;
            if (dif < 0)
            {
                return (false, "Ваше число слишком маленькое!");
            }
            else if (dif > 0)
            {
                return (false, "Ваше число слишком большое!");
            }
            else
            {
                return (true, "Поздравляю! Вы отгадали!");
            }
        }
    }
}
