using System;

namespace Portal.Web.Data.Attributes
{
    public class DataSource : Attribute
    {
        public string DataSourceName { get; set; }

        public DataSource(string dataSourceName)
        {
            DataSourceName = DataSourceName;
        }
    }
}
