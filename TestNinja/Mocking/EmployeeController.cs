using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private EmployeeContext _db;
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeController(IEmployeeStorage employeeStorage)
        {
            _db = new EmployeeContext();
            _employeeStorage = employeeStorage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            //vdaka tomu, ze sa logika pre pracu s DB (odmazanie employee) vykonava v inej triede je zabezpecene Separation of concerns
            _employeeStorage.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}