// -----------------------------------------------------------------------
// <copyright file="AlertResultItemModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Microsoft.Graph;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models
{
    public class AlertResultItemModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Severity { get; set; }

        public string Category { get; set; }

        public AlertStatus? Status { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public string Provider { get; set; }
    }
}