using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.ViewModel;
using Workshop.DAL;
using Workshop.Common;
namespace Workshop.Core
{
   public class WorkshopBL
    {
        DbInterface dbInterface; 

        public WorkshopBL()
        {
            dbInterface = new DbInterface();
            
        }

        public void WorkshopReg(WorkshopViewModel WorkshopVM)
        {
          
            SqlDbInterface sqlDbInterface = new SqlDbInterface();
            try
            {
                wssregistration workshopRgs = new wssregistration
                {
                    name = WorkshopVM.name,
                    location = WorkshopVM.location,
                    technology = WorkshopVM.technology,
                    email = WorkshopVM.email,
                    contactNo = WorkshopVM.contactNo,
                    course = WorkshopVM.course,
                    branch = WorkshopVM.branch,
                    semester = WorkshopVM.semester,
                    college = WorkshopVM.college
                };

                sqlDbInterface.WorkshopReg(workshopRgs);

            }
            catch
            {
                
            }
                
        }
    }
}
