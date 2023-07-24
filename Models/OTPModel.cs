using ADIS;
using System.Globalization;
using System.Text.RegularExpressions;

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

    public static OTPCode? StrToCode(string input) {
        // ssv
        // example string: label;hex-key;epoch;duration;
        // test string: "Test D: naa4471@rit.edu;bb9fa0c66ca9b744d878a46e3db1b17e;1690157759;15;"
        // this might change later if I add a custom ptotocol to open the app

        // check for valid ssv (null is invalid)
        var regex = new Regex(@".+;(([a-f]|[A-F]|[0-9]){2}){16};\d+;\d+;");
        if (!regex.IsMatch(input))
            return null;

        var values = input.Split(';');
        values[1] = values[1].ToLower();
        var key = new byte[16];
        for (int i = 0; i < 16; i++)
            key[i] = byte.Parse(values[1][(2 * i)..(2 * i + 2)], NumberStyles.HexNumber);
        long epoch = long.Parse(values[2]);
        int duration = int.Parse(values[3]);
        return new(values[0], key, epoch, duration);
    }
}