using Microsoft.Extensions.Options;
using Otus.SolidHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.SolidHomework.Implementations
{
    internal class GuessNumberGame : IGame
    {
        Settings Settings;
        IHiddenNumberService HiddenNumberService;
        IComparator<int> Comparator;
        public string GameName { get; } = "Угадай число";

        public GuessNumberGame(IOptions<Settings> settings, IHiddenNumberService hiddenNumberService, IComparator<int> comparator)
        {
            Settings = settings.Value;
            HiddenNumberService = hiddenNumberService;
            Comparator = comparator;
        }
        public void Play()
        {
            Console.WriteLine($"Отгадайте число от {Settings.MinValue} до {Settings.MaxValue} за {Settings.Attempts} попыток.");

            var hiddenNumber = HiddenNumberService.GetHiddenNumber(Settings.MinValue, Settings.MaxValue);
            for (int attemp = 0; attemp < Settings.Attempts - 1; attemp++)
            {
                Console.WriteLine($"Попытка #{attemp}. Введите число:");
                var userNumber = int.Parse(Console.ReadLine());
                (bool result, string comment) = Comparator.Compare(userNumber, hiddenNumber);
                Console.WriteLine(comment);

                if (result)
                    return;
            }

            Console.WriteLine("Вы использовали все ваши попытки =( Повезёт в следующий раз!");
        }
    }
}
