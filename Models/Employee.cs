namespace CodingTest.Models
{
    public class Employee : IEquatable<Employee>, IComparable<Employee>
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int CompareTo(Employee? other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return EmployeeId.CompareTo(other.EmployeeId);
            }
        }

        public bool Equals(Employee? other)
        {
            if (other == null)
            { 
                return false; 
            }
            else if (EmployeeId == other.EmployeeId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
