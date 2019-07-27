
using System;
using System.Web;
using System.Data.Entity;
using ShauliBlog.Models;
using System.Collections.Generic;

namespace ShauliBlog.DAL
{
    public class FansInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var fans = new List<Fan>
            {
            new Fan{ID=1, name="Alexander",sn="Choen", birthday=DateTime.Parse("1992-04-19"), gender="male", clubSeniority=1},
            new Fan{ID=1, name="yoni",sn="tzimki", birthday=DateTime.Parse("1998-04-08"), gender="male", clubSeniority=4},
            new Fan{ID=1, name="moshe",sn="bruh", birthday=DateTime.Parse("2001-04-03"), gender="male", clubSeniority=3},
            new Fan{ID=1, name="ronen",sn="yitzhaki", birthday=DateTime.Parse("1994-05-07"), gender="male", clubSeniority=1},
            new Fan{ID=1, name="roti",sn="Choen", birthday=DateTime.Parse("1942-03-01"), gender="female", clubSeniority=2},
            new Fan{ID=1, name="smadar",sn="shany", birthday=DateTime.Parse("1998-03-03"), gender="female", clubSeniority=4},
            new Fan{ID=1, name="yakov",sn="simha", birthday=DateTime.Parse("1978-08-08"), gender="male", clubSeniority=4},
            new Fan{ID=1, name="shulamit",sn="iptah", birthday=DateTime.Parse("2000-02-15"), gender="female", clubSeniority=2},
            new Fan{ID=1, name="ronit",sn="mazal", birthday=DateTime.Parse("1975-01-29"), gender="female", clubSeniority=3},
            new Fan{ID=1, name="eyal",sn="saga", birthday=DateTime.Parse("1964-03-07"), gender="male", clubSeniority=1},
            new Fan{ID=1, name="dana",sn="kamilio", birthday=DateTime.Parse("1999-02-01"), gender="female", clubSeniority=3},

            };

            fans.ForEach(fan => context.Fans.Add(fan));
            context.SaveChanges();
        }
        }
}