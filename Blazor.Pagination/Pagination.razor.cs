using Microsoft.AspNetCore.Components;

namespace Blazor.Pagination
{
    public partial class Pagination
    {

        [Parameter]
        [EditorRequired]
        public string NavUrl { get; set; } = String.Empty;
        [Parameter]
        [EditorRequired]
        public int CurrentPageNumber { get; set; } = 1;
        [Parameter]
        [EditorRequired]
        public int ItemsPerPage { get; set; } = 30;
        [Parameter]
        [EditorRequired]
        public int TotalItems { get; set; }

        public int TotalPages
        {
            get
            {
                if (TotalItems == 0 || ItemsPerPage == 0)
                {
                    return 1;
                }

                return (int)Math.Ceiling((double)TotalItems / (double)ItemsPerPage);
            }
        }

        public int StartPage
        {
            get
            {
                int startPage = CurrentPageNumber - 2;
                if (startPage < 1)
                {
                    startPage = 1;
                }

                return startPage;
            }
        }

        public int MaxPage
        {
            get
            {
                int maxPage = StartPage + 4;
                if (maxPage > TotalPages)
                {
                    maxPage = TotalPages;
                }

                return maxPage;
            }
        }

        public string GetUrl(int seite) => $"{NavUrl}{seite}";
    }
}