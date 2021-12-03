using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using AbstractShapes;
using BasicShapes;
using DataSource;

namespace DbLibEF
{
    public class ShapesDbContext : DbContext, IDataSource
    {
        DbSet<Rectangle> Rectangles { get; set; }
        DbSet<RectThreeAngle> RectThreeAngles { get; set; }
        DbSet<Square> Squares { get; set; }

        public ShapesDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mylocaldb;Database=shapesdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rectangle>().Ignore(b => b.Value);
            modelBuilder.Entity<Square>().Ignore(b => b.Value);
            modelBuilder.Entity<RectThreeAngle>().Ignore(b => b.Value);
            modelBuilder.Entity<Rectangle>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Square>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<RectThreeAngle>().Property(p => p.Id).ValueGeneratedNever();
        }

        public List<IShape> GetShapes()
        {
            List<IShape> shapes = new List<IShape>();
            shapes.AddRange(Rectangles.ToList());
            shapes.AddRange(RectThreeAngles.ToList());
            shapes.AddRange(Squares.ToList());
            return shapes.OrderBy<IShape, int>(x => x.Id).ToList<IShape>();
        }

        public void AddShape(string par)
        {
            BasicShapesCSFactory f = new BasicShapesCSFactory();
            IShape sh = f.CreateShapeFromString(par);
            sh.Id = Rectangles.Count() + Squares.Count() + RectThreeAngles.Count() + 1;
            if (sh.Name == "Rectangle") Rectangles.Add((Rectangle)sh);
            if (sh.Name == "Square") Squares.Add((Square)sh);
            if (sh.Name == "rect_tri") RectThreeAngles.Add((RectThreeAngle)sh);
            SaveChanges();
        }

        public int ShapesCount { get; set; }
    }
}
