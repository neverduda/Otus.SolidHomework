using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otus.SolidHomework.Interfaces;

namespace Otus.SolidHomework.Implementations
{
    public class RandomNumberService : IHiddenNumberService
    {
        public int GetHiddenNumber(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }
    }
}
