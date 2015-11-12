using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace slang.Parsing
{
    public static class NewParser
    {
        public static Literal ParseDouble(string value)
        {
            if(value.EndsWith ("d", StringComparison.InvariantCultureIgnoreCase)) { 
                value
                    .Replace ("d", "")
                    .Replace ("D", ""); 
            }

            double d;
            return double.TryParse (value, out d) ? new Literal() : null;
        }

        public static Literal ParseInteger(string value) {

            var unsignedLongPattern = new Regex (@"(\d+|0[xX][0-9a-fA-F]+)(ul|Ul|UL|uL|lu|Lu|LU|uL)");

            if(unsignedLongPattern.IsMatch (value)) {
                value = value
                    .Replace ("l", "")
                    .Replace ("L", "")
                    .Replace ("u", "")
                    .Replace ("U", "");
                
                ulong u;

                return ParseDecimalOrHex (
                    value,
                    v => ulong.TryParse (v, out u) ? new Literal() : null,
                    v => ulong.TryParse (v, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out u) ? new Literal() : null);
            }

            var signedLongPattern = new Regex(@"(\d+|0[xX][0-9a-fA-F]+)(l|L)$");

            if(signedLongPattern.IsMatch (value)) {
                value = value
                    .Replace ("l", "")
                    .Replace ("L", "");

                long l;

                return ParseDecimalOrHex (
                    value,
                    v => long.TryParse (v, out l) ? new Literal () : null,
                    v => long.TryParse (v, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out l) ? new Literal () : null
                );
            }

            int i;

            return ParseDecimalOrHex (
                value,
                v => int.TryParse (value, out i) ? new Literal () : null,
                v => int.TryParse (value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out i) ? new Literal() : null
            );
        }

        static string Strip(string value, params string[] values) {
            return values.Aggregate (value, (previous, next) => previous.Replace(next, ""));
        }

        static T ParseDecimalOrHex<T>(string value, Func<string, T> converter, Func<string, T> hexConverter) {
            
            if(value.StartsWith ("0x", StringComparison.InvariantCultureIgnoreCase)) {
                value = value
                    .Replace ("0x", "")
                    .Replace("0X", "");

                return hexConverter (value);
            }

            return converter (value);
        }
    }

    public class Literal {}
}

