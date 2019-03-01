// -----------------------------------------------------------------------
// <copyright file="GraphDeviceModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MicrosoftGraph_Security_API_Sample.Models
{
    public class GraphDeviceModel
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public bool? IsCompliant { get; set; }

        public string Os { get; set; }

        public string OsVersion { get; set; }

        public bool? IsIntuneManaged { get; set; }

        public DateTimeOffset? ApproximateLastSignIn { get; set; }
    }
}