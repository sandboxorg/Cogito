﻿using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = values,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(values, displayName),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = values,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(values, displayName),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = values,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(Invoke<IEnumerable<TElement>>(values, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(Invoke<IEnumerable<TElement>>(values, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(Invoke<IEnumerable<TElement>>(values, displayName), Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));


            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(values),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(Invoke<TElement[]>(values, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, ActivityAction<TElement> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(Invoke<TElement[]>(values, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, Func<TElement, Task> body, string displayName = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (body == null)
                throw new ArgumentNullException(nameof(body));

            return ParallelForEach(Invoke<TElement[]>(values, displayName), Delegate<TElement>(arg => Invoke<TElement>(body, arg, displayName)), displayName);
        }

    }

}
