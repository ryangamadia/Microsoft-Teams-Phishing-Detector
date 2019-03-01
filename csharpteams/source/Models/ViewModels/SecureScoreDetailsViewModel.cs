// -----------------------------------------------------------------------
// <copyright file="SecureScoreDetailsViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Graph;
using Microsoft_Teams_Graph_RESTAPIs_Connect.Models.DomainModels;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Models.ViewModels
{
    public class SecureScoreDetailsViewModel
    {
        public SecureScoreModel TopSecureScore { get; set; }

        public IEnumerable<SecureScoreControlProfileModel> SecureScoreControlProfiles { get; set; }
    }
}