namespace Challenge2.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Challenge2Context : DbContext
    {
        // Your context has been configured to use a 'Challenge2Context' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Challenge2.Models.Challenge2Context' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Challenge2Context' 
        // connection string in the application configuration file.
        public Challenge2Context()
            : base("name=Challenge2Context")
        {
        }

        //static MyContext()
        //{
        //    DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}