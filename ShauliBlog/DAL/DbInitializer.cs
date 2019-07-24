
using System;
using System.Web;
using System.Data.Entity;
using ShauliBlog.Models;
using System.Collections.Generic;

namespace ShauliBlog.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var fans = new List<Fan>
            {
            new Fan{Id=1, Name="Alexander",Sn="Choen", Birthday=DateTime.Parse("1992-04-19"), Gender="male", ClubSeniority=1},
            new Fan{Id=2, Name="yoni",Sn="tzimki", Birthday=DateTime.Parse("1998-04-08"), Gender="male", ClubSeniority=4},
            new Fan{Id=3, Name="moshe",Sn="bruh", Birthday=DateTime.Parse("2001-04-03"), Gender="male", ClubSeniority=3},
            new Fan{Id=4, Name="ronen",Sn="yitzhaki", Birthday=DateTime.Parse("1994-05-07"), Gender="male", ClubSeniority=1},
            new Fan{Id=5, Name="roti",Sn="Choen", Birthday=DateTime.Parse("1942-03-01"), Gender="female", ClubSeniority=2},
            new Fan{Id=6, Name="smadar",Sn="shany", Birthday=DateTime.Parse("1998-03-03"), Gender="female", ClubSeniority=4},
            new Fan{Id=7, Name="yakov",Sn="simha", Birthday=DateTime.Parse("1978-08-08"), Gender="male", ClubSeniority=4},
            new Fan{Id=8, Name="shulamit",Sn="iptah", Birthday=DateTime.Parse("2000-02-15"), Gender="female", ClubSeniority=2},
            new Fan{Id=9, Name="ronit",Sn="mazal", Birthday=DateTime.Parse("1975-01-29"), Gender="female", ClubSeniority=3},
            new Fan{Id=10, Name="eyal",Sn="saga", Birthday=DateTime.Parse("1964-03-07"), Gender="male", ClubSeniority=1},
            new Fan{Id=11, Name="dana",Sn="kamilio", Birthday=DateTime.Parse("1999-02-01"), Gender="female", ClubSeniority=3},
            };

            fans.ForEach(fan => context.Fans.Add(fan));
            context.SaveChanges();
        }
        }
}