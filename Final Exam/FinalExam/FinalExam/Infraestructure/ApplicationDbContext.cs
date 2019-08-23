using FinalExam.Models;
using System.Data.Entity;

namespace FinalExam.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<Runner> Runners { get; set; }
    }
}