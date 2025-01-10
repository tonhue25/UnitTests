using System.ComponentModel;

namespace UnitTests.Enums
{
    public enum ErrorCode
    {
        [Description("Success")]
        Success = 00,

        [Description("Unknown error")]
        Error = 99,

        [Description("Invalid Input Data")]
        InvalidInputData = 03,

        [Description("Not Found")]
        NotFound = 01,
    }
}
