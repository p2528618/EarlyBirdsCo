﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System.Collections.Generic;

namespace Testing5
{
    [TestClass]
    public class tstStockCollection
    {

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //test to see it exists
            Assert.IsNotNull(AllStock);
        }

        [TestMethod]
        public void StockListOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create test data in the form of a list of objects to assign to the property
            List<clsStock> TestList = new List<clsStock>();
            //add an item to the list
            //create the item of test data
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.ItemId = 1;
            TestItem.ItemName = "Keycap";
            TestItem.Price = 12.75m;
            TestItem.Material = "Metal";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 15;
            TestItem.InStock = true;
            //add item to test list
            TestList.Add(TestItem);
            //assign data to the property
            AllStock.StockList = TestList;
            //test to see values are the same
            Assert.AreEqual(AllStock.StockList, TestList);
        }

        [TestMethod]
        public void ThisStockPropertyOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create test data to assign to property
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.ItemId = 1;
            TestItem.ItemName = "Keycap";
            TestItem.Price = 12.75m;
            TestItem.Material = "Metal";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 15;
            TestItem.InStock = true;
            //assign data to property
            AllStock.ThisItem = TestItem;
            //test to see values are the same
            Assert.AreEqual(AllStock.ThisItem, TestItem);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create test data in the form of a list of objects to assign to the property
            List<clsStock> TestList = new List<clsStock>();
            //add an item to the list
            //create the item of test data
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.ItemId = 1;
            TestItem.ItemName = "Keycap";
            TestItem.Price = 12.75m;
            TestItem.Material = "Metal";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 15;
            TestItem.InStock = true;
            //add item to the test list
            TestList.Add(TestItem);
            //assign data to property
            AllStock.StockList = TestList;
            //test to see values are the same
            Assert.AreEqual(AllStock.Count, TestList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create item of test data
            clsStock TestItem = new clsStock();
            //store primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.ItemId = 1;
            TestItem.ItemName = "Keycap";
            TestItem.Price = 12.75m;
            TestItem.Material = "Metal";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 15;
            TestItem.InStock = true;
            //set ThisItem to test data
            AllStock.ThisItem = TestItem;
            //add record
            PrimaryKey = AllStock.Add();
            //set primary key of test data
            TestItem.ItemId = PrimaryKey;
            //find record
            AllStock.ThisItem.Find(PrimaryKey);
            //test to see values are same
            Assert.AreEqual(AllStock.ThisItem, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create item of test data
            clsStock TestItem = new clsStock();
            //store primary key
            Int32 PrimaryKey = 0;       
            //set its properties
            TestItem.ItemId = 1;
            TestItem.ItemName = "Keycap";
            TestItem.Price = 12.75m;
            TestItem.Material = "Metal";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 15;
            TestItem.InStock = true;
            //set ThisItem to test data
            AllStock.ThisItem = TestItem;
            //add record
            PrimaryKey = AllStock.Add();
            //set primary key of test data
            TestItem.ItemId = PrimaryKey;
            //modify test data
            TestItem.ItemName = "Keycap 2";
            TestItem.Price = 10m;
            TestItem.Material = "Resin";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 0;
            TestItem.InStock = false;
            //set record based on new test data
            AllStock.ThisItem = TestItem;
            //update record
            AllStock.Update();
            //find record
            AllStock.ThisItem.Find(PrimaryKey);
            //test to see ThisItem matches test data
            Assert.AreEqual(AllStock.ThisItem, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            //create an instance of clsStockCollection
            clsStockCollection AllStock = new clsStockCollection();
            //create item of test data
            clsStock TestItem = new clsStock();
            //store primary key
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.ItemId = 1;
            TestItem.ItemName = "Keycap";
            TestItem.Price = 12.75m;
            TestItem.Material = "Metal";
            TestItem.LastPurchased = DateTime.Now.Date;
            TestItem.Quantity = 15;
            TestItem.InStock = true;
            //set ThisItem to test data
            AllStock.ThisItem = TestItem;
            //add record
            PrimaryKey = AllStock.Add();
            //set primary key of test data
            TestItem.ItemId = PrimaryKey;
            //find record
            AllStock.ThisItem.Find(PrimaryKey);
            //delete record
            AllStock.Delete();
            //find record now
            Boolean Found = AllStock.ThisItem.Find(PrimaryKey);
            //test to see record was not found
            Assert.IsFalse(Found);
        }

        [TestMethod]
        public void ReportByItemNameMethodOK()
        {
            //create an instance of clsStockCollection containing no filter
            clsStockCollection AllStock = new clsStockCollection();
            //create an instace of filtered data
            clsStockCollection FilteredStock = new clsStockCollection();
            //apply blank string (to return all records)
            FilteredStock.ReportByItemName("");
            //test to see two values are same
            Assert.AreEqual(AllStock.Count, FilteredStock.Count);
        }

        [TestMethod]
        public void ReportByItemNameNoneFound()
        {
            //create an instace of filtered data
            clsStockCollection FilteredStock = new clsStockCollection();
            //apply an item name that does not exist
            FilteredStock.ReportByItemName("xx xx xx");
            //test to see there are no records
            Assert.AreEqual(0, FilteredStock.Count);
        }

        [TestMethod]
        public void ReportByItemNameTestDataFound()
        {
            //create an instance of filtered data
            clsStockCollection FilteredStock = new clsStockCollection();
            //store outcome
            Boolean OK = true;
            //apply an item name that does not exist
            FilteredStock.ReportByItemName("xx xx xx");
            //check that correct number of records are found
            if (FilteredStock.Count == 2)
            {
                //check that first record is ID .....
                if (FilteredStock.StockList[0].ItemId != 16)
                {
                    OK = false;
                }
                //check that second record is ID .....
                if (FilteredStock.StockList[1].ItemId != 17)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            //test to see there are no records
            Assert.IsTrue(OK);
        }
    }
}
