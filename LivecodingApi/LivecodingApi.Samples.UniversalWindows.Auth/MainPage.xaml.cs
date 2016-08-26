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
            bool useReactive = true;
            var scopes = AuthenticationScope.All;

            var paginationRequest = new PaginationRequest
            {
                Search = "uwp",
                ItemsPerPage = 20,
                Page = 2
            };

            if (useReactive)
            {
                // Authenticate
                var reactiveService = new ReactiveLivecodingApiService();
                reactiveService.Login(_clientId, _clientSecret, scopes)
                    .Subscribe((result) =>
                    {
                        // TODO : Handle errors using Reactive paradigm
                        if (result.HasValue && result.Value)
                        {
                            // Try to use the API
                            reactiveService.GetCurrentUser()
                                .Subscribe((userResult) =>
                                {

                                });

                            reactiveService.GetVideos(paginationRequest)
                                .Subscribe((videosResult) =>
                                {

                                });
                        }
                    });
            }
            else
            {
                // Authenticate
                var service = new LivecodingApiService();
                bool? isAuthenticated = await service.LoginAsync(_clientId, _clientSecret, scopes);

                // Try to use the API
                try
                {
                    var user = await service.GetCurrentUserAsync();
                    var videos = await service.GetVideosAsync(paginationRequest);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
    }
}
