﻿// -----------------------------------------------------------------------
// <copyright file="AlertDetailsViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.Graph;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models.ViewModels
{
    public class AlertDetailsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public IEnumerable<string> Comments { get; set; }

        public string Status { get; set; }

        public string Severity { get; set; }

        public string Feedback { get; set; }

        public GraphUserModel AssignedTo { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> RecommendedActions { get; set; }

        public GraphUserModel User { get; set; }

        public AlertDeviceViewModel Device { get; set; }

        public SecurityVendorInformation Vendor { get; set; }

        public IEnumerable<AlertTrigger> Triggers { get; set; }

        public IEnumerable<UserSecurityState> Users { get; set; }

        public IEnumerable<HostSecurityState> Hosts { get; set; }

        public IEnumerable<NetworkConnection> NetworkConnections { get; set; }

        public IEnumerable<FileSecurityState> Files { get; set; }

        public IEnumerable<Process> Processes { get; set; }

        public IEnumerable<RegistryKeyState> RegistryKeyUpdates { get; set; }

        public IEnumerable<MalwareState> MalwareStates { get; set; }

        public IEnumerable<string> SourceMaterials { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<VulnerabilityState> VulnerabilityStates { get; set; }

        public IEnumerable<CloudAppSecurityState> CloudAppStates { get; set; }

        public IEnumerable<string> DetectionIds { get; set; }
    }
}