using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace covid19.Views
{
    public partial class WorldStatsPage : ContentPage
    {
        public WorldStatsPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
        }
    }
}