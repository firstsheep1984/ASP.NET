using System.Web.Mvc;
using VedioRentalData;

namespace VedioRentalImprove.Controllers
{
    public abstract class BaseController:Controller
    {
        public IVedioRentalData Data { get;  }
        public BaseController(IVedioRentalData data)
        {
            this.Data = data;
        }
    }
}