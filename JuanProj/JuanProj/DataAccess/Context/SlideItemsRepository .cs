using Core.Entities;
using DataAccess.Contex;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context;

public class SlideItemsRepository : Repository<SlideItem>, ISlideItemsRepository
{
    public SlideItemsRepository(AppDbContext context) : base(context)
    {
    }
}