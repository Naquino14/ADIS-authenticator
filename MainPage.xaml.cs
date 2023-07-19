namespace ADIS_authenticator;

using ADIS;
using ADIS_authenticator.ViewModels;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm) {
        InitializeComponent();
        BindingContext = vm;
    }
    private async void OnCounterClicked(object sender, EventArgs e) {
		await CounterBtn.ScaleTo(1.1, 100);
        await CounterBtn.ScaleTo(1, 100);
    }
}

