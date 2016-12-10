using System;

namespace sc.Terminal
{
    static class Messages
    {
        public static void WriteHeader ()
        {
            var header = new [] { "slang compiler (sc), version 0.0.0.0", "Copyright James G. McAuley 2015" };

            using (Colour.With (ConsoleColor.Cyan)) {
                foreach (var message in header) {
                    Console.WriteLine (message);
                }
            }
        }

        public static void WriteUsage ()
        {
            using(Colour.With (ConsoleColor.Yellow)) {
                Console.WriteLine ("Usage: sc.exe <projectName> {<fileName>}");
            }
        }

        public static void WriteInfo (string format, params object [] args)
        {
            using (Colour.With (ConsoleColor.White)) {
                var message = string.Format (format, args);
                Console.WriteLine ("    {0}", message);
            }
        }

        public static void WriteError (string format, params object [] args)
        {
            using(Colour.With(ConsoleColor.Red)) {
                var message = string.Format (format, args);
                Console.Error.WriteLine (message);    
            }
        }

        public static void WriteLogo ()
        {
            using (Colour.With (ConsoleColor.White)) {
                // Generated by http://patorjk.com/software/taag/#p=display&f=Larry%203D&t=slang%0A
                Console.WriteLine (@"       ___                                
      /\_ \                               
  ____\//\ \      __      ___      __     
 /',__\ \ \ \   /'__`\  /' _ `\  /'_ `\   
/\__, `\ \_\ \_/\ \L\.\_/\ \/\ \/\ \L\ \  
\/\____/ /\____\ \__/.\_\ \_\ \_\ \____ \ 
 \/___/  \/____/\/__/\/_/\/_/\/_/\/___L\ \
                                   /\____/
                                   \_/__/ ");
            }
        }
    }

    class Colour : IDisposable
    {
        public static Colour With(ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            return new Colour ();
        }

        public void Dispose ()
        {
            Console.ResetColor ();
        }
    }

}
