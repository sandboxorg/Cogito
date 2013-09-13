﻿using System.ComponentModel.Composition.Hosting;

namespace Cogito.Composition
{

    /// <summary>
    /// Implements a sub-scope.
    /// </summary>
    class CompositionScope : CompositionContextCore
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="parent"></param>
        public CompositionScope(CompositionContainer parent)
            : base(parent)
        {

        }

    }

}