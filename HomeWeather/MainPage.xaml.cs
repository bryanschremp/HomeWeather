using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

namespace HomeWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // http://api.thingspeak.com/channels/33195/feed/last.json
        private static int IndoorChannelID = 33195;
        private static string IndoorReadAPIKey = "FZ7QQ4A29WWLKUKJ";
        // http://api.thingspeak.com/channels/21626/feed/last.json
        private static int OutdoorChannelID = 21626;
        private static string OutdoorReadAPIKey = "T2LYOSXKDC0D2WLS";

        public MainPage()
        {
            this.InitializeComponent();
            RefreshData();
        }

        private async void RefreshData()
        {
            var client = new ThingSpeakClient(false);

            // Indoor Feed
            var indoorFeed = await client.ReadLastFeedAsync( IndoorReadAPIKey, IndoorChannelID );

            if ( indoorFeed != null )
            {
                IndoorTemp.Text = indoorFeed.Field1.ToString();
                IndoorHumidity.Text = indoorFeed.Field2.ToString();
            }

            // Outdoor Feed
            var outdoorFeed = await client.ReadLastFeedAsync( OutdoorReadAPIKey, OutdoorChannelID );
            if (outdoorFeed != null)
            {
                OutdoorTemp.Text = outdoorFeed.Field1.ToString();
                OutdoorHumidity.Text = outdoorFeed.Field2.ToString();
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

    }
}
