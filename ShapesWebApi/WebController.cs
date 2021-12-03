using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShapesController;
using Shape4ViewAdapter;

namespace ShapesWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {

        ShapesController.Controller ctrl;

        public WebController()
        {
            ctrl = new ShapesController.Controller(new DSFactory(),
                OneMorePercent);
        }

        public void OneMorePercent() { }

        [HttpGet("{id}")]
        public ActionResult<List<Shape4View>> Get(int id)
        {
            ctrl.CalcReport(id);
            return new ActionResult<List<Shape4View>>(ctrl.GetList().ToList()); 
            //db.Students.ToListAsync();
        }
    }
}
