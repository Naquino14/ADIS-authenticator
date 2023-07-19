using ADIS;
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
}

public partial class OTPCode {
    public string Code { get => AOTP.Code; set => lastCode = value; }
    public string Label { get; set; }

    private AOTP1 AOTP { get; init; }

    public string lastCode;

    public OTPCode(string label, byte[] key, long epoch, int duration) {
        AOTP = new(key, epoch, duration);
        Label = label;
        Code = AOTP.Code;
        lastCode = Code;
    }
}
