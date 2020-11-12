namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (id , Type) VALUES (1 , 'Comedy')");
            Sql("INSERT INTO Genres (id , Type) VALUES (2 , 'Action')");
            Sql("INSERT INTO Genres (id , Type) VALUES (3 , 'Family')");
            Sql("INSERT INTO Genres (id , Type) VALUES (4 , 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
