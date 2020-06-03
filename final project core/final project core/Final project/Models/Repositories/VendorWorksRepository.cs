using Final_project.Models.our_tables;
using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.Repositories
{
    public class VendorWorksRepsitory
    {
        ProjectDbcontext _db;
        public VendorWorksRepsitory(ProjectDbcontext db)
        {
            _db = db;
        }
        public List<VendorWorks> GetAll()
        {
            return _db.vendorWorks.OrderBy(o => o.last_updated).ToList();
        }

        public VendorWorks GetOnebyId(int id)
        {
            VendorWorks work = _db.vendorWorks.FirstOrDefault(a => a.Id == id);
            return work;
        }

       

        public bool Edit(VendorWorks newWork)
        {
            VendorWorks Work = _db.vendorWorks.FirstOrDefault(a => a.Id == newWork.Id);
            Work.Image = newWork.Image;
            Work.category_id = newWork.category_id;
            Work.description = newWork.description;
            Work.title = newWork.title;
            Work.last_updated = newWork.last_updated;
            _db.SaveChanges();
            return true;
        }

        public bool Add(VendorWorks Work)
        {
            _db.vendorWorks.Add(Work);
            _db.SaveChanges();
            return true;
        }

        public bool addInVendor(VenBudget vendor)
        {
            _db.venBudgets.Add(vendor);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            VendorWorks work = _db.vendorWorks.FirstOrDefault(a => a.Id == id);
            _db.vendorWorks.Remove(work);
            _db.SaveChanges();
            return true;
        }

       
        public List<catagory> GetVendorCateg(string id)
        {
            List<catagory> catList = new List<catagory>();
            List<int> catListInt = new List<int>();
            var list = _db.vendors.Where(a => a.vendor_id == id).ToList();                    
            foreach(var n in list)
            {
                catListInt.Add(n.catt_id);
            }
            foreach(var ct in catListInt)
            {
               catagory categ= _db.catagories.FirstOrDefault(a => a.cat_Id == ct);
                //if (catList.FirstOrDefault(a => a.cat_Id == categ.cat_Id) == null)
                //{
                    catList.Add(categ);
                //}
                
            }


            return catList;
        }



        public List<catagory> GetNoBudgetCateg(string id)
        {
            List<catagory> catList = new List<catagory>();
            List<int> catListInt = new List<int>();
            var list = _db.vendors.Where(a => a.vendor_id == id).ToList();
            foreach (var n in list)
            {
                catListInt.Add(n.catt_id);
            }
            foreach (var ct in catListInt)
            {
               
               

              if (_db.venBudgets.FirstOrDefault(a => a.catt_id == ct) == null)
                {
                   
                    catagory categ = _db.catagories.FirstOrDefault(a => a.cat_Id == ct);
                    catList.Add(categ);
                }

            }


            return catList;
        }

        public List<VenBudget> getVenData(string id)
        {
            
            var list = _db.venBudgets.Where(a => a.vendor_id == id ).ToList();
            return list;
        }
        public List<catagory> GetAllCategories()
        {
            return _db.catagories.ToList();
        }

        public VenBudget Getbudget(string id,int id1)
        {
           VenBudget bd = _db.venBudgets.FirstOrDefault(a => a.catt_id ==id1&& a.vendor_id==id);
            return bd;
        }


        public bool EditBudgetData(VenBudget bd)
        {
            VenBudget bData = _db.venBudgets.FirstOrDefault(a => a.vendor_id == bd.vendor_id && a.catt_id==bd.catt_id );
            bData.catt_id = bd.catt_id;
            bData.Cat_budget = bd.Cat_budget;
            bData.vendor_id = bd.vendor_id;
            _db.SaveChanges();
            return true;
        }

        public int GetTotalBudget(string id , int id1)
        {
            List<Booking> list = new List<Booking>();
            int total=0;
            list= _db.booking.Where(a => a.VendorId == id && a.CategoryId == id1 ).ToList();
            foreach(var i in list)
            {
                total += i.Cost;
            }

            return total;
        }

        public int GetTotalBudgetPending(string id, int id1)
        {
            List<Booking> list = new List<Booking>();
            int total = 0;
            list = _db.booking.Where(a => a.VendorId == id && a.CategoryId == id1 && a.Status == false).ToList();
            foreach (var i in list)
            {
                total += i.Cost;
            }

            return total;
        }

        public int GetTotalBudgetPaid(string id, int id1)
        {
            List<Booking> list = new List<Booking>();
            int total = 0;
            list = _db.booking.Where(a => a.VendorId == id && a.CategoryId == id1 && a.Status == true).ToList();
            foreach (var i in list)
            {
                total += i.Cost;
            }

            return total;
        }
    }
}
