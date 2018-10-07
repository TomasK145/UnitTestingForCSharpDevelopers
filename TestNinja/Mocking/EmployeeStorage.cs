using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class EmployeeStorage : IEmployeeStorage
    {
        //v nazve triedy pouzit Service - ak sa jedna o application service layer - zodpovedne za high level orchestration --> delegovanie uloh roznym objektom
        private EmployeeContext _db;

        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            //nie je potrebny unit testing pretoze pracujeme priamo s external resources
            //spravny sposob otestovania by bolo napisat integration test
            var employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return;
            }
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
