using System;
using System.Collections.Generic;
using System.Text;

namespace myProject.PagingModel
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Items { get; set; }
    }
}
