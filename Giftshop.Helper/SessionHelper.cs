namespace GiftShop.Helper
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    public static class SessionHelper
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.Set(key, (byte[])value);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            session.TryGetValue(key, out var value);
            return value;
        }
    }
}
