﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class ForPaging
    {
        public int NowPage{ get; set; }
        public int MaxPage{ get; set; }
        public int ItemNo{ get { return 1; } }

        public ForPaging()
        {
            this.NowPage = 1;
        }
        public ForPaging(int Page)
        {
            this.NowPage = Page;
        }
        public void SetRightPage()
        {
            if (this.NowPage < 1)
            {
                this.NowPage = 1;
            }
            else if (this.NowPage > this.MaxPage)
            {
                this.NowPage = this.MaxPage;
            }

            if (this.MaxPage == 0)
            {
                this.NowPage = 1;
            }
        }
        
        public void SetMaxPage(int Total)
        {
            MaxPage = (int)Math.Ceiling(Convert.ToDouble(Total / ItemNo));
        }
    }
}