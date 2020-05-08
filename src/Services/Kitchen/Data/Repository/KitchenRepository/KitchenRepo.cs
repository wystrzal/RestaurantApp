using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Data.Repository.KitchenRepository
{
    public class KitchenRepo : BaseRepository, IKitchenRepo
    {
        private readonly DataContext dataContext;

        public KitchenRepo(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }


    }
}
