using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.DAL
{
   public class DbInterface
    {
        private WorkshopEntities entities;
       public DbInterface() {
            entities = new WorkshopEntities();
        }

        public List<technology> GetTechnologyList()
         {
             List<technology> techList = new List<technology>();
             try
             {
                 var techies = entities.technologies.Where(x => x.status == true).ToList();
                 foreach (var item in techies)
                 {
                    techList.Add(new technology
                     {
                         techID = item.techID,
                         name = item.name
                         
                     });
                 }
             }
             catch (Exception ex) {
                
            }
             return techList;
         }
    }
}
