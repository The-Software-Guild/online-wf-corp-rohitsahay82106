namespace DVD_Catalogue.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using DVD.Models.Tables;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVD_Catalogue.Models.DvdCatalogEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVD_Catalogue.Models.DvdCatalogEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Rating.AddOrUpdate(
                    r=>r.RatingId,
                    new Rating
                    {
                        RatingId="G",
                        RatingDescription= "Suitable for audiences of all age"
                    },
                    new Rating
                    {
                        RatingId = "PG",
                        RatingDescription = "Parental Guidance"
                    },
                    new Rating
                    {
                        RatingId = "PG-13",
                        RatingDescription = "Parental Guidance and not suitable for kids below 13"
                    },
                    new Rating
                    {
                        RatingId = "R",
                        RatingDescription = "Restricted, not suitable for anyone below 18"
                    }
                );
            context.SaveChanges();

            context.Dvd.AddOrUpdate(
                    d=> d.Title,
                    new Dvd
                    {
                        Title = "Taare Zameen Par",
                        ReleaseYear = 2015,
                        Director = "Kalpana Yadav",
                        RatingId = "PG",
                        Notes = "Excellent movie for parents of school going kids"
                    }
                );

            context.SaveChanges();
        }
    }
}
