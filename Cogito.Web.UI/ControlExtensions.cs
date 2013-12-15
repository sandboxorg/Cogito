﻿using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Web.UI;

namespace Cogito.Web.UI
{

    /// <summary>
    /// Provides extensions that make working with <see cref="Control"/> instances easier.
    /// </summary>
    public static class ControlExtensions
    {

        /// <summary>
        /// Sets the given attribute and attribute value on the <see cref="Control"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T WithAttribute<T>(this T control, string key, string value)
            where T : IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(key != null);

            control.SetAttribute(key, value);

            return control;
        }

        /// <summary>
        /// Sets the given attribute and attribute value on the <see cref="Control"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static T WithAttribute<T>(this T control, Expression<Func<string, string>> attribute)
            where T : IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);
            Contract.Requires<ArgumentNullException>(attribute != null);

            foreach (var p in attribute.Parameters)
                WithAttribute(control, p.Name, attribute.Compile()(control.GetAttribute(p.Name)));

            return control;
        }

        /// <summary>
        /// Adds the given CSS class to the <see cref="Control"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="class"></param>
        /// <returns></returns>
        public static T WithClass<T>(this T control, string @class)
            where T : IAttributeAccessor
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(@class))
                control.SetAttribute("class", (control.GetAttribute("class") + " " + @class).TrimEnd());

            return control;
        }

        /// <summary>
        /// Adds the given content to the body of the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T WithContent<T>(this T control, string value)
            where T : CogitoControl
        {
            Contract.Requires<ArgumentNullException>(control != null);

            if (!string.IsNullOrWhiteSpace(value))
                control.Controls.Add(new LiteralControl(value));

            return control;
        }

    }

}