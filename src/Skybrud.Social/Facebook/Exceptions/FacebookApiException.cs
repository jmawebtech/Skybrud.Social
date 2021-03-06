using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Exceptions {

    public class FacebookApiException : Exception {

        public int Code { get; private set; }
        public string Type { get; private set; }
        public int Subcode { get; private set; }

        public FacebookApiException(int code, string type, string message, int subcode = 0) : base(message) {
            Code = code;
            Type = type;
            Subcode = subcode;
        }

        [Obsolete]
        public static FacebookApiException Parse(JsonObject obj) {

            return new FacebookApiException(
                obj.GetInt32("code"),
                obj.GetString("type"),
                obj.GetString("message"),
                obj.HasValue("error_subcode") ? obj.GetInt32("error_subcode") : 0
            );

        }

    }

}
