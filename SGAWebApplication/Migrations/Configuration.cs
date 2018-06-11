namespace SGAWebApplication.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SGAWebApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SGAWebApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SGAWebApplication.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                roleManager.Create(new IdentityRole { Name = "Teacher" });
            }

            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                roleManager.Create(new IdentityRole { Name = "Student" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(r => r.Email == "mahoneyj0253@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mahoneyj0253@forsythtech.edu",
                    Email = "mahoneyj0253@forsythtech.edu",
                    FirstName = "John",
                    LastName = "Mahoney",
                    UserRole = "Admin"
                }, "penguins82");
            }

            var userId = userManager.FindByEmail("mahoneyj0253@forsythtech.edu").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Users.Any(r => r.Email == "jlegin@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jlegin@forsythtech.edu",
                    Email = "jlegin@forsythtech.edu",
                    FirstName = "Jomo",
                    LastName = "Legin",
                    UserRole = "Admin"
                }, "password");
            }

            userId = userManager.FindByEmail("jlegin@forsythtech.edu").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Users.Any(r => r.Email == "mahoneyj0253@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "sdorsett@forsythtech.edu",
                    Email = "sdorsett@forsythtech.edu",
                    FirstName = "Samuel",
                    LastName = "Dorsett",
                    UserRole = "Teacher"
                }, "password");
            }

            userId = userManager.FindByEmail("sdorsett@forsythtech.edu").Id;
            userManager.AddToRole(userId, "Teacher");

            if (!context.Users.Any(r => r.Email == "lcohen@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "lcohen@forsythtech.edu",
                    Email = "lcohen@forsythtech.edu",
                    FirstName = "Linda",
                    LastName = "Cohen",
                    UserRole = "Teacher"
                }, "password");
            }

            userId = userManager.FindByEmail("lcohen@forsythtech.edu").Id;
            userManager.AddToRole(userId, "Teacher");

            if (!context.Users.Any(r => r.Email == "bdavis0856@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "bdavis0856@forsythtech.edu",
                    Email = "bdavis0856@forsythtech.edu",
                    FirstName = "Brent",
                    LastName = "Davis",
                    UserRole = "Student",
                    Points = 0
                }, "password");
            }

            userId = userManager.FindByEmail("bdavis0856@forsythtech.edu").Id;
            userManager.AddToRole(userId, "Student");

            if (!context.Users.Any(r => r.Email == "tsmith2834@forsythtech.edu"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "tsmith2834@forsythtech.edu",
                    Email = "tsmith2834@forsythtech.edu",
                    FirstName = "Timothy",
                    LastName = "Smith",
                    UserRole = "Student",
                    Points = 0
                }, "password");
            }

            userId = userManager.FindByEmail("tsmith2834@forsythtech.edu").Id;
            userManager.AddToRole(userId, "Student");

            context.clubs.AddOrUpdate(
                    new Clubs { Id = 1, Name = "Mathletes", Budget = 100 },
                    new Clubs { Id = 2, Name = "AITP", Budget = 200 },
                    new Clubs { Id = 3, Name = "Music Lovers", Budget = 50 },
                    new Clubs { Id = 4, Name = "Anime Club", Budget = 1500 },
                    new Clubs { Id = 5, Name = "Literature Club", Budget = 100 }
            );

            context.clubEvents.AddOrUpdate(
                new ClubEvents
                {
                    Name = "Math Fun",
                    Description = "We have fun with math",
                    PointKey = "YS2HD-3J2U3",
                    PointValue = 10,
                    ClubId = 1
                },
                new ClubEvents
                {
                    Name = "Fun With Counting",
                    Description = "We count numbers all day",
                    PointKey = "HDBW2-2D34F",
                    PointValue = 15,
                    ClubId = 1
                },
                new ClubEvents
                {
                    Name = "Teaching Kids Math",
                    Description = "We teach kids math",
                    PointKey = "BSHDU-2HEN3",
                    PointValue = 20,
                    ClubId = 1
                },
                new ClubEvents
                {
                    Name = "Decathalon",
                    Description = "We go to a tournament to see who's the best in the land",
                    PointKey = "JD82J-DJW8J",
                    PointValue = 25,
                    ClubId = 1
                },
                new ClubEvents
                {
                    Name = "Reading Math Labels",
                    Description = "We read math labels",
                    PointKey = "LHDUS-28SH2",
                    PointValue = 5,
                    ClubId = 1
                },
                new ClubEvents
                {
                    Name = "Programming Competition",
                    Description = "We compete using python to see who can write the better program",
                    PointKey = "2NEUD-SJ23J",
                    PointValue = 20,
                    ClubId = 2
                },
                new ClubEvents
                {
                    Name = "Learn to Build a Computer",
                    Description = "We learn to build a computer from our club president",
                    PointKey = "H28JD-28JDE",
                    PointValue = 15,
                    ClubId = 2
                },
                new ClubEvents
                {
                    Name = "PC Clinic",
                    Description = "We fix computers that people bring in",
                    PointKey = "NW27H-3J87J",
                    PointValue = 15,
                    ClubId = 2
                },
                new ClubEvents
                {
                    Name = "MVC Lecture",
                    Description = "We will have someone come in and teach about the basics of MVC",
                    PointKey = "UHW82-82734",
                    PointValue = 5,
                    ClubId = 2
                },
                new ClubEvents
                {
                    Name = "Pizza Party",
                    Description = "We eat pizza and hang out",
                    PointKey = "273HN-28342",
                    PointValue = 2,
                    ClubId = 2
                },
                new ClubEvents
                {
                    Name = "Playing For the School",
                    Description = "We play a couple of songs in the courtyard in the day",
                    PointKey = "27364-26343",
                    PointValue = 10,
                    ClubId = 3
                },
                new ClubEvents
                {
                    Name = "Concert for Fall Fest",
                    Description = "We host a concert featuring a couple of local artists",
                    PointKey = "IWJDU-2838F",
                    PointValue = 25,
                    ClubId = 3
                },
                new ClubEvents
                {
                    Name = "Jam Out Session",
                    Description = "We jam out to our favorite tunes",
                    PointKey = "MBS92-3VC82",
                    PointValue = 5,
                    ClubId = 3
                },
                new ClubEvents
                {
                    Name = "Seeing the Nutcracker",
                    Description = "We see the nutcracker in december",
                    PointKey = "2IS02-27HXN",
                    PointValue = 15,
                    ClubId = 3
                },
                new ClubEvents
                {
                    Name = "Going to the Symphony",
                    Description = "We attend the North Carolina symphony",
                    PointKey = "2JE7U-37H3S",
                    PointValue = 15,
                    ClubId = 3
                },
                new ClubEvents
                {
                    Name = "Seeing an Anime Movie",
                    Description = "We go to high point to see the latest anime movie",
                    PointKey = "82JLP-LWPLS",
                    PointValue = 15,
                    ClubId = 4
                },
                new ClubEvents
                {
                    Name = "Going to Triad Anime Con",
                    Description = "We meet up and go to triad anime con",
                    PointKey = "09J2K-8JENL",
                    PointValue = 5,
                    ClubId = 4
                },
                new ClubEvents
                {
                    Name = "Japanese Culture Night",
                    Description = "We spend a night learning about Japanese Culture",
                    PointKey = "ZXSI2-28XJD",
                    PointValue = 10,
                    ClubId = 4
                },
                new ClubEvents
                {
                    Name = "Cosplay How To",
                    Description = "We get some people in to teach us about the basics of cosplay",
                    PointKey = "HNMZS-XUWJS",
                    PointValue = 20,
                    ClubId = 4
                },
                new ClubEvents
                {
                    Name = "J-Pop Appreciation",
                    Description = "We take the time to listen to J-Pop and other forms of Japanese Music",
                    PointKey = "8J36H-37DH3",
                    PointValue = 5,
                    ClubId = 4
                },
                new ClubEvents
                {
                    Name = "Poetry Slam Night",
                    Description = "We read out poetry and hit each other with them",
                    PointKey = "HDU72-DJ36H",
                    PointValue = 5,
                    ClubId = 5
                },
                new ClubEvents
                {
                    Name = "Reading Hour",
                    Description = "We host an event to let people read books based on out collection",
                    PointKey = "6H1BS-2YH34",
                    PointValue = 20,
                    ClubId = 5
                },
                new ClubEvents
                {
                    Name = "Reading At Fall Fest",
                    Description = "We hold a corner at Fall Fest where we set up a library of our favorite book",
                    PointKey = "W3H7E-28JD3",
                    PointValue = 15,
                    ClubId = 5
                },
                new ClubEvents
                {
                    Name = "Discovery",
                    Description = "We share about our favorite authors",
                    PointKey = "CNWU3-28JDN",
                    PointValue = 5,
                    ClubId = 5
                },
                new ClubEvents
                {
                    Name = "Writing Books Seminar",
                    Description = "We invite some famous book authors to show us how to write books",
                    PointKey = "WN2O3-43HDS",
                    PointValue = 10,
                    ClubId = 5
                }
            );

            context.events.AddOrUpdate(
                new Events
                {
                    Name = "Fall Fest",
                    Description = "Fall Fest is the big event of the Fall that Forsyth Tech holds",
                    RegularKey = "Y273H-DJ273",
                    RegularValue = 25,
                    VolunteerKey = "28JNW-283JD",
                    VolunteerValue = 50
                },
                new Events
                {
                    Name = "",
                    Description = "Fall Fest is the big event of the Fall that Forsyth Tech holds",
                    RegularKey = "BCHD2-SNWJ8",
                    RegularValue = 25,
                    VolunteerKey = "CBH63-DHF34",
                    VolunteerValue = 50
                },
                new Events
                {
                    Name = "Fall Fest",
                    Description = "Fall Fest is the big event of the Fall that Forsyth Tech holds",
                    RegularKey = "HWNS7-3YHD2",
                    RegularValue = 25,
                    VolunteerKey = "KDME2-2DN43",
                    VolunteerValue = 50
                },
                new Events
                {
                    Name = "Fall Fest",
                    Description = "Fall Fest is the big event of the Fall that Forsyth Tech holds",
                    RegularKey = "BDGD8-273HJ",
                    RegularValue = 25,
                    VolunteerKey = "CGDHG-237IH",
                    VolunteerValue = 50
                },
                new Events
                {
                    Name = "Fall Fest",
                    Description = "Fall Fest is the big event of the Fall that Forsyth Tech holds",
                    RegularKey = "NCJD0-72J98",
                    RegularValue = 25,
                    VolunteerKey = "OLKDY-27364",
                    VolunteerValue = 50
                }
            );

        }
    }
}
