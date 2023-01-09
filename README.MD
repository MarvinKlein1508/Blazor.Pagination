# Blazor.Pagination
A simple to use blazor component to implement a pagination based on Bootstrap 5.2.


## Installation

You can install from Nuget using the following command:

`Install-Package Blazor.Pagination`

Or via the Visual Studio package manger.

## Basic usage
Start by add the following using statement to your root `_Imports.razor`.

    @using Blazor.Pagination

To use the component, your page should define a public parameter for the current page and for the `TotalItems`. For example:

```csharp
    private int _page = 1;
    [Parameter]
    public int Page { get => _page; set => _page value < 1 ? 1 : value; }
    
    public int TotalItems { get; set; }
    
    public async Task LoadAsync(bool navigateToFirstPage = false) 
    {
        // Provide Page to your class or method
        TotalItems = 100;// YOUR_METHOD_TO_FETCH_TOTAL_ITEMS;
        // Do your Loading here.
    }
```
Within your function that loads the data you can forward the Page property to any class of method. Your method should also call another method to set `TotalItems`


Your site should be accessible with two routes. For example:
```csharp
@page "/Customer"
@Page "/Customer/Page/{Page:int}"
```

**Note: The route without a page directive should always default to 1. Make sure to check that Page is greater than or equal to 1.**

The component expects you to provide three parameters. 
| Parameter | Type | Function
|---|---|---|
|  Page | int  | The currently active page
| TotalItems | int | The total amount of available items
| NavUrl | string | The base for the generated nav-links.

You can embed the component in your `.razor` files like this:
```csharp
    <Pagination Page="Page"
                TotalItems="TotalItems"
                NavUrl="/Customer/Page/" />
```



To unify the use of the component, the component also provides the `IHasPagination` interface. This contains all needed properties as well as a function to Load the data.

## EventPagination
This nuget package also offers another pagination component based on events. This one should be used when you don't want to provide the current page via URL.

The usage for this component is identical with the regular pagination component. The difference is that instead of providing a `NavUrl` as parameter, you'll need to provide an `EventCallback<int>`.
```csharp
    <EventPagination Page="Page"
                TotalItems="TotalItems"
                PageChanged="OnPageChangedAsync" />
    
    @code {
        private async Task OnPageChangedAsync(int pageNumber)
        {
            Page = pageNumber;
            await LoadAsync();
        }

        public async Task LoadAsync(bool navigateToFirstPage = false) 
        {
            // Provide Page to your class or method
            TotalItems = 100;// YOUR_METHOD_TO_FETCH_TOTAL_ITEMS;
            // Do your Loading here.
        } 
    }
```

The component expects you to provide three parameters. 
| Parameter | Type | Function
|---|---|---|
|  Page | int  | The currently active page
| TotalItems | int | The total amount of available items
| PageChanged | EventCallback<int> | A callback function which does something based on the selected page number