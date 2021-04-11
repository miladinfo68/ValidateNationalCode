
using System.Linq;
using System.Web.Mvc;
//=================================
using CheckInvalidCodeMeli.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace CheckInvalidCodeMeli.Controllers
{
    public class HomeController : Controller
    {
        private CheckCodeMeliClass objCheckCodeMeli;
        public List<SqlViewVM> newModel;
        public ActionResult Index()
        {
            using (var db = new amozeshEntities())
            {

                var fostad = (from x in db.fostads
                              join y in db.fostad_head on x.code_ostad equals y.ocode
                              where x.vaz_fali == 1
                              select new
                              {
                                  x.code_ostad,
                                  x.idd_meli,
                              }).ToList();


                var fOstadList_amozeshDb = (from x in fostad
                                            select new IndexVM
                                            {
                                                CodeOstad = x.code_ostad.ToString(),
                                                CodeMeli = x.idd_meli,
                                                DbName = "AmodeshDb"
                                            }).ToList();

                var Os_tbList_thesesDb = db.vOs_tb_TheseDb.Select(s => new IndexVM { CodeOstad = s.id_os.ToString(), CodeMeli = s.code_meli, DbName = "ThesesDb" }).ToList();
                objCheckCodeMeli = new CheckCodeMeliClass();

                List<IndexVM> finalList = objCheckCodeMeli.GetInvalidList(fOstadList_amozeshDb, Os_tbList_thesesDb);
                ViewBag.TotalCount = finalList.Count;
                return View(finalList);

            }

        }

        //################################################
        //################################################

        public ActionResult SqlView()
        {

            using (var ctx = new amozeshEntities())
            {
                var dd = ctx.fn_GetInvalidNationalCodesList();
                newModel = new List<SqlViewVM>();
                newModel = dd.Select(x => new SqlViewVM
                {
                    CodeOstad = x.code_ostad.ToString(),
                    IddMeli = x.idd_meli,
                    Name = x.name,
                    Family = x.family,
                    DbName = x.dbName

                }).ToList();
                ViewBag.TotalCount = newModel.Count;
                TempData["excel"] = newModel;
                return View(newModel);
            }
        }

        //################################################
        //################################################


        
        public void ExportExcelFile()
        {
            var gv = new GridView();
            var model = TempData["excel"];
            gv.DataSource = model;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel"; Response.Charset = "utf-8";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            //return View("SqlView",model);

        }

    }
}