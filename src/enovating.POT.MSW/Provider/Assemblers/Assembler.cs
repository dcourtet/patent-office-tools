// -------------------------------------------------------------------------------------
// This file is part of 'Patent Office Tools' source code.
// 
// Patent Office Tools is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but without any warranty; without even the implied warranty of
// merchantability or fitness for a particular purpose. See the
// GNU Affero General Public License for more details.
// 
// Copyright 2019-2020 enovating SA <https://www.enovating.com/>
// -------------------------------------------------------------------------------------

namespace enovating.POT.MSW.Provider.Assemblers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Implements the common functions of an object assembler.
    /// </summary>
    /// <typeparam name="TTarget">The target type.</typeparam>
    /// <typeparam name="TSource">The source type.</typeparam>
    internal abstract class Assembler<TTarget, TSource>
        where TTarget : new()
    {
        /// <summary>
        ///     Converts the object of the source type to an object of the target type.
        /// </summary>
        /// <param name="source">The source object.</param>
        public virtual TTarget Convert(TSource source)
        {
            if (source == null)
            {
                return default;
            }

            var target = new TTarget();
            Merge(target, source);

            return target;
        }

        /// <summary>
        ///     Converts objects of the source type to objects of the target type.
        /// </summary>
        /// <param name="sources">The source objects.</param>
        /// <returns>The target objects.</returns>
        public virtual TTarget[] Convert(IEnumerable<TSource> sources)
        {
            return sources == null
                ? new TTarget[0]
                : sources.Select(Convert).ToArray();
        }

        /// <summary>
        ///     Merge the object of the source type with the object of the target type.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="source">The source object.</param>
        public virtual void Merge(TTarget target, TSource source)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            MergeCore(target, source);
        }

        /// <summary>
        ///     Merge the object of the source type with the object of the target type.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="source">The source object.</param>
        protected abstract void MergeCore(TTarget target, TSource source);
    }
}
