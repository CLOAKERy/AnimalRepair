﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int IdCustomer { get; set; }

        public string Date { get; set; } = null!;

        public double Price { get; set; }
    }
}