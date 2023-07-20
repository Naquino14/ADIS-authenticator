using ADIS;
namespace ADIS_authenticator.Models;
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