using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Syncfusion.XlsIO;
using System.IO;
using System.Web.Services;

namespace AutomatizacionPI
{
    public partial class _Default : Page
    {
        public List<string> periodos = new List<string>();
        public List<string> periodoActualisl = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadPeriods();
                loadPeriodoActual();
                Page.Header.DataBind();
            }
            else
            {
              
            }

        }

        public void loadPeriods()
        {

            DateTime fechaini = DateTime.Now.AddMonths(-12);
            DateTime periodoAnterior = DateTime.Now.AddMonths(-1);
            var orderList = periodos.OrderByDescending(periodos => periodos);

            while (fechaini.ToString("yyyyMM") != DateTime.Now.ToString("yyyyMM"))
            {

                periodos.Add(fechaini.ToString("yyyyMM"));
                 orderList = periodos.OrderByDescending(periodos => periodos);
                fechaini = fechaini.AddMonths(1);

            }
            DropDownListMes.DataSource=orderList;
            DropDownListMes.DataBind();

        }
        public void loadPeriodoActual()
        {
            DateTime periodoActual = DateTime.Now.AddMonths(0);
            periodoActualisl.Add(periodoActual.ToString("yyyyMM"));
            DropDownListActual.DataSource = periodoActualisl;
            DropDownListActual.DataBind();

        }


        [WebMethod]
        public  static string  DowndloadExcel(string period)
        {
            byte[] file = new Dao.Get_File()._getFile(period).ToArray();

            return Convert.ToBase64String(file, 0, file.Length);
        }
        public static string DowndloadExcel2(string period)
        {
            byte[] file = new Dao.Get_File()._getFile(period).ToArray();

            return Convert.ToBase64String(file, 0, file.Length);
        }

    }
}