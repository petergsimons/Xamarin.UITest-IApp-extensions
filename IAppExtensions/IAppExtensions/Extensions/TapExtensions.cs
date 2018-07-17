using System;
using Xamarin.UITest.Queries;

namespace Xamarin.UITest
{
    public static class TapExtensions
    {
        internal const string DefaultTimeoutMessage = "Timed out waiting for element...";

        /// <summary>
        /// Waits for the specified element then taps it. 
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        /// <param name="timoutMessage">Timout message.</param>
        /// <param name="timeout">Timeout.</param>
        /// <param name="retryFrequency">Retry frequency.</param>
        /// <param name="postTimout">Post timout.</param>
        public static void WaitForThenTap(this IApp app, Func<AppQuery, AppQuery> element, string timoutMessage = DefaultTimeoutMessage, TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimout = null )
        {
            app.WaitForElement(
                element, 
                timoutMessage, 
                timeout ?? TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_TIMEOUT_SECONDS), 
                retryFrequency ?? TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_RETRYFREQUENCY_SECONDS), 
                postTimout ?? TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_POST_TIMEOUT_SECONDS)
            );
            app.Tap(element);
        }

        /// <summary>
        /// Waits for the specified element then taps it. 
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        /// <param name="timoutMessage">Timout message.</param>
        /// <param name="timeout">Timeout.</param>
        /// <param name="retryFrequency">Retry frequency.</param>
        /// <param name="postTimout">Post timout.</param>
        public static void WaitForThenTap(this IApp app, Func<AppQuery, AppWebQuery> element, string timoutMessage = DefaultTimeoutMessage, TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimout = null)
        {
            app.WaitForElement(
                element, 
                timoutMessage, 
                timeout ?? TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_TIMEOUT_SECONDS), 
                retryFrequency ?? TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_RETRYFREQUENCY_SECONDS), 
                postTimout ?? TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_POST_TIMEOUT_SECONDS)
            );
            app.Tap(element);
        }

        /// <summary>
        /// Waits for the specified element then taps it. 
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        /// <param name="timoutMessage">Timout message.</param>
        /// <param name="timeout">Timeout.</param>
        /// <param name="retryFrequency">Retry frequency.</param>
        /// <param name="postTimout">Post timout.</param>
        public static void WaitForThenTap(this IApp app, string element, string timoutMessage = DefaultTimeoutMessage, TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimout = null)
        {
            app.WaitForThenTap(
                el => el.Marked(element), 
                timoutMessage, 
                timeout, 
                retryFrequency, 
                postTimout
            );
        }

        /// <summary>
        /// Taps an item if it exists and fails silently if it can't find the item.
        /// </summary>
        /// <returns><c>true</c>, if tap was optionallyed, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="itemToTap">Item to tap.</param>
        /// <param name="timeout">Timeout.</param>
        public static bool OptionallyTap(this IApp app, Func<AppQuery, AppQuery> itemToTap, TimeSpan? timeout)
        {
            try
            {
                app.WaitForElement(itemToTap, timeout: timeout ?? TimeSpan.FromSeconds(1));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            if (app.ElementExists(itemToTap))
            {
                app.Tap(itemToTap);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Optionallies the tap.
        /// </summary>
        /// <returns><c>true</c>, if tap was optionallyed, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="itemToTap">Item to tap.</param>
        /// <param name="timeout">Timeout.</param>
        public static bool OptionallyTap(this IApp app, string itemToTap, TimeSpan? timeout)
        {
           return app.OptionallyTap(i => i.Marked(itemToTap), timeout);
        }

    }
}
