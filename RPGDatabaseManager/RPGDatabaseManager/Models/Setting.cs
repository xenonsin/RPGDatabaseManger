using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RPGDatabaseManager
{
    public class Setting
    {
        public string Header { get; set; }

        public Frame ViewPage { get; set; }

        private object page;

        public Setting(object _page,string header)
        {
            this.page = _page;
            this.Header = header;
            ViewPage = new Frame();
        }

        public void LoadPage()
        {
            ViewPage.Navigate(this.page);
        }


    }
}
