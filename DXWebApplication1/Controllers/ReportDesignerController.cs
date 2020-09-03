using DevExpress.DataAccess.Sql;
using DevExpress.Web.Mvc.Controllers;
using DevExpress.XtraReports.Web.ReportDesigner;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
  public class ReportDesignerController : ReportDesignerApiController
  {
        public override ActionResult Invoke()
        {
            var result = base.Invoke();
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            return result;
        }

        public ActionResult GetReportDesignerModel(string reportUrl)
      {
          Response.AppendHeader("Access-Control-Allow-Origin", "*");

          string modelJsonScript =
              new ReportDesignerClientSideModelGenerator()
              .GetJsonModelScript(
                  reportUrl,                 // The URL of a report that is opened in the Report Designer when the application starts.
                  GetAvailableDataSources(), // Available data sources in the Report Designer that can be added to reports.
                  "ReportDesigner/Invoke",   // The URI path of the controller action that processes requests from the Report Designer.
                  "WebDocumentViewer/Invoke",// The URI path of the controller action that processes requests from the Web Document Viewer.
                  "QueryBuilder/Invoke"      // The URI path of the controller action that processes requests from the Query Builder.
              );
          return Content(modelJsonScript, "application/json");
      }

      Dictionary<string, object> GetAvailableDataSources()
      {
          //SqlConnection connection = new SqlConnection("data source=(localdb)/mssqllocaldb;initial catalog=aspnet-DXWebApplication1-20200900153700;integrated security=SSPI");
          //connection.Open();
          var dataSources = new Dictionary<string, object>();
          SqlDataSource ds = new SqlDataSource("Northwind_Connection");
          var productsQuery = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("Products");
          var customersQuery = SelectQueryFluentBuilder.AddTable("Customers").SelectAllColumns().Build("Customers");
          ds.Queries.Add(productsQuery);
          ds.Queries.Add(customersQuery);
          ds.RebuildResultSchema();
          dataSources.Add("SqlDataSource", ds);
          return dataSources;
      }
  }
}