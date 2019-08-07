
using System;
using System.Web;
using System.Data.Entity;
using ShauliBlog.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace ShauliBlog.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var fans = new List<Fan>
            {
                new Fan{ID=1, name="Alexander",sn="Choen", city="Tel Aviv", birthday=DateTime.Parse("1992-04-19"), gender=Gender.male, clubSeniority=1},
                new Fan{ID=2, name="yoni",sn="tzimki", city="Kfar saba", birthday=DateTime.Parse("1998-04-08"), gender=Gender.male, clubSeniority=4},
                new Fan{ID=3, name="moshe",sn="bruh", city="Herzeliya", birthday=DateTime.Parse("2001-04-03"), gender=Gender.male, clubSeniority=3},
                new Fan{ID=4, name="ronen",sn="yitzhaki", city="Eliat", birthday=DateTime.Parse("1994-05-07"), gender=Gender.male, clubSeniority=1},
                new Fan{ID=5, name="roti",sn="Choen", city="Rehovot", birthday=DateTime.Parse("1942-03-01"), gender=Gender.female, clubSeniority=2},
                new Fan{ID=6, name="smadar",sn="shany", city="Tzur Yigal", birthday=DateTime.Parse("1998-03-03"), gender=Gender.female, clubSeniority=4},
                new Fan{ID=7, name="yakov",sn="simha", city="Tel Aviv", birthday=DateTime.Parse("1978-08-08"), gender=Gender.male, clubSeniority=4},
                new Fan{ID=8, name="shulamit",sn="iptah", city="Yafo", birthday=DateTime.Parse("2000-02-15"), gender=Gender.female, clubSeniority=2},
                new Fan{ID=9, name="ronit",sn="mazal", city="Bet Dagan", birthday=DateTime.Parse("1975-01-29"), gender=Gender.female, clubSeniority=3},
                new Fan{ID=10, name="eyal",sn="saga", city="Tel Aviv", birthday=DateTime.Parse("1964-03-07"), gender=Gender.male, clubSeniority=1},
                new Fan{ID=11, name="dana",sn="kamilio", city="Rehovot", birthday=DateTime.Parse("1999-02-01"), gender=Gender.female, clubSeniority=3}
            };

            fans.ForEach(fan => context.Fans.Add(fan));

            var posts = new List<Post>
            {
            new Post{Id=0, Author="Ilay", AuthorSite="https://www.colman.ac.il/", PublishDate=DateTime.Parse("2019-03-03"), Content="In India, natural calamities such as floods, droughts, cyclones and earthquakes have caused widespread damage and disruption. Disaster management emphasizes the need for incorporating multi-functional, multi-disciplinary and sectoral approach involving engineering, social and financial processes. Unfortunately, India does not have a good record on the front of disaster management.", Image="data:image/jpeg;base64,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",
            Title="My opinion on this blog",},
            new Post{Id=1, Author="May", AuthorSite="https://www.colman.ac.il/", PublishDate=DateTime.Parse("2019-05-01"), Content="Global warming or climate change has become a worldwide concern. It is gradually developing into an unprecedented environmental crisis evident in melting glaciers, changing weather patterns, rising sea levels, floods, cyclones and droughts. Global warming implies an increase in the average temperature of the Earth due to entrapment of greenhouse gases in the earth’s atmosphere. There is a crying need to raise awareness about global warming if we have to save the world from disaster.Here we are providing you some useful articles on global warming under various categories according to varying words limits.",
            Title="A few words on gloobal worming", Video=" https://www.youtube.com/embed/TkRdM8db_qY"},
            new Post{Id=2, Author="Alex", AuthorSite="https://www.colman.ac.il/", PublishDate=DateTime.Parse("2019-03-07"), Content="Meditation is exploring. It’s not a fixed destination. Your head doesn’t become vacuumed free of thought, utterly undistracted. It’s a special place where each and every moment is momentous. When we meditate we venture into the workings of our minds: our sensations (air blowing on our skin or a harsh smell wafting into the room), our emotions (love this, hate that, crave this, loathe that) and thoughts (wouldn’t it be weird to see an elephant playing a trumpet). Mindfulness meditation asks us to suspend judgment and unleash our natural curiosity about the workings of the mind, approaching our experience with warmth and kindness, to ourselves and others",
            Title="Mindfulness Meditation", Video="https://www.youtube.com/embed/aexnRWrqxLI"}
            };

            posts.ForEach(post => context.Posts.Add(post));


            var comments = new List<Comment>
            {
            new Comment{Id=0, PostId=0,  Title="Great Gob!", Author="May", AuthorSite="https://www.udemy.com/", Content="I love this post very much" },
            new Comment{Id=1, PostId=1, Title="My website is better!", Author="Shmulik", AuthorSite="https://www.ebay.com/", Content="See my site!" },
            new Comment{Id=2, PostId=1, Title="Worring", Author="sara", AuthorSite="https://www.ebay.com/", Content="Earth is dommed" },
            new Comment{Id=3, PostId=2, Title="Good content, thanks", Author="yaron", AuthorSite="https://www.ebay.com/", Content="One question tho, how long should I do it as a beginner?" },
            new Comment{Id=4, PostId=2, Title="Deep..", Author="Shmulik", AuthorSite="https://www.ebay.com/", Content="My mother is doing it everyday, now she feels amazing" },
            new Comment{Id=5, PostId=0, Title="Thanks for sharing", Author="aharon", AuthorSite="https://www.ebay.com/", Content="Didn't about like that" },
            new Comment{Id=6, PostId=2, Title="Intersting", Author="ronit", AuthorSite="https://www.ebay.com/", Content= "I'm gonna try it myself aswell!" },
            };

            comments.ForEach(comment => context.Comments.Add(comment));


            // Adding idan, ofek, guy and lior as admins
            ApplicationDbContext accountsContext = new ApplicationDbContext();
            IdentityRole adminRole = new IdentityRole { Name = "Admin" };
            accountsContext.Roles.Add(adminRole);

            var passwordHash = new PasswordHasher();
            string guyPass = passwordHash.HashPassword("Gg1234!");
            string ofekPass = passwordHash.HashPassword("Oo1234!");
            string idanPass = passwordHash.HashPassword("Ii1234!");
            string liorPass = passwordHash.HashPassword("Ll1234!");

            ApplicationUser guy = new ApplicationUser { UserName = "guy@gmail.com", Email = "guy@gmail.com", PasswordHash = guyPass, SecurityStamp = Guid.NewGuid().ToString(), LockoutEnabled = true };
            ApplicationUser idan = new ApplicationUser { UserName = "idan@gmail.com", Email = "idan@gmail.com", PasswordHash = idanPass, SecurityStamp = Guid.NewGuid().ToString(), LockoutEnabled = true };
            ApplicationUser ofek = new ApplicationUser { UserName = "ofek@gmail.com", Email = "ofek@gmail.com", PasswordHash = ofekPass, SecurityStamp = Guid.NewGuid().ToString(), LockoutEnabled = true };
            ApplicationUser lior = new ApplicationUser { UserName = "lior@gmail.com", Email = "lio@gmail.com", PasswordHash = liorPass, SecurityStamp = Guid.NewGuid().ToString(), LockoutEnabled = true };

            accountsContext.Users.Add(guy);
            accountsContext.Users.Add(idan);
            accountsContext.Users.Add(lior);
            accountsContext.Users.Add(ofek);

            IdentityUserRole guyAdminRole = new IdentityUserRole()
            {
                RoleId = adminRole.Id,
                UserId = guy.Id
            };

            IdentityUserRole idanAdminRole = new IdentityUserRole()
            {
                RoleId = adminRole.Id,
                UserId = idan.Id
            };

            IdentityUserRole liorAdminRole = new IdentityUserRole()
            {
                RoleId = adminRole.Id,
                UserId = lior.Id
            };

            IdentityUserRole ofekAdminRole = new IdentityUserRole()
            {
                RoleId = adminRole.Id,
                UserId = ofek.Id
            };

            guy.Roles.Add(guyAdminRole);
            idan.Roles.Add(idanAdminRole);
            lior.Roles.Add(liorAdminRole);
            ofek.Roles.Add(ofekAdminRole);

            accountsContext.SaveChanges();
        }
    }
}