﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonFinancialsVS.Entities
{
    //Class Name: Sale
    //Author: Debbie Bourne
    //Purpose of this class: to create a Sale entity with properties 
    //Methods in Class: N/A
    public class Sale
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
        public double ProductRevenue { get; set; }
        public string ProductSupplierState { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerZipCode { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
