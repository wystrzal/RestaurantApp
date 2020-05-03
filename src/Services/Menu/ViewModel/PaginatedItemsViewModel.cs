using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.ViewModel
{
    public class PaginatedItemsViewModel<TEntity> where TEntity : class
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int Count { get; private set; }

        public IEnumerable<TEntity> Data { get; private set; }

        public PaginatedItemsViewModel(int pageIndex, int count, IEnumerable<TEntity> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = 5;
            this.Count = count;
            this.Data = data;
        }
    }
}
