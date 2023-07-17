namespace ADIS_authenticator;

using ADIS;
using ADIS_authenticator.Models;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

public partial class MainPage : ContentPage
{
    ObservableCollection<Code> codes;
    public MainPage() {
        InitializeComponent();
        codes = new ObservableCollection<Code> {
            new Code {
                AOTP = new(Encoding.ASCII.GetBytes("..bazingasim2026!"), 0, 3),
                Label = "Test: naa4471@rit.edu"
            }
        };
        collectionView.BindingContext = codes;
        collectionView.ItemsSource = codes;
    }
    private async void OnCounterClicked(object sender, EventArgs e) {
        collectionView.ItemsSource.Cast<Code>().First().Label = "bzainga test 12345678987654567";
		await CounterBtn.ScaleTo(1.1, 100);
        await CounterBtn.ScaleTo(1, 100);
    }
}

