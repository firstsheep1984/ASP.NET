using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
         Student GetStudent(int id);
        void CreateStudent(Student st);
        void UpdateStudent(Student st);
        void DeleteStudent(int id);
    }
}
