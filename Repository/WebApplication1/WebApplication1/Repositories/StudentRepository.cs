using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        [Dependency]
        public ApplicationDbContext DbContext { get; set; }

        public void CreateStudent(Student st)
        {
            DbContext.Students.Add(st);
            DbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student st = DbContext.Students.Find(id);
            DbContext.Entry(st).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            return DbContext.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return DbContext.Students.ToList();
        }

        public void UpdateStudent(Student st)
        {
            DbContext.Entry(st).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}