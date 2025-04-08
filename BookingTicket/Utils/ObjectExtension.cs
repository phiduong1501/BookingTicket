using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BookingTicket.Utils
{
    public static class ObjectExtension
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            if (table == null)
                return null;
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            List<T> result = new List<T>();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            try
            {
                foreach (var property in properties)
                {
                    if (row[property.Name] != DBNull.Value)
                    {
                        try
                        {
                            property.SetValue(item, System.Convert.ChangeType(row[property.Name], property.PropertyType), null);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Thieu field trong view
            }
            return item;
        }
    }
}