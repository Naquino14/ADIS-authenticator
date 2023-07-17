using ADIS;

namespace ADIS_authenticator.Models;

internal class Code {
    public AOTP1 AOTP { get; init; }
    public string Label { get; set; }
}