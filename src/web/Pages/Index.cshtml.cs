using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using infrastructure.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages
{
    public class IndexModel : PageModel
    {
        #region Fields
        protected int _TestCount = -1;
        #endregion

        #region Properties
        protected IDbMgr DB { get; set; }

        public int TestCount
        {
            get { return _TestCount; }
            set { _TestCount = value; }
        }
        #endregion

        public IndexModel(IDbMgr db)
        {
            DB = db;
        }

        public void OnGet()
        {
            TestCount = SpaceEventsForDay(DateTime.Now).CurrentCount;
        }

        public ISpaceEventGroup SpaceEventsForDay(DateTime forDate)
        {
            return SpaceEventsForDay(forDate.Month, forDate.Day);
        }

        public ISpaceEventGroup SpaceEventsForDay(int month, int day)
        {
            // if (IDB == null) { ReadData(); }

            if (DB != null)
            {
                return DB.GetGroupForDate(new DateTime(2020, month, day));
            }

            return null;
        }
    }
}
