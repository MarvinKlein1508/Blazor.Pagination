# Blazor.Pagination
A simple to use blazor component to implement a pagination based on Bootstrap 5.2.


## Installation

You can install from Nuget using the following command:

`Install-Package Blazor.Pagination`

Or via the Visual Studio package manger.

## Basic usage
Start by add the following using statement to your root `_Imports.razor`.

    @using Blazor.Pagination

To use the component, your page should define a public parameter for the current page. For example:

```csharp
    private int _page = 1;
    [Parameter]
    public int Page { get => _page; set => _page value < 1 ? 1 : value; }
```

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

    <Pagination Page="Page"
                TotalItems="TotalItems"
                NavUrl="/Customer/Page/" />



To unify the use of the component, the component also provides the `IHasPagination` interface. This contains all needed properties as well as a function to Load the data.

