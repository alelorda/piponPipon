using Pipo_Pipon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipo_Pipon.Repo
{
    public class BebidaRepo
    {
        private pipopiponEntities db;
        public BebidaRepo()
        {
            db = new pipopiponEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in db.Bebidas
                                  select new SelectListItem()
                                  {
                                      Text = obj.bebidaNombre,
                                      Value = obj.bebidaId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;

        }

    }
}