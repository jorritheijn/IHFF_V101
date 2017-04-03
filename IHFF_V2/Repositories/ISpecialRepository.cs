using IHFF_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF_V2.Repositories
{
    interface IspecialRepository
    {
        DetailSpecialViewModel GetSpecificSpecial(int Id);
    }
}