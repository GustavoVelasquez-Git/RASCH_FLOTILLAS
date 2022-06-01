using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RASCH_FLOTILLAS.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboBusiness();


    }
}