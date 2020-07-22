using System.Collections.Generic;
using Newtonsoft.Json;

namespace VisualLogin.Dingtalk.Robot
{
    #region RobotMessage


    public class RobotMessageText :IRobotMessage
    {
        [JsonProperty("text")]
        public RobotMessageExtensionsText Text { get; set; } = new RobotMessageExtensionsText();
        [JsonProperty("at")]
        public RobotMessageExtensionsAt At { get; set; } = new RobotMessageExtensionsAt();
        [JsonProperty("msgtype")] 
        public string MsgType { get; set; } = "text";
    }
    public class RobotMessageLink : IRobotMessage
    {
        [JsonProperty("msgtype")]
        public string MsgType { get; set; } = "link";
        public RobotMessageExtensionsLink Link { get; set; } = new RobotMessageExtensionsLink();
    }
    public class RobotMessageMarkdown : IRobotMessage
    {
        [JsonProperty("msgtype")] 
        public string MsgType { get; set; } = "markdown";
        [JsonProperty("markdown")]
        public string Markdown { get; set; }
        [JsonProperty("at")]
        public RobotMessageExtensionsAt At { get; set; } = new RobotMessageExtensionsAt();
    }
    public class RobotMessageActionCardSingle : IRobotMessage
    {
        [JsonProperty("msgtype")]
        public string MsgType { get; set; } = "actionCard";
        [JsonProperty("actionCard")]
        public RobotMessageExtensionsActionCardSingle ActionCard { get; set; } = new RobotMessageExtensionsActionCardSingle();
    }
    public class RobotMessageActionCard : IRobotMessage
    {
        [JsonProperty("msgtype")]
        public string MsgType { get; set; } = "actionCard";
        [JsonProperty("actionCard")]
        public RobotMessageExtensionsActionCard ActionCard { get; set; } = new RobotMessageExtensionsActionCard();
    }
    public class RobotMessageFeedCard : IRobotMessage
    {
        [JsonProperty("msgtype")]
        public string MsgType { get; set; } = "feedCard";
        [JsonProperty("feedCard")]
        public RobotMessageExtensionsFeedCard FeedCard { get; set; } = new RobotMessageExtensionsFeedCard();
    }

    #endregion

    #region RebotMessageExt

    public class RobotMessageExtensionsText
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
    public class RobotMessageExtensionsAt
    {
        [JsonProperty("atMobiles")]
        public string[] AtMobiles { get; set; }
        [JsonProperty("isAtAll")]
        public bool IsAtAll { get; set; }
    }
    public class RobotMessageExtensionsLink
    {
        [JsonProperty("text")]
        public string Text { get; set; }   
        [JsonProperty("title")]
        public string Title { get; set; }     
        [JsonProperty("picUrl")]
        public string PicUrl { get; set; }
        [JsonProperty("messageUrl")]
        public string MessageUrl { get; set; }
    }
    public class RobotMessageExtensionsMarkdown
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class RobotMessageExtensionsActionCardSingle
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("btnOrientation")]
        public string BtnOrientation { get; set; }
        [JsonProperty("singleTitle")]
        public string SingleTitle { get; set; } 
        [JsonProperty("singleURL")]
        public string SingleUrl { get; set; }
    }
    public class RobotMessageExtensionsActionCard
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("btns")]
        public List<RobotMessageExtensionsActionCardBtn> Btns { get; set; } = new List<RobotMessageExtensionsActionCardBtn>();
    }
    public class RobotMessageExtensionsActionCardBtn
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("actionURL")]
        public string ActionUrl { get; set; }
    }
    public class RobotMessageExtensionsFeedCard
    {
        [JsonProperty("links")]
        public List<RobotMessageExtensionsLink> Links { get; set; }=new List<RobotMessageExtensionsLink>();
    }
    #endregion
}
