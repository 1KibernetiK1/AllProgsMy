using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLinq_DZ
{
    public class HardDriveStorage
    {
        public static List<HardDrive> GetHardDrives()
        {
            return new List<HardDrive>
            {
                new HardDrive()
                {
                    Name = "WD Blue [WD10SPZX]",
                    Categories = "Жесткие диски 3,5",
                    AvailabilityInStores = false,
                    Guarantee = 24,
                    Rating = 5,
                    Volume = 1024,
                    Manufacturer = "Western Digital",
                    Covers = Covers.IsAvailable,
                    Price = 3300
                },
                new HardDrive()
                {
                    Name = "WD Black [WD10SPSX]",
                    Categories = "Жесткие диски 2,5",
                    AvailabilityInStores = false,
                    Guarantee = 12,
                    Rating = 4,
                    Volume = 2048,
                    Manufacturer = "Western Digital",
                    Covers = Covers.IsAvailable,
                    Price = 3500
                },
                new HardDrive()
                {
                    Name = "Toshiba L200 [HDWL120UZSVA]",
                    Categories = "Жесткие диски 3,5",
                    AvailabilityInStores = true,
                    Guarantee = 24,
                    Rating = 3,
                    Volume = 1024,
                    Manufacturer = "Toshiba",
                    Covers = Covers.NotAvailable,
                    Price = 4000
                },
                new HardDrive()
                {
                    Name = "Seagate BarraCuda [ST1000LM048]",
                    Categories = "Жесткие диски 2,5",
                    AvailabilityInStores = true,
                    Guarantee = 12,
                    Rating = 4,
                    Volume = 1024,
                    Manufacturer = "Seagate",
                    Covers = Covers.IsAvailable,
                    Price = 5000
                },
                new HardDrive()
                {
                    Name = "WD Blue [WD5000AZLX]",
                    Categories = "Жесткие диски 2,5",
                    AvailabilityInStores = true,
                    Guarantee = 24,
                    Rating = 5,
                    Volume = 500,
                    Manufacturer = "Western Digital",
                    Covers = Covers.NotAvailable,
                    Price = 2400
                },
                new HardDrive()
                {
                    Name = "Seagate IronWolf NAS [ST6000VN001]",
                    Categories = "Жесткие диски 3,5",
                    AvailabilityInStores = false,
                    Guarantee = 12,
                    Rating = 3,
                    Volume = 1024,
                    Manufacturer = "Seagate",
                    Covers = Covers.IsAvailable,
                    Price = 6000
                },
                new HardDrive()
                {
                    Name = "WD Purple [WD140PURZ]",
                    Categories = "Жесткие диски 2,5",
                    AvailabilityInStores = false,
                    Guarantee = 12,
                    Rating = 4,
                    Volume = 1024,
                    Manufacturer = "Western Digital",
                    Covers = Covers.IsAvailable,
                    Price = 4000
                },
                new HardDrive()
                {
                    Name = "Toshiba S300 Surveillance [HDWT740UZSVA]",
                    Categories = "Жесткие диски 3,5",
                    AvailabilityInStores = true,
                    Guarantee = 36,
                    Rating = 5,
                    Volume = 2048,
                    Manufacturer = "Toshiba",
                    Covers = Covers.NotAvailable,
                    Price = 4500
                },
                new HardDrive()
                {
                    Name = "WD Gold [WD4003FRYZ]",
                    Categories = "Жесткие диски 3,5",
                    AvailabilityInStores = false,
                    Guarantee = 12,
                    Rating = 4,
                    Volume = 4000,
                    Manufacturer = "Western Digital",
                    Covers = Covers.IsAvailable,
                    Price = 3300
                },
                new HardDrive()
                {
                    Name = "WD Blue [WD10SPZX]",
                    Categories = "Жесткие диски 3,5",
                    AvailabilityInStores = true,
                    Guarantee = 24,
                    Rating = 2,
                    Volume = 1024,
                    Manufacturer = "Western Digital",
                    Covers = Covers.IsAvailable,
                    Price = 3300
                }
            };
        }
    }
}
