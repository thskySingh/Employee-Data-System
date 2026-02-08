using Microsoft.EntityFrameworkCore;
using EmployeeForm.Models;

namespace EmployeeForm.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<tblemployee>tblemployees { get; set; }
        public DbSet<tblcountry> tblcountries { get; set; }
        public DbSet<tblstate> tblstates { get; set; }
        public DbSet<tblcity> tblcities { get; set; }
        public DbSet<tblgender> tblgenders { get; set; }
        public DbSet<tblhobby> tblhobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Gender
            modelBuilder.Entity<tblgender>().HasData(
                new tblgender { genderid = 1, gendername = "Male" },
                new tblgender { genderid = 2, gendername = "Female" },
                new tblgender { genderid = 3, gendername = "Transgender" }
            );

            // 🔹 Country
            modelBuilder.Entity<tblcountry>().HasData(
                new tblcountry { countryid = 1, countryname = "India" },
                new tblcountry { countryid = 2, countryname = "Pakistan" }
            );

            // 🔹 State (2 states per country)
            modelBuilder.Entity<tblstate>().HasData(
                // India
                new tblstate { stateid = 1, statename = "Gujarat", countryid = 1 },
                new tblstate { stateid = 2, statename = "Maharashtra", countryid = 1 },

                // Pakistan
                new tblstate { stateid = 3, statename = "Punjab", countryid = 2 },
                new tblstate { stateid = 4, statename = "Sindh", countryid = 2 }
            );

            // 🔹 City (2 cities per state)
            modelBuilder.Entity<tblcity>().HasData(
                // Gujarat
                new tblcity { cityid = 1, cityname = "Ahmedabad", stateid = 1 },
                new tblcity { cityid = 2, cityname = "Surat", stateid = 1 },

                // Maharashtra
                new tblcity { cityid = 3, cityname = "Mumbai", stateid = 2 },
                new tblcity { cityid = 4, cityname = "Pune", stateid = 2 },

                // Punjab
                new tblcity { cityid = 5, cityname = "Lahore", stateid = 3 },
                new tblcity { cityid = 6, cityname = "Multan", stateid = 3 },

                // Sindh
                new tblcity { cityid = 7, cityname = "Karachi", stateid = 4 },
                new tblcity { cityid = 8, cityname = "Hyderabad", stateid = 4 }
            );

            // 🔹 Hobbies (8 hobbies)
            modelBuilder.Entity<tblhobby>().HasData(
                new tblhobby { hobbyid = 1, hobbyname = "Cricket" },
                new tblhobby { hobbyid = 2, hobbyname = "Football" },
                new tblhobby { hobbyid = 3, hobbyname = "Reading" },
                new tblhobby { hobbyid = 4, hobbyname = "Music" },
                new tblhobby { hobbyid = 5, hobbyname = "Traveling" },
                new tblhobby { hobbyid = 6, hobbyname = "Gaming" },
                new tblhobby { hobbyid = 7, hobbyname = "Cooking" },
                new tblhobby { hobbyid = 8, hobbyname = "Photography" }
            );
        }
        
    }
}
