using PM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DAL
{
    /// <summary>
    /// PM database initializer class.
    /// </summary>
    public class PMDbInitializer : DropCreateDatabaseAlways<PMAppContext>
    {
        protected override void Seed(PMAppContext context)
        {
            RoleEntity ownerRole = new RoleEntity()
            {
                RoleId = Guid.NewGuid(),
                Name = "Owner"
            };

            RoleEntity adminRole = new RoleEntity()
            {
                RoleId = Guid.NewGuid(),
                Name = "Administrator"
            };

            RoleEntity userRole = new RoleEntity()
            {
                RoleId = Guid.NewGuid(),
                Name = "User"
            };

            RoleEntity clientRole = new RoleEntity()
            {
                RoleId = Guid.NewGuid(),
                Name = "Client"
            };

            context.Roles.Add(ownerRole);
            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);
            context.Roles.Add(clientRole);

            context.SaveChanges();


            base.Seed(context);
        }
    }
}
