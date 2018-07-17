using System;
using Xamarin.UITest.Queries;

namespace Xamarin.UITest
{
    public static class AppExtensionsForElementExists
    {
        /// <summary>
        /// This will query the current screen for no matching elements and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if does not exist was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        public static bool ElementDoesNotExist(this IApp app, string element)
        {
            return !app.ElementExists(element);
        }

        /// <summary>
        /// This will query the current screen for no matching elements and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if does not exist was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        /// <param name="timeout">Timeout.</param>
        public static bool ElementDoesNotExist(this IApp app, string element, TimeSpan timeout)
        {
            return !app.ElementExists(element, timeout);
        }

        /// <summary>
        /// This will query the current screen for no matching elements and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if does not exist was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="query">Query.</param>
        public static bool ElementDoesNotExist(this IApp app, Func<AppQuery, AppQuery> query)
        {
            return !app.ElementExists(query, TimeSpan.FromMilliseconds(1000));
        }

        /// <summary>
        /// This will query the current screen for no matching elements and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if does not exist was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="query">Query.</param>
        /// <param name="timeout">Timeout.</param>
        public static bool ElementDoesNotExist(this IApp app, Func<AppQuery, AppQuery> query, TimeSpan timeout)
        {
            return !app.ElementExists(query, timeout);
        }

        /// <summary>
        /// This will query the current screen for the specified item and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if exists was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        public static bool ElementExists(this IApp app, string element)
        {
            return app.ElementExists(a => a.Marked(element), TimeSpan.FromMilliseconds(1000));
        }

        /// <summary>
        /// This will query the current screen for the specified item and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if exists was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        /// <param name="timeout">Timeout.</param>
        public static bool ElementExists(this IApp app, string element, TimeSpan timeout)
        {
            return app.ElementExists(a => a.Marked(element), timeout);
        }

        /// <summary>
        /// This will query the current screen for the specified query and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if exists was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="element">Element.</param>
        public static bool ElementExists(this IApp app, Func<AppQuery, AppQuery> element)
        {
            return app.ElementExists(element, TimeSpan.FromMilliseconds(1000));
        }

        /// <summary>
        /// This will query the current screen for the specified query and return a bool.
        /// </summary>
        /// <returns><c>true</c>, if exists was elemented, <c>false</c> otherwise.</returns>
        /// <param name="app">App.</param>
        /// <param name="query">Query.</param>
        public static bool ElementExists(this IApp app, Func<AppQuery, AppQuery> query, TimeSpan timeout)
        {
            try
            {
                app.WaitForElement(query, timeout: timeout);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return app.Query(query).Any();
        }
    }
}
