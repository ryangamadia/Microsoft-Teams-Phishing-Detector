// -----------------------------------------------------------------------
// <copyright file="GraphUserModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using Microsoft.Graph;

namespace MicrosoftGraph_Security_API_Sample.Models
{
    public class GraphUserModel
    {
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Upn { get; set; }

        public string JobTitle { get; set; }

        public GraphUserModel Manager { get; set; }

        public string OfficeLocation { get; set; }

        public string ContactVia { get; set; }

        public string Picture { get; set; }

        public IEnumerable<GraphDeviceModel> RegisteredDevices { get; set; }

        public IEnumerable<GraphDeviceModel> OwnedDevices { get; set; }

        public GraphDeviceModel SelectedDevice { get; set; }
    }
}