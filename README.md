# Kf.Localization
Basic .Net library for supporting resource based localization.

## Download ##
- Main library at https://www.nuget.org/packages/Kf.Localization/
- Resx based implementation at https://www.nuget.org/packages/Kf.Localization.Resx/

## Resx Example ##
1. Download the binaries Kf.Localization and Kf.Localization.Resx, or get all dependencies directly via the nuget package ( https://www.nuget.org/packages/Kf.Localization.Resx/ ).
2. Create the appropriate .resx files (e.g. Strings.resx, Strings.nl-BE.resx, Strings.en-EN.resx, etc..)
3. Afterwards you can use the library, and pass around the dependendent object via DI or any other method you prefer.

```
using System;
using Kf.Localization.Providers;
using Kf.Localization.Resx;
using TestingKfLocalizationResx.Resources;

namespace TestingKfLocalizationResx
{
    class Program
    {
        static void Main(string[] args) {
            IResourceProvider<string> strings = new ResxStringProvider(Strings.ResourceManager, null);
            var p = new Program(strings);
            p.Welcome();
            p.About();
            Console.ReadLine();
        }

        private readonly IResourceProvider<string> _resourceProvider;

        public Program(IResourceProvider<string> resourceProvider) {
            _resourceProvider = resourceProvider;           
        }

        public void Welcome() {
            Console.WriteLine(_resourceProvider.Get("WelcomeWords"));
        }

        public void About() {
            Console.WriteLine($"About: {_resourceProvider.Get("Title")}");
        }
    }
}
```

![.resx file(s) itself](http://oi60.tinypic.com/1z1r901.jpg)
