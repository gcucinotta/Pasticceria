// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Pasticceria.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Pasticceria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Pasticceria.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Progetti\Pasticceria\Pasticceria\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/dolci")]
    public partial class Dolci : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "D:\Progetti\Pasticceria\Pasticceria\Pages\Dolci.razor"
       
        string baseUrl;
        IEnumerable<Data.Entity.Dolce> dolci;
        RadzenDataGrid<Data.Entity.Dolce> myGridDolci;

    protected override async Task OnInitializedAsync()
    {
        baseUrl = myAppSettings.GetBaseUrl();
        dolci = await myCustomHttpClient.GetJsonAsync<Data.Entity.Dolce[]>(baseUrl + "/api/dolci/get");
    }

    void RowRender(RowRenderEventArgs<Data.Entity.Dolce> args)
    {
        args.Expandable = true;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        //if (firstRender)
        //{
        //    grid.ExpandRow(dolci.FirstOrDefault());
        //    StateHasChanged();
        //}

        //base.OnAfterRender(firstRender);
    }

    async Task delDolce(Data.Entity.Dolce myDolce)
    {
        var confirmResult = await myDialogService.Confirm("Verranno cancellati il dolce e tutti gli ingredienti associati. Confermi ?", "Attenzione", new ConfirmOptions() { OkButtonText = "SI", CancelButtonText = "NO" });
        if (confirmResult.HasValue && confirmResult.Value)
        {
            HttpResponseMessage message = await myCustomHttpClient.DeleteAsync(baseUrl + "/api/ingredienti/deletebydolce/" + myDolce.ID);
            if (message.IsSuccessStatusCode)
            {
                message = await myCustomHttpClient.DeleteAsync(baseUrl + "/api/dolci/delete/" + myDolce.ID);
                if (message.IsSuccessStatusCode)
                    dolci = await myCustomHttpClient.GetJsonAsync<Data.Entity.Dolce[]>(baseUrl + "/api/dolci/get");
            }
        }
    }

    async Task addDolce()
    {
        await myDialogService.OpenAsync<DolciDetail>("Inserimento nuovo dolce",
                new Dictionary<string, object>() { { "IDDolce", 0 } },
                new DialogOptions() { Width = "900px", Height = "700px", Resizable = true, Draggable = true });

        dolci = await myCustomHttpClient.GetJsonAsync<Data.Entity.Dolce[]>(baseUrl + "/api/dolci/get");
    }

    async Task editDolce(Data.Entity.Dolce myDolce)
    {
        await myDialogService.OpenAsync<DolciDetail>("Modifica dolce",
                new Dictionary<string, object>() { { "IDDolce", myDolce.ID } },
                new DialogOptions() { Width = "900px", Height = "700px", Resizable = true, Draggable = true });

        dolci = await myCustomHttpClient.GetJsonAsync<Data.Entity.Dolce[]>(baseUrl + "/api/dolci/get");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NotificationService myNotificationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Radzen.DialogService myDialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Data.Service.AppSettings myAppSettings { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Data.Service.CustomHttpClient myCustomHttpClient { get; set; }
    }
}
#pragma warning restore 1591
