namespace fluentRibon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        PublishYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.PersonBooks",
                c => new
                    {
                        Person_PersonId = c.Long(nullable: false),
                        Book_BookId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonId, t.Book_BookId })
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Book_BookId);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_GenreId = c.Int(nullable: false),
                        Book_BookId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_GenreId, t.Book_BookId })
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Genre_GenreId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.PersonBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.PersonBooks", "Person_PersonId", "dbo.People");
            DropIndex("dbo.GenreBooks", new[] { "Book_BookId" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_GenreId" });
            DropIndex("dbo.PersonBooks", new[] { "Book_BookId" });
            DropIndex("dbo.PersonBooks", new[] { "Person_PersonId" });
            DropTable("dbo.GenreBooks");
            DropTable("dbo.PersonBooks");
            DropTable("dbo.Genres");
            DropTable("dbo.People");
            DropTable("dbo.Books");
        }
    }
}
