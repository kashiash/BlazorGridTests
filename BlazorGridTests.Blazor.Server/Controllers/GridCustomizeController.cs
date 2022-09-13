using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.JSInterop;
using BlazorGridTests.Blazor.Server;
using DevExpress.ExpressApp.Blazor;
using GridWithContextMenu.Data;
using BlazorGridTests.Module.BusinessObjects;

namespace BlazorGridTests.Module.Controllers
{
    public class GridCustomizeController : ViewController<ListView>
    {
        string LocalStorageKey = "dupa";
        IJSRuntime JSRuntime;
        IObjectSpace objectSpace;

        GridContextMenuContainer ContextMenuContainer { get; set; }


        public GridCustomizeController() : base()
        {

            // Target required Views (use the TargetXXX properties) and create their Actions.
            //if (Application != null)
            //{
            //    JSRuntime = ((BlazorApplication)Application).ServiceProvider.GetRequiredService<IJSRuntime>();
            //}
        }


        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
          
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            if (objectSpace == null)
            {
                objectSpace = Application.CreateObjectSpace();
            }

            if (View.Editor is DxGridListEditor gridListEditor)
            {
                IDxGridAdapter dataGridAdapter = gridListEditor.GetGridAdapter();
                dataGridAdapter.GridModel.ColumnResizeMode = DevExpress.Blazor.GridColumnResizeMode.ColumnsContainer;

                dataGridAdapter.GridModel.DetailRowDisplayMode = GridDetailRowDisplayMode.Auto;
               
                dataGridAdapter.GridModel.ShowFilterRow = true;


                LocalStorageKey = View.Id;

                dataGridAdapter.GridModel.LayoutAutoSaving = async (GridPersistentLayoutEventArgs e) => 
                {
                    await SaveLayoutToLocalStorageAsync(e.Layout); 
                };
                dataGridAdapter.GridModel.LayoutAutoLoading = async (GridPersistentLayoutEventArgs e) =>
                {
                    e.Layout = await LoadLayoutFromLocalStorageAsync();
                };



            }
        }
        async Task<GridPersistentLayout> LoadLayoutFromLocalStorageAsync()
        {
            try
            {
             //   var json =  await JSRuntime.InvokeAsync<string>("localStorage.getItem", LocalStorageKey);
                var json = GetLayout();
                return JsonSerializer.Deserialize<GridPersistentLayout>(json);
            }
            catch
            {
                // Mute exceptions
                return null;
            }
        }

        private string GetLayout()
        {
            var storage = objectSpace.GetObjectsQuery<BlazorLayoutStorage>()
     .Where(s => s.ViewId == LocalStorageKey && s.PermissionPolicyUser == (Guid)SecuritySystem.CurrentUserId).FirstOrDefault();
            return storage != null ? storage.Layout : null;
        }

        async Task SaveLayoutToLocalStorageAsync(GridPersistentLayout layout)
        {
            try
            {
                var json = JsonSerializer.Serialize(layout);
                //   await JSRuntime.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, json);
                StoreLayout(json);
            }
            catch
            {
                // Mute exceptions
            }
        }

        private void StoreLayout(string json)
        {
            var storage = objectSpace.GetObjectsQuery<BlazorLayoutStorage>()
                .Where(s => s.ViewId == LocalStorageKey && s.PermissionPolicyUser == (Guid)SecuritySystem.CurrentUserId).FirstOrDefault();
            if (storage == null)
            {
                storage = objectSpace.CreateObject<BlazorLayoutStorage>();
                storage.ViewId = LocalStorageKey;
                storage.PermissionPolicyUser = (Guid)SecuritySystem.CurrentUserId;
            }
            storage.Layout = json;
            objectSpace.CommitChanges();
        }
    }

}
