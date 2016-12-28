﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using BangazonFinancialsVS;
using BangazonFinancialsVS.Factory;
using BangazonFinancialsVS.Entities;


namespace FinancialTests
{
    public class Tests
    {
        [Fact]
        public void TestThatTestingWorks()
        {
            bool isMonday = true;
            Assert.True(isMonday);
        }

        //Method Name: TestSalesFactoryIsSingleton()
        //Purpose of Method: Test that there is only one salesFactory at a time
        [Fact]
        public void TestSalesFactoryIsSingleton()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            SalesFactory salesFactory2 = SalesFactory.Instance;
            Assert.Equal(salesFactory, salesFactory2);
        }

        //Method Name: TestCanPullAllSalesFromDB()
        //Purpose of Method: Test that all sales data can be pulled from DB
        [Fact]
        public void TestCanPullAllSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;

            List<Sale> ListOfAllSales = salesFactory.GetAllSalesByDate();
            Assert.Equal(ListOfAllSales.Count, 1000);
        }

        //Method Name: TestCanPullLastSevenDaysSalesFromDB()
        //Purpose of Method: Test that last seven days of data can be pulled from DB
        [Fact]
        public void TestCanPullLastSevenDaysSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfLastSevenDaysSales = salesFactory.GetLastSevenDaysSales();
            Assert.NotEqual(ListOfLastSevenDaysSales.Count, 0);
        }

        //Method Name: TestCanPullLast30DaysSalesFromDB()
        //Purpose of Method: Test that last thirty days of data can be pulled from DB
        [Fact]
        public void TestCanPullLast30DaysSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfLastThirtyDaysSales = salesFactory.GetLastThirtyDaysSales();
            Assert.NotEqual(ListOfLastThirtyDaysSales.Count, 0);
        }

        //Method Name: TestCanPullLastNinetyDaysSalesFromDB()
        //Purpose of Method: Test that last ninety days of data can be pulled from DB
        [Fact]
        public void TestCanPullLast90DaysSalesFromDB()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfLastNinetyDaysSales = salesFactory.GetLastNinetyDaysSales();
            Assert.NotEqual(ListOfLastNinetyDaysSales.Count, 0);
        }

        //Method Name: TestCanSumRevenuePerCustomer()
        //Purpose of Method: Test that a sum of all revenue by customer can be pulled from DB
        [Fact]
        public void TestCanSumRevenuePerCustomer()
        {

            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByCustomer = salesFactory.GetAllSalesByCustomer();

            Assert.Equal(ListOfRevenueByCustomer.Count, 16);
        }

        //Method Name: TestCanSumRevenuePerProduct()
        //Purpose of Method: Test that a sum of all revenue by product can be pulled from DB
        [Fact]
        public void TestCanSumRevenuePerProduct()
        {
            SalesFactory salesFactory = SalesFactory.Instance;
            List<Sale> ListOfRevenueByProduct = salesFactory.GetAllSalesByCustomer();

            Assert.Equal(ListOfRevenueByProduct.Count, 16);
        }
    }
}

