using Microsoft.EntityFrameworkCore;  
namespace WebApi.Entities
{     
public class EmployeContext : DbContext     
  {         
    //public StudentsContext(DbContextOptions<StudentsContext> options)                 : base(options)  
    public EmployeContext(DbContextOptions options)                 : base(options)        
{         
}       
    public DbSet<Employes> Employes{ get; set; } 
    public DbSet<Attendance> Attendance{ get; set; } 
    


     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // base.OnModelCreating(modelBuilder);
        modelBuilder.HasSequence<int>("rollno", schema: "dbo")
            .StartsAt(1)
            .IncrementsBy(1);
            //builder.ForNpgsqlUseIdentityColumns();

        modelBuilder.Entity<Employes>()
            .Property(o => o.rollno);
            //.HasDefaultValueSql("NEXT VALUE FOR dbo.Order_seq");

            //  modelBuilder.HasSequence<int>("id", schema: "dbo")
            // .StartsAt(1)
            // .IncrementsBy(1);
           modelBuilder.Entity<Attendance>()
            .Property(o => o.id);
            // .HasDefaultValueSql("NEXT VALUE FOR dbo.Order_seq");

    }
      // protected override void OnModelCreating(ModelBuilder modelBuilder)
      //   {
      //       modelBuilder.Entity<Student>().HasNoKey();
      //   }
  
   } 
}