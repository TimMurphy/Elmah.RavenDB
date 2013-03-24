﻿using System.Collections.Generic;
using System.Collections.Specialized;

namespace Elmah
{
    public static class Mapping 
    {
        public static ErrorDocument MapToErrorDocument(this Error error)
        {
            return new ErrorDocument 
            {
                ApplicationName = error.ApplicationName,
                Cookies = error.Cookies.MapToListOfKeyValuePair(),
                Detail = error.Detail,
                ErrorXml = ErrorXml.EncodeString(error),
                Exception = error.Exception,
                Form = error.Form.MapToListOfKeyValuePair(),
                HostName = error.HostName,
                Message = error.Message,
                QueryString = error.QueryString.MapToListOfKeyValuePair(),
                ServerVariables = error.ServerVariables.MapToListOfKeyValuePair(),
                Source = error.Source,
                StatusCode = error.StatusCode,
                Time = error.Time,
                Type = error.Type,
                User = error.User,
                WebHostHtmlMessage = error.WebHostHtmlMessage
            };
        }

        public static IList<KeyValuePair<string, string>> MapToListOfKeyValuePair(this NameValueCollection collection)
        {
            var list = new List<KeyValuePair<string, string>>();

            for (int i = 0; i < collection.Count; i++)
            {
                list.Add(new KeyValuePair<string, string>(collection.Keys[i], collection[i]));
            }

            return list;
        }
    }
}
