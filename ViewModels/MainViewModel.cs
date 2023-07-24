using ADIS;
using ADIS_authenticator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text;

namespace ADIS_authenticator.ViewModels;
public partial class MainViewModel : ObservableObject {
    [ObservableProperty]
    ObservableCollection<OTPCode> codes;

    public MainViewModel() : base() {
        codes = new() {
            new("Test: naa4471@rit.edu", Encoding.ASCII.GetBytes("longerpassword!!"), 1245678, 10),
            new("Test2: AAAAHHHS", Encoding.ASCII.GetBytes("longerpassword!!"), 12678, 10),
            new("Test3: fast boi", Encoding.ASCII.GetBytes("differentpasswrd"), DateTimeOffset.UtcNow.ToUnixTimeSeconds(), 3)
        };
        new Thread(UpdateCodesThread).Start();
    }

    void UpdateCodesThread() {
        for (; ; ) {
            Thread.Sleep(500);
            for (int i = 0; i < Codes.Count; i++) {
                if (Codes[i].Code != Codes[i].lastCode) {
                    var temp = Codes[i];
                    Codes[i] = null;
                    Codes[i] = temp;
                    Codes[i].Code = Codes[i].Code;
                }
            }
        }
    }

    [RelayCommand]
    public void OnPlusClick() {
        // display popup for qr code scanning
    }
}
