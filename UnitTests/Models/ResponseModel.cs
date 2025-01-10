using UnitTests.Enums;

namespace UnitTests.Models
{
    public class ResponseModel
    {
        public string ErrCode { get; set; }
        public string ErrMsg { get; set; }

        public LoginModel Data { get; set; }

        public ResponseModel(ErrorCode code, string message = "", LoginModel data = null)
        {
            ErrCode = EnumExtensions.GetCodeValue(code);
            ErrMsg = string.IsNullOrEmpty(message) ? EnumExtensions.GetDescription(code) : message;
            Data = data;
        }
    }
}
