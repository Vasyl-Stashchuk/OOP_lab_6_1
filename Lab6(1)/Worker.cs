using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_1_
{
    public class Worker
    {
        private List<Car> cars;
        public Worker()
        {
            cars = createList();
        }
        private List<Car> createList()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("lanos","зелений","TE 1247",2017,"Івано Іван Іванович"));
            cars.Add(new Car("amulet", "чорний", "KI 5870", 2017, "Петров Петро Петрович"));
            cars.Add(new Car("mazda", "червоний", "TE 0145", 2017, "Задорожній Микола Павлович"));
            cars.Add(new Car("mazda", "сірий", "TE 4578", 2017, "Шевченко Марія Вікторівна"));
            cars.Add(new Car("lanos", "білий", "KI 1478", 2017, "Пушкарьов Володимир Павлович"));
            return cars;
        }

        private Dictionary<Car, int> getListForMark()
        {
            Dictionary<Car, int> carQuant = new Dictionary<Car, int>();
            int quantity;
            for (int i = 0; i < cars.Count; i++)
            {
                quantity = 1;
                for (int j = i+1; j < cars.Count; j++)
                {
                    if (cars[i].mark == cars[j].mark)
                    {
                        quantity++;                       
                    }
                }
                int count = 0;
                if (carQuant.Count != 0)
                {
                    foreach (var c in carQuant)
                    {
                        if (cars[i].mark != c.Key.mark)
                        {
                            count++;
                        }
                    }
                    if (count == carQuant.Count)
                    {
                        carQuant.Add(cars[i], quantity);
                    }
                    
                }
                else
                    carQuant.Add(cars[i], quantity);
            }

            return carQuant;
        }

        public void showAllList()
        {
            Console.WriteLine("Список машин: ");
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].showInfo();
            }
        }
        public void showSortedTable()
        {
            Console.WriteLine("Кількість авто кожної марки: ");
            Dictionary<Car, int> carQuan = getListForMark();
            carQuan.OrderBy(x => x.Value);
            Console.WriteLine("{0, -7} {1}", "Марка", "Кількість");
            foreach (var c in carQuan)
            {
                Console.WriteLine("{0, -7} {1}", c.Key.mark, c.Value);
            }
        }
    }
}
