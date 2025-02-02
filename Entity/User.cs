namespace University_Managment_system.Entity
{
    public class User 
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public int DeptId { get; set; }
    }
}
