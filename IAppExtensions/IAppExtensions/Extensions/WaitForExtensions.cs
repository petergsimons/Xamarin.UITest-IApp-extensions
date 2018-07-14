using System;
using Xamarin.UITest.Queries;

namespace Xamarin.UITest
{
    public static class WaitForExtensions
    {
        internal const string DefaultTimeoutMessage = "Timed out waiting for element...";

        public static void WaitForThenTap(this IApp app, Func<AppQuery, AppQuery> element, string timoutMessage = DefaultTimeoutMessage, TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimout = null )
        {
            if (timeout == null)
                timeout = TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_TIMEOUT_SECONDS);
            if (retryFrequency == null)
                TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_RETRYFREQUENCY_SECONDS);
            if (postTimout == null)
                TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_POST_TIMEOUT_SECONDS);

            app.WaitForElement(element, timoutMessage, timeout, retryFrequency, postTimout);
            app.Tap(element);
        }

        public static void WaitForThenTap(this IApp app, Func<AppQuery, AppWebQuery> element, string timoutMessage = DefaultTimeoutMessage, TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimout = null)
        {
            if (timeout == null)
                timeout = TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_TIMEOUT_SECONDS);
            if (retryFrequency == null)
                TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_RETRYFREQUENCY_SECONDS);
            if (postTimout == null)
                TimeSpan.FromSeconds(ExtensionPoperties.DEFAULT_POST_TIMEOUT_SECONDS);

            app.WaitForElement(element, timoutMessage, timeout, retryFrequency, postTimout);
            app.Tap(element);
        }


        public static void WaitForThenTap(this IApp app, string element, string timoutMessage = DefaultTimeoutMessage, TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimout = null)
        {
            app.WaitForThenTap(el => el.Marked(element), timoutMessage, timeout, retryFrequency, postTimout);
        }
    }
}
