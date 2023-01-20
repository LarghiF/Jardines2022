using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Helpers
{
    public class DefaultValues
    {
        public static SelectList ItemsPerPageList
        {
            get
            {
                return(new SelectList(new List<int>{ 5,10,15,20,25,50,100},selectedValue:10));
            }
        }
    }
}