using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace TaskManagement.Core.Extensions;


public static class SessionExtensions
{
    public static void SetObject(this ISession session, string key, object value)
    {
        try
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
