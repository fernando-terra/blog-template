namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Titulo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "Categoria", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Resumo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Resumo", c => c.String());
            AlterColumn("dbo.Posts", "Categoria", c => c.String());
            AlterColumn("dbo.Posts", "Titulo", c => c.String());
        }
    }
}
