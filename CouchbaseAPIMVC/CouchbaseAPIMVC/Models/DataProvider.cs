using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouchbaseAPIMVC.Models
{
    public static class DataProvider
    {
        public static string FakeDb()
        {
            return
                "[{'Id':'1','Type':'NWS.Models.Customer, BreezeSampleService','CustomerID':'729de505-ea6d-4cdf-89f6-0360ad37bde7','CustomerID_OLD':'WANDK','CompanyName':'Die Wandernde Kuh','ContactName':'Rita Müller','ContactTitle':'Sales Representative','Address':'Adenauerallee 900','City':'Stuttgart','PostalCode':'70563','Country':'Germany','Phone':'0711-020361','Fax':'0711-035428'},{'Id':'2','Type':'NWS.Models.Customer, BreezeSampleService','CustomerID':'cd98057f-b5c2-49f4-a235-05d155e636df','CustomerID_OLD':'SUPRD','CompanyName':'Suprêmes délices','ContactName':'Pascale Cartrain','ContactTitle':'Accounting Manager','Address':'Boulevard Tirou, 255','City':'Charleroi','PostalCode':'B-6000','Country':'Belgium','Phone':'(071) 23 67 22 20','Fax':'(071) 23 67 22 21'}]";

        }
    }
}