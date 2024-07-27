using System.ComponentModel.DataAnnotations;

namespace CRudAppUsingAspWebApiClient.Models
{

    public class Student
    {
        [Required]
        public int studentId { get; set; }


        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentGender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public int standerd { get; set; }
        [Required]
        public string fatherName { get; set; }
    }

}
