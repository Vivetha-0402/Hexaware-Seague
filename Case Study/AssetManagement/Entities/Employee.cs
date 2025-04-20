namespace Asset_Management.Entities
{
    // Represents an employee within the organization
    public class Employee
    {
        // Unique identifier for the employee
        public int EmployeeId { get; set; }

        // Name of the employee
        public string Name { get; set; }

        // Job position or title of the employee
        public string Position { get; set; }

        // Department in which the employee works
        public string Department { get; set; }

        // Constructor to initialize employee object with all properties
        public Employee(int employeeId, string name, string position, string department)
        {
            EmployeeId = employeeId;
            Name = name;
            Position = position;
            Department = department;
        }
    }
}
