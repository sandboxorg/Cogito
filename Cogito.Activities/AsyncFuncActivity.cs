﻿using System;
using System.Activities;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        public static AsyncFuncActivity<TResult> Invoke<TResult>(Func<Task<TResult>> func, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncFuncActivity<TResult>(func)
            {
                DisplayName = displayName,
            };
        }

        public static AsyncFuncActivity<TValue1, TValue2> Then<TValue1, TValue2>(this Activity<TValue1> activity, Func<TValue1, Task<TValue2>> func)
        {
            Contract.Requires<ArgumentNullException>(activity != null);
            Contract.Requires<ArgumentNullException>(func != null);

            return new AsyncFuncActivity<TValue1, TValue2>(func, activity);
        }

    }

    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function.
    /// </summary>
    public class AsyncFuncActivity<TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        public static implicit operator ActivityFunc<TResult>(AsyncFuncActivity<TResult> activity)
        {
            return Expressions.Delegate(() =>
            {
                return activity;
            });
        }

        public static implicit operator ActivityDelegate(AsyncFuncActivity<TResult> activity)
        {
            return activity;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<Task<TResult>> func = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(OutArgument<TResult> result = null, Func<Task<TResult>> func = null)
        {
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<Task<TResult>> Func { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context, Func<Func<Task<TResult>>, Task<TResult>> executor)
        {
            return executor(Func);
        }

    }

}
