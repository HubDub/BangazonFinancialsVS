﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonFinancialsVS.Data;
using BangazonFinancialsVS.Entities;
using Microsoft.Data.Sqlite;

namespace BangazonFinancialsVS.Factory
{
    public class SalesFactory
    {
        private static SalesFactory _instance;
        public static SalesFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SalesFactory();
                }
                return _instance;
            }
        }

        //Method Name: GetAllSalesByDate()
        //Purpose of Method: pulls all sales from database and sends list back to where it was called
        public List<Sale> GetAllSalesByDate()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfAllSales = new List<Sale>();

            connection.execute($"SELECT Id, ProductName, ProductCost, ProductRevenue, ProductSupplierState, CustomerFirstName, CustomerLastName, CustomerAddress, CustomerZipCode, PurchaseDate FROM Revenue ORDER BY PurchaseDate",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfAllSales.Add(new Sale
                        {
                            Id = reader.GetInt32(0),
                            ProductName = reader[1].ToString(),
                            ProductCost = reader.GetInt32(2),
                            ProductRevenue = reader.GetInt32(3),
                            ProductSupplierState = reader[4].ToString(),
                            CustomerFirstName = reader[5].ToString(),
                            CustomerLastName = reader[6].ToString(),
                            CustomerAddress = reader[7].ToString(),
                            CustomerZipCode = reader[8].ToString(),
                            PurchaseDate = reader.GetDateTime(9)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfAllSales;
        }

        //Method Name: GetLastSevenDaysSales()
        //Purpose of Method: pulls sales from last seven days from database and sends list back to where it was called
        public List<Sale> GetLastSevenDaysSales()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfLastSevenDaysSales = new List<Sale>();

            connection.execute($"SELECT ProductName, PurchaseDate, ProductRevenue FROM Revenue WHERE PurchaseDate >= datetime('now', '-6 days') AND PurchaseDate <= datetime('now', 'localtime') ORDER BY PurchaseDate",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfLastSevenDaysSales.Add(new Sale
                        {
                            ProductName = reader[0].ToString(),
                            PurchaseDate = reader.GetDateTime(1),
                            ProductRevenue = reader.GetInt32(2)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfLastSevenDaysSales;
        }

        //Method Name: GetLastThirtyDaysSales()
        //Purpose of Method: pulls sales from last thirty days from database and sends list back to where it was called
        public List<Sale> GetLastThirtyDaysSales()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfLastThirtyDaysSales = new List<Sale>();

            connection.execute($"SELECT ProductName, PurchaseDate, ProductRevenue FROM Revenue WHERE PurchaseDate >= datetime('now', '-29 days') AND PurchaseDate <= datetime('now', 'localtime') ORDER BY PurchaseDate",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfLastThirtyDaysSales.Add(new Sale
                        {
                            ProductName = reader[0].ToString(),
                            PurchaseDate = reader.GetDateTime(1),
                            ProductRevenue = reader.GetInt32(2)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfLastThirtyDaysSales;
        }

        //Method Name: GetLastNinetyDaysSales()
        //Purpose of Method: pulls sales from last ninety days from database and sends list back to where it was called
        public List<Sale> GetLastNinetyDaysSales()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfLastNinetyDaysSales = new List<Sale>();

            connection.execute($"SELECT ProductName, PurchaseDate, ProductRevenue FROM Revenue WHERE PurchaseDate >= datetime('now', '-89 days') AND PurchaseDate <= datetime('now', 'localtime') ORDER BY PurchaseDate",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfLastNinetyDaysSales.Add(new Sale
                        {
                            ProductName = reader[0].ToString(),
                            PurchaseDate = reader.GetDateTime(1),
                            ProductRevenue = reader.GetInt32(2)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfLastNinetyDaysSales;
        }

        //Method Name: GetAllSalesByCustomer()
        //Purpose of Method: pulls sum of sales by customer from database and sends list back to where it was called
        public List<Sale> GetAllSalesByCustomer()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfRevenueByCustomer = new List<Sale>();

            connection.execute($"SELECT CustomerFirstName, CustomerLastName, Sum(ProductRevenue) as ProductRevenue FROM Revenue GROUP BY CustomerLastName",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfRevenueByCustomer.Add(new Sale
                        {
                            CustomerFirstName = reader[0].ToString(),
                            CustomerLastName = reader[1].ToString(),
                            ProductRevenue = reader.GetInt32(2)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfRevenueByCustomer;
        }

        //Method Name: GetAllSalesByProduct()
        //Purpose of Method: pulls sum of sales by product from database and sends list back to where it was called
        public List<Sale> GetAllSalesByProduct()
        {
            FinancialsConnection connection = new FinancialsConnection();
            List<Sale> ListOfRevenueByProduct = new List<Sale>();

            connection.execute($"SELECT ProductName, Sum(ProductRevenue) as ProductRevenue FROM Revenue GROUP BY ProductName",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        ListOfRevenueByProduct.Add(new Sale
                        {
                            ProductName = reader[0].ToString(),
                            ProductRevenue = reader.GetInt32(1)
                        });
                    }
                    reader.Dispose();
                });
            return ListOfRevenueByProduct;
        }
    }
}
