
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Client;

public partial class EmployeeListPage : ContentPage
{
	public EmployeeListPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        EmployeeListViewModel viewModel = new();
        viewModel.Clear();
        LoadEmployee();
    }

    private void LoadEmployee()
    {
        EmployeeListViewModel viewModel = new();
        HttpClient client = new()
        {
            BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5142" : "http://localhost:5142")
             
        };
        client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync("api/employees").Result;
        response.EnsureSuccessStatusCode();

        IEnumerable<EmployeeViewModel> employeeFromApi = response.Content.ReadFromJsonAsync<IEnumerable<EmployeeViewModel>>().Result;
        foreach (EmployeeViewModel e in employeeFromApi.OrderBy(emp => emp.EmployeeName))
        {
            viewModel.Add(e);
        }
        BindingContext = viewModel;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmployeeCreatePage(BindingContext as EmployeeListViewModel));
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is not EmployeeViewModel c) return;
        await Navigation.PushAsync(new EmployeeCreatePage(BindingContext as EmployeeListViewModel, c));
    }

    private async void ListView_Refreshing(object sender, EventArgs e)
    {
        if (sender is not ListView listView) return;
        listView.IsRefreshing = true;
        await Task.Delay(1500);
        listView.IsRefreshing = false;
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        MenuItem menuItem = sender as MenuItem;
        if (menuItem.BindingContext is not EmployeeViewModel emp) return;
        try
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5142" : "http://localhost:5142");
            HttpResponseMessage response = await client.DeleteAsync($"api/employees/{emp.EmployeeId}");
            if (response.IsSuccessStatusCode)
            {
                (BindingContext as EmployeeListViewModel)?.Remove(emp);
            }
            else
            {
                await DisplayAlert("Error", "Falied to delete", "OK");
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", $"Error Occured: {ex.Message}", "OK");
        }
    }
}