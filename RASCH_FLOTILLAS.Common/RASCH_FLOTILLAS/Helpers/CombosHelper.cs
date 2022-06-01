using Microsoft.AspNetCore.Mvc.Rendering;
using RASCH_FLOTILLAS.Data;
using System.Collections.Generic;
using System.Linq;

namespace RASCH_FLOTILLAS.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboBusiness()
        {
            List<SelectListItem> list = _context.Business.Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una empresa...]",
                Value = "0"
            });

            return list;
        }
    }
}