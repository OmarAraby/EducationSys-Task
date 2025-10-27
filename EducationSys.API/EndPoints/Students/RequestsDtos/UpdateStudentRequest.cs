using Microsoft.AspNetCore.Mvc;

namespace EducationSys.API.EndPoints.Students.RequestsDtos
{
    public class UpdateStudentRequest
    {
        [FromRoute] public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
