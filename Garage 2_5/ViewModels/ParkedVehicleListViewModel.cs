using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2_5.ViewModels
{
    public class ParkedVehicleListViewModel
    {
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; set; }
        public SelectList SearchVehicleTypes { get; set; }
    }
}