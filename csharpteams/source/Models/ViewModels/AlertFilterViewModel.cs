// -----------------------------------------------------------------------
// <copyright file="AlertFilterViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models.ViewModels
{
    public class AlertFilterViewModel
    {
        public int? Top { get; set; }

        public AlertFilterCollection Filters { get; set; }
    }

    public class AlertFilterCollection : IEnumerable
    {
       public AlertFilterCollection()
        {
            this.Filters = new Dictionary<string, string>();
        }

        private Dictionary<string, string> Filters { get; set; }

        public int Count
        {
            get { return this.Filters.Count; }
        }

        public string GetFilterValue(string filterKey)
        {
            var key = filterKey.ToLower();
            return this.Filters.ContainsKey(key) ? this.Filters[key] : string.Empty;
        }

        public void Add(string key, string value)
        {
            this.Filters.Add(key.ToLower(), value);
        }

        public IEnumerator GetEnumerator()
        {
            return this.Filters.GetEnumerator();
        }
    }
}