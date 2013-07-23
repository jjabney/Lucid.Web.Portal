using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lucid.Web.Portal.Models
{
    public class LucidWebPortalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        public LucidWebPortalContext()
        {
        
                System.Data.Entity.Database.SetInitializer(new LucidWebPortalContextInitializer());

                
              
        }

    
   
        public DbSet<Lucid.Web.Portal.Models.Message> Messages { get; set; }

        public DbSet<Lucid.Web.Portal.Models.Video> Videos { get; set; }

    }
}