// -----------------------------------------------------------------------
// <copyright file="AlertStatisticViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft_Teams_Graph_RESTAPIs_Connect.Models.DomainModels;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models
{
    public class AlertStatisticViewModel
    {
        public SecureScoreStatisticModel SecureScore { get; set; }

        public IOrderedEnumerable<KeyValuePair<string, int>> ActiveAlerts { get; set; }

        public Dictionary<KeyValuePair<string, string>, Dictionary<SeveritySortOrder, int>> UsersWithTheMostAlerts { get; set; }

        public Dictionary<KeyValuePair<string, string>, Dictionary<SeveritySortOrder, int>> HostsWithTheMostAlerts { get; set; }

        public Dictionary<KeyValuePair<string, string>, Dictionary<SeveritySortOrder, int>> ProvidersWithTheMostAlerts { get; set; }

        public Dictionary<KeyValuePair<string, string>, Dictionary<SeveritySortOrder, int>> IPWithTheMostAlerts { get; set; }
    }
}