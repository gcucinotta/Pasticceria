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
    [Microsoft.AspNetCore.Components.RouteAttribute("/backoffice")]
    public partial class Backoffice : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "D:\Progetti\Pasticceria\Pasticceria\Pages\Backoffice.razor"
       
    string _eMail;
    string _password;
    string baseUrl;
    Data.Entity.Utente myUtente = new Data.Entity.Utente();

    protected override async Task OnInitializedAsync()
    {
        await Task.Run(() =>
        {
            myUtente.eMail = string.Empty;
            myUtente.Password = string.Empty;
        });
    }

    async Task onAccedi()
    {
        if (string.IsNullOrWhiteSpace(_eMail) || string.IsNullOrWhiteSpace(_password))
        {
            Messagge("Attenzione", "Inserire le credenziali.", NotificationSeverity.Info);
            return;
        }

        baseUrl = myAppSettings.GetBaseUrl();
        myUtente = await myCustomHttpClient.GetJsonAsync<Data.Entity.Utente>(baseUrl + "/api/utenti/isexists/" + _eMail);
        if (myUtente == null)
        {
            Messagge("Attenzione", "Credenziali non valide.", NotificationSeverity.Error);
            return;
        }

        if (myUtente.ID != 0)
        {
            // Controllo password ...
            if (myUtente.Password == _password) {
                myNavigationManager.NavigateTo("Dolci");
            }
            else
            {
                Messagge("Attenzione", "Credenziali non valide.", NotificationSeverity.Error);
            }
        }
    }

    private void Messagge(string title, string detail, NotificationSeverity severity)
    {
        myNotificationService.Notify(new NotificationMessage { Severity = severity, Summary = title, Detail = detail, Duration = 4000 });
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager myNavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NotificationService myNotificationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Data.Service.AppSettings myAppSettings { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Data.Service.CustomHttpClient myCustomHttpClient { get; set; }
    }
}
#pragma warning restore 1591
