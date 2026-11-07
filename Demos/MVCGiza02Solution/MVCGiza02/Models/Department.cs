namespace MVCGiza02.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Mgrname { get; set; }

        // Dep has many emps
        public List<Employee>? Emps { get; set; }
    }
}
