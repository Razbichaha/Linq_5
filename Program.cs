using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new();
            storage.Start();
            Console.ReadLine();
        }
    }

    class Storage
    {
        private List<Stew> _stews = new List<Stew>();

        internal Storage()
        {
            GenerateStorage();
        }

        internal void Start()
        {
            int presentYear = 2022;

            Console.WriteLine("Список всех банок тушенки");
            Console.WriteLine();

            ShowAllStew();

            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Просроченные продукты");

            ShowExpiredProduct(presentYear);

            Console.ReadLine();
        }

        private void ShowExpiredProduct(int presentYear)
        {
            var expiredProduct = from product in _stews where product.BestBeforeDate + product.DateManufacture < presentYear select product;

            ShowListPlayer(expiredProduct.ToList());
        }

        private void ShowListStews(List<Stew> stews)
        {
            foreach (Stew player in stews)
            {
                ShowStew(player);
            }
        }

        private void ShowAllStew()
        {
            Console.Clear();

            foreach (Stew stew in _stews)
            {
                ShowStew(stew);
            }
        }

        private void ShowStew(Stew stew)
        {
            Console.WriteLine($" {stew.Title} | Дата производства - {stew.DateManufacture} | Срок годности - {stew.BestBeforeDate}");
        }

        private void GenerateStorage()
        {
            int quantityStew = 15;
            int minimumBestBeforeDate = 2;
            int maximumBestBeforeDate = 5;

            for (int i = 0; i < quantityStew; i++)
            {
                Random random = new Random();
                Stew stew = new Stew(i + 1, random.Next(minimumBestBeforeDate, maximumBestBeforeDate));
                _stews.Add(stew);
            }
        }
    }

    class Stew
    {
        internal string Title { get; private set; }
        internal int DateManufacture { get; private set; }
        internal int BestBeforeDate { get; private set; }

        public Stew(int countName , int bestBeforeDate)
        {
            GenerateTitle(countName);
            GenerateDateManufacture();
            BestBeforeDate = bestBeforeDate;
        }

        private void GenerateTitle(int count)
        {
                Title = "Тушенка_" + count;
        }

        private void GenerateDateManufacture()
        {
            Random random = new();
            int minimumYaers = 2000;
            int maximumYaers = 2022;
            DateManufacture = random.Next(minimumYaers, maximumYaers);
        }
    }
}
