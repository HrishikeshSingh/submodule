// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISourceControlActions.cs" company="Microsoft Corporation">
//   2012-2023, All rights reserved.
// </copyright>
// <summary>
//   The OSS Source Control Actions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Services.OssEngineering.OssActions.Definition
{
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Framework.Server;
    using Microsoft.TeamFoundation.Release.SourceControl.Definition;
    using Microsoft.VisualStudio.Services.OssEngineering.Models;

    public interface ISourceControlActions
    {
        /// <summary>
        /// Commit given list of files in given container
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="commitArgumet">Commit Details like author, email, description etc.</param>
        /// <param name="files">List of files to commit</param>
        void Commit(IVssRequestContext requestContext, CommitArgument commitArgumet, IEnumerable<string> files);

        /// <summary>
        /// Commit given list of stream
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="commitArgumet">Commit Details like author, email, description etc.</param>
        /// <param name="listOfFileDescriptor">IEnumerable of FileDescriptor.</param>
        /// <param name="tagName">Name of the tag to be created.</param>
        void Commit(IVssRequestContext requestContext, CommitArgument commitArg, IEnumerable<FileDescriptor> listOfFileDescriptor);

        /// <summary>
        /// Fetch all artifacts from remote branch to the local branch.
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        void Fetch(IVssRequestContext requestContext);

        /// <summary>
        /// Fetch all artifacts present i an particular version.
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="version">Source Control Version details</param>
        void Fetch(IVssRequestContext requestContext, SourceControlVersion version);

        /// <summary>
        /// Fetch all versions of the given versionType.
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="versionType">Source Control Version Type</param>
        void Fetch(IVssRequestContext requestContext, SourceControlVersionType versionType);

        /// <summary>
        /// Push all artifacts from local branch to the remote branch.
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        void Push(IVssRequestContext requestContext);

        /// <summary>
        /// Push all artifacts from local branch to the remote branch.
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="version">Source Control Version details</param>
        void Push(IVssRequestContext requestContext, SourceControlVersion version);

        /// <summary>
        /// Push all versions of the given versionType.
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="versionType">Source Control Version Type</param>
        void Push(IVssRequestContext requestContext, SourceControlVersionType versionType);

        /// <summary>
        /// Create a new branch on the container
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="branchName">Name of the new branch to be created</param> 
        /// <param name="commitId">Commit ID based on which the branch will be created.
        /// If this is empty/null, branch is created from the current Head.</param>
        void CreateBranch(IVssRequestContext requestContext, string branchName, string commitId);

        /// <summary>
        /// Create a new branch on the container
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="branchName">Name of the new branch to be created</param> 
        /// If this is empty/null, branch is created from the current Head.</param>
        void CreateBranch(IVssRequestContext requestContext, string branchName);

        /// <summary>
        /// Rename oldBranchName on container to newBranchName
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="oldBranchName">Existing name of the branch</param>
        /// <param name="newBranchName">New name of the branch</param>
        void RenameBranch(IVssRequestContext requestContext, string oldBranchName, string newBranchName);

        /// <summary>
        /// Returns available branches for a given source repository 
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="fromRemote">Get branches from remote branch or local branch</param>
        /// <returns>Returns Branches list</returns>
        IEnumerable<Branch> GetBranches(IVssRequestContext requestContext, bool fromRemote);

        /// <summary>
        /// Returns available tags for a given source repository 
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="fromRemote">Get tags from remote branch or local branch</param>
        /// <returns>Returns Tags list</returns>
        IEnumerable<Tag> GetTags(IVssRequestContext requestContext, bool fromRemote);

        /// <summary>
        /// Returns available versions for a given source repository. Version names
        /// are prefixed with the type of the version. For ex, a branch-type version
        /// is prefixed with "b:", a tag type version is prefixed with "t:"
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="fromRemote">Get versions from remote branch or local branch</param>
        /// <returns>Returns a list of Versions</returns>
        IEnumerable<SourceVersion> GetVersions(IVssRequestContext requestContext, bool fromRemote);

        /// <summary>
        /// Delete a branch on the container
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="branchName">Name of the branch to be deleted</param>
        void DeleteBranch(IVssRequestContext requestContext, string branchName);

        /// <summary>
        /// Create a new tag on the container
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="tagName">Name of the tag to be created</param>
        /// <param name="tagArgument">Details of the tag like : commitId, author, author email, description</param>
        void CreateTag(IVssRequestContext requestContext, string tagName, TagArgument tagArgument);

        /// <summary>
        /// Delete a tag on the container
        /// </summary>
        /// <param name="requestContext">The Team Foundation Request Context</param>
        /// <param name="tagName">Name of the tag to be deleted</param>
        void DeleteTag(IVssRequestContext requestContext, string tagName);
    }
}