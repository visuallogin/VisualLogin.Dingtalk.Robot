using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VisualLogin.Dingtalk.Robot
{
    public class RobotSend
    {
        private const string BaseUrl = "https://oapi.dingtalk.com/robot/send?access_token=";
        private static RobotSend _instance;

        private RobotSend()
        {
        }

        public string Token { get; set; }
        public string Secret { get; set; }

        public static RobotSend GetInstance()
        {
            return _instance ?? (_instance = new RobotSend());
        }

        public async Task<RobotResponse> Post(IRobotMessage robotMessage)
        {
            return await Post(Token, Secret, robotMessage);
        }
        public async Task<RobotResponse> Post(string token,string secret, IRobotMessage robotMessage)
        {
            if (string.IsNullOrWhiteSpace(token)) throw new Exception("token is null or empty!");
            if (string.IsNullOrWhiteSpace(secret)) throw new Exception("token is null or empty!");
            var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var secretEnc = Encoding.UTF8.GetBytes(Secret);
            var stringToSign = $"{timestamp}\n{Secret}";
            var stringToSignEnc = Encoding.UTF8.GetBytes(stringToSign);
            var hmac256 = new HMACSHA256(secretEnc);
            var hashMessage = hmac256.ComputeHash(stringToSignEnc);
            var sign = Convert.ToBase64String(hashMessage);
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var http = new HttpClient(httpClientHandler);
            var str = new StringContent(JsonConvert.SerializeObject(robotMessage), Encoding.UTF8,
                "application/json");
            var httpResponseMessage = await http.PostAsync($"{BaseUrl}{Token}&timestamp={timestamp}&sign={sign}", str);
            var res = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RobotResponse>(res);
        }
    }
}