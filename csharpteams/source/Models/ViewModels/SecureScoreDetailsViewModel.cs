// -----------------------------------------------------------------------
// <copyright file="SecureScoreDetailsViewModel.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Graph;
using MicrosoftGraph_Security_API_Sample.Models.DomainModels;

namespace MicrosoftGraph_Security_API_Sample.Models.ViewModels
{
    public class SecureScoreDetailsViewModel
    {
        public SecureScoreModel TopSecureScore { get; set; }

        public IEnumerable<SecureScoreControlProfileModel> SecureScoreControlProfiles { get; set; }
    }
}