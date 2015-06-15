using System.Globalization;
using Kf.Localization.Resx.Tests.Data;
using Xunit;

namespace Kf.Localization.Resx.Tests
{    
    public class ResxStringProviderTests
    {        
        [Fact]
        public void HasCurrentUICultureWhenNullIsPassed() {
            ResxProvider<string> sut = new ResxStringProvider(Strings.ResourceManager, null);
            Assert.Equal(CultureInfo.CurrentUICulture, sut.Culture);
        }

        [Fact]
        public void HasCurrentUICultureWheCultureInfoIsPassed() {
            ResxProvider<string> sut = new ResxStringProvider(Strings.ResourceManager, new CultureInfo("nl-BE"));
            Assert.Equal(new CultureInfo("nl-BE"), sut.Culture);
        }
    }
}
