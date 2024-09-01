using Exiled.API.Features;
using PlaceholderAPI.API.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalTimeExpansion
{
    public class LocalTimeExpansion : PlaceholderExpansion
    {
        public override string Author { get; set; } = "NotZer0Two";
        public override string Identifier { get; set; } = "localtime";
        public override string RequiredPlugin { get; set; } = null;

        public override string OnOfflineRequest(string param)
        {
            string[] split = param.Split('_');

            switch(split[0].ToLower())
            {
                case "time":
                    if (split.Length == 2)
                        return DateTime.Now.ToString(split[1]);
                    else return DateTime.Now.ToString("f");
                case "timezone":
                    if (split.Length == 2)
                        return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, split[1]).ToString("f");
                    else if(split.Length == 3)
                        return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, split[1]).ToString(split[2]);
                    else
                    {
                        foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                            Log.Info(z.Id);
                        return "Logged in console the List.";
                    }
            }

            return null;
        }
    }
}
