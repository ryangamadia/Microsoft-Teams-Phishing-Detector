// -----------------------------------------------------------------------
// <copyright file="IAuthProvider.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;

namespace Microsoft_Teams_Graph_RESTAPIs_Connect.Providers
{
    public interface IAuthProvider
    {
        Task<string> GetUserAccessTokenAsync();
    }
}