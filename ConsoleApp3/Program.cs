using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Storage> storages = new List<Storage>();
            storages.Add(new Flash("домашки", "LaCie XtremKey", 64000));
            storages.Add(new Flash("аниме", "RAUF ", 16000));
            storages.Add(new DVD("для фильмов", "SPEDO", TypeDVD.doubleSided));
            storages.Add(new DVD("Сделано в китае", "Sony FAIK", TypeDVD.singleSided));
            storages.Add(new HDD("Top Secret", "SOON", 250000, 250000, 250000, 250000));
            Task3(new HDD("Прекрасный", "WD Red", 2000000, 2000000));
        }
        static void Task1(List<Storage> storages)
        {
            Console.WriteLine($"{storages.Sum(a => a.GetMemory()) / 1000}ГБ");
        }
        static void Task2(List<Storage> storages)
        {
            double memory, time = 0;
            do
            {
                Console.Clear();
                Console.Write("Введите размер данных: ");
            } while (!double.TryParse(Console.ReadLine(), out memory));
            foreach (var item in storages)
            {
                time += item.Copy(ref memory);
                if (memory == 0)
                {
                    break;
                }
            }
            if (memory != 0)
            {
                Console.WriteLine($"Не хватило {memory}");
            }
            Console.WriteLine($"Прошло {time}");
            foreach (var item in storages)
            {
                Console.WriteLine(item.GetInfo());
            }
        }
        static void Task3(Storage storage)
        {
            double memory;
            do
            {
                Console.Clear();
                Console.Write("Введите размер данных: ");
            } while (!double.TryParse(Console.ReadLine(), out memory));
            int i = 0;
            while (memory != 0)
            {
                i++;
                storage.Copy(ref memory);
                storage.Clear();
            }
            Console.WriteLine($"Вам понадобиться {i}");
        }
    }
    }

