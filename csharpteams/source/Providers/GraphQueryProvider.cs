// -----------------------------------------------------------------------
// <copyright file="GraphQueryProvider.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft_Teams_Graph_RESTAPIs_Connect.Models;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Providers
{
    public static class GraphQueryProvider
    {
        public static string GetQueryByAlertFilter(AlertFilterModel filter)
        {
            var filteredQuery = string.Empty;

            foreach (KeyValuePair<string, List<AlertFilterProperty>> property in filter)
            {
                var filtersForKey = string.Join($" {AlertFilterOperator.And} ", property.Key.Trim().EndsWith(")") ? property.Value.Select(item => $"{property.Key.Substring(0, property.Key.Length - 1)} {item.PropertyDescription.Operator} {item.Value})") : property.Value.Select(item => $"{property.Key} {item.PropertyDescription.Operator} {item.Value}"));

                filteredQuery += $"{(filteredQuery.Length != 0 ? $" {AlertFilterOperator.And} " : string.Empty)}{filtersForKey}";
            }

            return filteredQuery;
        }
    }
}