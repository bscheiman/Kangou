#region
using System;
using System.Diagnostics;
using Newtonsoft.Json;

#endregion

namespace Kangou {
    public static class Extensions {
        [DebuggerStepThrough]
        public static T FromJson<T>(this string str) {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
