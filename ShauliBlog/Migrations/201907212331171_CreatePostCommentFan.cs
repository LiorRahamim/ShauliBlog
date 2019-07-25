namespace ShauliBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePostCommentFan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fan",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sn = c.String(nullable: false),
                        name = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        birthday = c.DateTime(nullable: false),
                        clubSeniority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fan");
        }
    }
}
