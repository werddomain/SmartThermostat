using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Pages
{
    public class TestPageVM:BaseModel
    {
        public TestPageVM() {
            TopMenu.Add(new Models.TopMenuButtonModel(FontAwesome.UWP.FontAwesomeIcon.AddressCard, "Test Button", "/Pages/HomePage"));
        }
    }
}
