using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace qa.Pages
{
    public class Index_Tests : qaWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
