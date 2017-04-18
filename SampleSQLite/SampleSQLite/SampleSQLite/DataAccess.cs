﻿using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleSQLite
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            dbConn.CreateTable<Employee>();
        }

        public List<Employee> GetAllEmployees()
        {
            return dbConn.Query<Employee>("Select * From [Employee]");
        }

        public int SaveEmployee(Employee aEmployee)
        {
            return dbConn.Insert(aEmployee);
        }

        public int DeleteEmployee(Employee aEmployee)
        {
            return dbConn.Delete(aEmployee);
        }

        public int EditEmployee(Employee aEmployee)
        {
            return dbConn.Update(aEmployee);
        }
    }
}
