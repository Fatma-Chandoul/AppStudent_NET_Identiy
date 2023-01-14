namespace StudentAnn.Models
{
    public class School
    {
        //Id ou ID ou SchoolId ou SchoolID
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAdress { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
