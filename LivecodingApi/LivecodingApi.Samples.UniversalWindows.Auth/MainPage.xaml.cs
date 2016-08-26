using LivecodingApi.Model;
using LivecodingApi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LivecodingApi.Samples.UniversalWindows.Auth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string _clientId = "<your-client-id>";
        private string _clientSecret = "<your-client-secret>";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Authenticate
            string token = string.Empty;
            var service = new LivecodingApiService();
            var scopes = new[] { AuthenticationScope.Read, AuthenticationScope.ReadChannel, AuthenticationScope.ReadUser, AuthenticationScope.ReadViewer, AuthenticationScope.Chat };
            bool? isAuthenticated = await service.LoginAsync(_clientId, _clientSecret, scopes);

            // Try to use the API
            try
            {
                var user = await service.GetCurrentUserAsync();

                var paginationRequest = new PaginationRequest
                {
                    Search = "uwp",
                    ItemsPerPage = 20,
                    Page = 2
                };

                var videos = await service.GetVideosAsync(paginationRequest);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
