using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBinaryTree.Domains
{
    public class Customer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public long Passport { get; set; }

        public override string ToString()
        {
            return $"{LastName} {Name} {Passport}";
        }

        public static Customer Default
        {
            get
            {
                return new Customer()
                {
                    LastName = "Козлов",
                    Name = "Коля",
                    Passport = 3217896354
                };
            }
        }

        public static List<Customer>GetGustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Name="Иван",
                    LastName="Петров",
                    Passport=7512055011
                },
                new Customer()
                {
                    Name="Петр",
                    LastName="Иванов",
                    Passport=7452055011
                },
                new Customer()
                {
                    Name="Елена",
                    LastName="Романова",
                    Passport=7512055011
                },
                new Customer()
                {
                    Name="Николай",
                    LastName="Наум",
                    Passport=7512052089
                },
                new Customer()
                {
                    Name="Ольга",
                    LastName="Петрова",
                    Passport=7892055011
                },
                new Customer()
                {
                    Name="Владислав",
                    LastName="Коршун",
                    Passport=7512011011
                }
            };
        }
        public static Customer Parse(string str)
        {
            string[] words = str.Split();
            return new Customer()
            {
                LastName = words[0],
                Name = words[1],
                Passport = long.Parse(words[2])
            };
        }

    }
}
