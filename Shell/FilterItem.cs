using System;
using System.Collections.Generic;
using System.Text;

namespace GongSolutions.Shell
{
    internal class FilterItem
    {
        public FilterItem(string caption, string filter)
        {
            Caption = caption;
            Filter = filter;
        }

        public bool Contains(string filter)
        {
            string[] filters = Filter.Split(',');

            foreach (string s in filters)
            {
                if (filter == s.Trim()) return true;
            }

            return false;
        }

        public override string ToString()
        {
            string filterString = string.Format(" ({0})", Filter);

            if (Caption.EndsWith(filterString))
            {
                return Caption;
            }
            else
            {
                return Caption + filterString;
            }
        }

        public static FilterItem[] ParseFilterString(string filterString)
        {
            int dummy;
            return ParseFilterString(filterString, string.Empty, out dummy);
        }

        public static FilterItem[] ParseFilterString(string filterString,
                                                     string existing,
                                                     out int existingIndex)
        {
            List<FilterItem> result = new List<FilterItem>();
            string[] items;

            existingIndex = -1;

            if (filterString != string.Empty)
            {
                items = filterString.Split('|');
            }
            else
            {
                items = new string[0];
            }

            if ((items.Length % 2) != 0)
            {
                throw new ArgumentException(
                    "Filter string you provided is not valid. The filter " +
                    "string must contain a description of the filter, " +
                    "followed by the vertical bar (|) and the filter pattern." +
                    "The strings for different filtering options must also be " +
                    "separated by the vertical bar. Example: " +
                    "\"Text files|*.txt|All files|*.*\"");
            }

            for (int n = 0; n < items.Length; n += 2)
            {
                FilterItem item = new FilterItem(items[n], items[n + 1]);
                result.Add(item);
                if (item.Filter == existing) existingIndex = result.Count - 1;
            }

            return result.ToArray();
        }

        public string Caption;
        public string Filter;
    }
}
