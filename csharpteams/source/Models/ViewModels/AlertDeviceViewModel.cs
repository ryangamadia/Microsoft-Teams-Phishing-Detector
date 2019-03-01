// -----------------------------------------------------------------------
// <copyright file="AlertDeviceViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Net;

namespace MicrosoftGraph_Security_API_Sample.Models
{
    public class AlertDeviceViewModel
    {
        public string Fqdn { get; set; }

        public string DisplayName
        {
            get { return string.IsNullOrWhiteSpace(this.Fqdn) ? "Unknown" : this.Fqdn.Split('.').FirstOrDefault(); }
        }

        public bool? IsAzureDomainJoined { get; set; }

        public string PrivateIpAddress { get; set; }

        public string PublicIpAddress { get; set; }
    }
}