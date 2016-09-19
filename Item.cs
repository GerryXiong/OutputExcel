using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutputExcel
{
    public class Item
    {
        public Item(String name, int pageSize, String userName, String pwd)
        {
            this.name = name;
            this.pageSize = pageSize;
            this.userName = userName;
            this.pwd = pwd;
        }
        public String name { get; set; }
        public int pageSize { get; set; }
        public String userName { get; set; }
        public String pwd { get; set; }
    }
}
