using Piranha.AttributeBuilder;
using Piranha.Models;
namespace LibraSoftCMS.Models
{
    [PageType(Title = "Front Page", UseBlocks = false)]
    [ContentTypeRoute(Title = "Default", Route = "/frontpage")]
    public class FrontPage : Page<FrontPage>
    {
    }
}
