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
    public class PMDbInitializer : DropCreateDatabaseIfModelChanges<PMAppContext>
    {
        protected override void Seed(PMAppContext context)
        {
            base.Seed(context);
            
        }
    }
}
