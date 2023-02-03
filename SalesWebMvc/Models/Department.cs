﻿using System.Numerics;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int id { get; set; }
        public string? name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, string? name)
        {
            this.id = id;
            this.name = name;
        }

        public void addSeller(Seller seller)
        {
            Sellers.Add(seller);

        }

        public double TotalSales(DateTime inital, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(inital, final));

        }


    }
}