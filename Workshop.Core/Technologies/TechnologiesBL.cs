using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.ViewModel;
using Workshop.DAL;

namespace Workshop.Core.Technologies
{
   public class TechnologiesBL
    {
        DbInterface dbInterface;
        public TechnologiesBL()
        {
            dbInterface = new DbInterface();
        }

        public List<TechnologiesViewModel> GetTechnologyList()
         {
             List<TechnologiesViewModel> technologylist = new List<TechnologiesViewModel>();
             try
             {
                 List<technology> technologies = new List<technology>();
                 technologies = dbInterface.GetTechnologyList();
                 foreach (var item in technologies)
                 {
                    technologylist.Add(new TechnologiesViewModel
                    {
                         techID = item.techID,
                         name = item.name
                     });
                 }

             }
             catch (Exception ex)
             {
             }
             return technologylist;
         }
    }
}
