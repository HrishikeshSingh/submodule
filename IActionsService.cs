// ----------------------------------------------------------------------------
// <copyright file="IActionsService.cs" company="Microsoft Corporation">
//     2012-2023, All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Services.OssEngineering.OssActions.Definition
{
    using Microsoft.TeamFoundation.Framework.Server;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.OssEngineering.Models;

    public interface IActionsService : IVssFrameworkService
    {
        IDownloadActions GetDownloadHelper(IVssRequestContext requestContext);

        IArchiveActions GetArchiveHelper(IVssRequestContext requestContext);

        IFrameworkActions GetFrameworkActions(IVssRequestContext requestContext);

        ISourceControlActions GetSourceControlActions(IVssRequestContext requestContext, string remoteUri, string localDirectory, bool shouldRetry);

        IContentRepositoryActions GetSourceContentRepositoryActions(
            IVssRequestContext requestContext,
            Repository repository);

        IContentRepositoryActions GetTargetContentRepositoryActions(
            IVssRequestContext requestContext,
            Repository repository);

        IFeedServiceActions GetFeedServiceActions(
            IVssRequestContext requestContext);
    }
}
