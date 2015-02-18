﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibGit2Sharp
{
    /// <summary>
    /// Class to convey information about the repository that is being operated on
    /// for operations that can recurse into submodules.
    /// </summary>
    public class RepositoryOperationContext
    {
        /// <summary>
        /// Needed for mocking.
        /// </summary>
        protected RepositoryOperationContext()
        { }

        /// <summary>
        /// Constructor suitable for use on the repository the main
        /// operation is being run on (i.e. the super project, not a submodule).
        /// </summary>
        /// <param name="repositoryPath">The path of the repository being operated on.</param>
        /// <param name="remoteUrl">The URL that this operation will download from.</param>
        internal RepositoryOperationContext(string repositoryPath, string remoteUrl)
            : this(repositoryPath, remoteUrl, string.Empty, string.Empty, 0)
        {
        }

        /// <summary>
        /// Constructor suitable for use on the sub repositories.
        /// </summary>
        /// <param name="repositoryPath">The path of the repository being operated on.</param>
        /// <param name="remoteUrl">The URL that this operation will download from.</param>
        /// <param name="parentRepositoryPath">The path to the super repository.</param>
        /// <param name="submoduleName">The logical name of this submodule.</param>
        /// <param name="recursionDepth">The depth of this sub repository from the original super repository.</param>
        internal RepositoryOperationContext(string repositoryPath,
                                            string remoteUrl,
                                            string parentRepositoryPath,
                                            string submoduleName, int recursionDepth)
        {
            RepositoryPath = repositoryPath;
            RemoteUrl = remoteUrl;
            ParentRepositoryPath = parentRepositoryPath;
            SubmoduleName = submoduleName;
            RecursionDepth = recursionDepth;
        }

        /// <summary>
        /// Full path to parent repository.
        /// </summary>
        public virtual string ParentRepositoryPath { get; private set; }

        /// <summary>
        /// The recursion depth for the current repository. The initial
        /// repository is at depth 0.
        /// </summary>
        public virtual int RecursionDepth { get; private set; }

        /// <summary>
        /// The remote URL this operation will work against, if any.
        /// </summary>
        public virtual string RemoteUrl { get; private set; }

        /// <summary>
        /// Full path of the repository.
        /// </summary>
        public virtual string RepositoryPath { get; private set; }

        /// <summary>
        /// If this is a submodule, the submodules name in the parent repository.
        /// </summary>
        public virtual string SubmoduleName { get; private set; }
    }
}