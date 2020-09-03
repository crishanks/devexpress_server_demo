using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;

namespace DXWebApplication1
{
    public class ReportStorageWebExtension1 : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        public Dictionary<string, XtraReport> Reports = new Dictionary<string, XtraReport>();

        public ReportStorageWebExtension1()
        {
            Reports.Add("Products", new XtraReport1());
        }

        public override bool CanSetData(string url)
        {
            return base.CanSetData(url);
        }
        public override bool IsValidUrl(string url)
        {
            return base.IsValidUrl(url);
        }

        public override byte[] GetData(string url)
        {
            return base.GetData(url);
        }

        public override Dictionary<string, string> GetUrls()
        {
            return Reports.ToDictionary(x => x.Key, y => y.Key);
        }

        public override void SetData(DevExpress.XtraReports.UI.XtraReport report, string url)
        {
            if (Reports.ContainsKey(url))
            {
                Reports[url] = report;
            }
            else
            {
                Reports.Add(url, report);
            }
        }

        public override string SetNewData(DevExpress.XtraReports.UI.XtraReport report, string defaultUrl)
        {
            SetData(report, defaultUrl);
            //return base.SetNewData(report, defaultUrl);
            return defaultUrl;
        }
    }
}
