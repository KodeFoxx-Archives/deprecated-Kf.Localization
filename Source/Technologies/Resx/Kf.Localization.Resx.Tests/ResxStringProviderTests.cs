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

        [Fact]
        public void CanGetCorrectKeyAndValue() {
            ResxProvider<string> sut = new ResxStringProvider(Strings.ResourceManager, new CultureInfo("en"));
            Assert.Equal("I've got the secret. I've got the key to another way. Ah ah ah ah ah ah, aha ah", 
                sut.Get("IVeGotTheKey"));
        }

        [Fact]
        public void CanGetCorrectKeyAndValueAfterChangingCulture() {
            ResxProvider<string> sut = new ResxStringProvider(Strings.ResourceManager, new CultureInfo("en"));
            Assert.Equal("I've got the secret. I've got the key to another way. Ah ah ah ah ah ah, aha ah",
                sut.Get("IVeGotTheKey"));
            sut.Culture = new CultureInfo("nl-BE");
            Assert.Equal("Ik heb het geheim. Ik heb de sleutel tot een andere manier. Ah ah ah ah ah ah, ah aha",
                sut.Get("IVeGotTheKey"));
        }
    }
}
