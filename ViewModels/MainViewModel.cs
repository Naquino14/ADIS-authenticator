using ADIS;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ADIS_authenticator.ViewModels;
public partial class MainViewModel : ObservableObject {
    [ObservableProperty]
    ObservableCollection<string> codes;

    public MainViewModel() : base() {
        codes = new() {
            "abcd",
            "efg"
        };
    }

    [RelayCommand]
    void Update() {
        Codes[0] = "AAAAAAAAAAAAA";
    }
}
