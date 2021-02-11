using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHouse.Models
{
    public class House
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public HouseType HouseType { get; set; }
        public int HouseTypeId { get; set; }
        public int Bedrooms { get; set; }
        public bool IsFurnished { get; set; }
        public int LogId { get; set; }
        public DateTime WarrantyStart { get; set; }
        public DateTime WarrantyEnd { get; set; }
        public double RentPrice { get; set; }
        public string ContractNumber { get; set; }
        public string Owner { get; set; }
        public string OwnershipRegisteration { get; set; }
        public string Location { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}