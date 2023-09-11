using Microsoft.Extensions.Hosting;
using Otus.SolidHomework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.SolidHomework
{
    public class GameHostedService : IHostedService
    {
        IGame Game;
        public GameHostedService(IGame game)
        {
            this.Game = game;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Хотите сыграть в игру {Game.GameName}? y/n");
                var command = Console.ReadLine();
                if (command == "y")
                {
                    Game.Play();
                }
                else if (command == "n")
                {
                    Environment.Exit(-1);
                }
                else
                {
                    Console.WriteLine("Вы выбрали некорректную команду.");
                }
            }
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
