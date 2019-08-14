using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MockupStudentRepository : IStudentRepository
    {
        private static List<Student> students = new List<Student>();
        public void CreateStudent(Student st)
        {
            students.Add(st);
        }

        public void DeleteStudent(int id)
        {
            Student st = students.Find(s => s.StudentId == id);
            students.Remove(st);
        }

        public Student GetStudent(int id)
        {
            Student st = students.Find(s => s.StudentId == id);
            return st;
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }

        public void UpdateStudent(Student st)
        {
            Student stToModify = students.Find(s => s.StudentId == st.StudentId);

        }
    }
}