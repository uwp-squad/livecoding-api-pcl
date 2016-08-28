# Livecoding API (PCL)

[![Build status](https://ci.appveyor.com/api/projects/status/4vkocg0u74gep51u?svg=true)](https://ci.appveyor.com/project/Odonno/livecoding-api-pcl)

A .NET library to access the livecoding.tv API

Supported platform :

- .NET Framework 4.5
- Windows 8, Windows 8.1
- Windows Phone 8.1
- Windows 10 (UWP)
- Xamarin.iOS
- Xamarin.Android (not available - 1 issue to fix)

## Documentation

Take a look at the livecoding API documentation here : https://www.livecoding.tv/developer/documentation/#!/api

### How to use ? (normal implementation)

Initialize an instance of `LivecodingApiService` and you are ready to use the livecoding API.
First, retrieve token through Authentication/Login process and then call API endpoints with methods available in the API service.

#### Authentication

To retrieve a token and access API endpoints, you have to provide the client id, client secret of your application (OAuth credentials).
And you have to provide the `scopes` list, a list of granted access your application requires.

```
var apiService = new LivecodingApiService();
var scopes = new string[] { AuthenticationScope.Read };
bool? isAuthenticated = await apiService.LoginAsync("<your-client-id>", "<your-client-secret>", scopes);
```

If `isAuthenticated == true`, it means you have been successfully authenticated and the token allow you to make API calls.
In other case, something went wrong during the authentication process.

#### Pagination

The API endpoints for with pagination is written with some `Hypermedia controls`. 
The pagination also contains properties to enable search, ordering, filtering.
Here is a short description of pagination :

- `Page` - from 1 to TotalPages
- `Count` - number of results present in the page
- `ItemsPerPage` - maximum number of results per page
- `Search` - text search on items
- `Ordering` - order items based on a field, max 1 ordering field per request
- `DescendingOrdering` - if true, ordering field is in DESC mode instead of ASC mode
- `Filters` - list of filters to dive into items results

```
// Assuming you have been succesfully authenticated
var apiService = new LivecodingApiService();
var paginationRequest = new PaginationRequest
{
    Search = "uwp",
    ItemsPerPage = 20,
    Page = 2
};
var paginationVideos = await apiService.GetVideosAsync(paginationRequest);
```

Now, you can use `paginationVideos.Results` which is a list of videos based on your search request.

#### Ordering

You can order your results by some field (example: creation date, slug, ..).
Here is an example to get the latest created videos about "UWP".

```
// Assuming you have been succesfully authenticated
var apiService = new LivecodingApiService();
var paginationRequest = new PaginationRequest
{
    Search = "uwp",
    ItemsPerPage = 20,
    Ordering = VideoOrderingField.CreationDate,
    DescendingOrdering = true
};
var paginationVideos = await apiService.GetVideosAsync(paginationRequest);
```

#### Filtering

You can filter your results by some field (example: coding category, difficulty, ..).
Here is an example to get videos about ruby programming.

```
// Assuming you have been succesfully authenticated
var apiService = new LivecodingApiService();
var paginationRequest = new PaginationRequest
{
    ItemsPerPage = 20
};
paginationRequest.Filters.Add(VideoFilteringField.CodingCategory, "ruby");
var paginationVideos = await apiService.GetVideosAsync(paginationRequest);
```

#### Handling exceptions

Do not forget that your API can be break. So, here is a way to handle exceptions using the normal implementation.

```
var apiService = new LivecodingApiService();
try
{
    bool? isAuthenticated = await apiService.LoginAsync("<your-client-id>", "<your-client-secret>", scopes);
}
catch (Exception ex)
{
    // TODO
}
```

### How to use ? (reactive implementation)

#### Authentication

#### Pagination

#### Ordering

#### Filtering

#### Handling exceptions