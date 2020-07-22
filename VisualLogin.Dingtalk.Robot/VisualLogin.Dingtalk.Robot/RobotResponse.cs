using Newtonsoft.Json;

namespace VisualLogin.Dingtalk.Robot
{
    public class RobotResponse
    {
        [JsonProperty("errcode")]
        public long ErrCode { get; set; }
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

    }
}