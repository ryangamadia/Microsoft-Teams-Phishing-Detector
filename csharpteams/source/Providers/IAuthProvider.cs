// -----------------------------------------------------------------------
// <copyright file="IAuthProvider.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;

namespace MicrosoftGraph_Security_API_Sample.Providers
{
    public interface IAuthProvider
    {
        Task<string> GetUserAccessTokenAsync();
    }
}