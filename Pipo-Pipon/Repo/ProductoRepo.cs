using Pipo_Pipon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipo_Pipon.Repo
{
    public class ProductoRepo
    {
        private pipopiponEntities db;
        public ProductoRepo()
        { 
           db = new pipopiponEntities(); 
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in db.Comidas
                                  select new SelectListItem()
                                  {
                                      Text = obj.comidaNombre,
                                      Value = obj.itemId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;

        }
    }
}