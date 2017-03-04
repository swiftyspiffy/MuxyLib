using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace MuxyLib
{
    public class Client
    {
        #region Events
        public event EventHandler<Events.Client.OnConnectedArgs> OnConnected;

        public event EventHandler<Events.Client.OnDisconnectedArgs> OnDisconnected;

        public event EventHandler<Events.Client.OnClientErrorArgs> OnClientError;

        public event EventHandler<Events.Client.OnPingArgs> OnPing;

        public event EventHandler<Events.Client.OnBitsArgs> OnBits;

        public event EventHandler<Events.Client.OnFollowArgs> OnFollow;

        public event EventHandler<Events.Client.OnSubscriberArgs> OnSubscriber;

        public event EventHandler<Events.Client.OnSessionChangeArgs> OnSessionChanged;

        public event EventHandler<Events.Client.OnHostedArgs> OnHosted;

        public event EventHandler<Events.Client.OnDonationArgs> OnDonation;
        #endregion

        public bool IsConnected { get { return client != null && client.IsAlive; } }

        private WebSocket client;
        private string overlayUrl;

        public Client(string muxyOverlayUrl)
        {
            overlayUrl = muxyOverlayUrl;
            client = new WebSocket(formatUrlForWebsocket(muxyOverlayUrl));
            client.OnOpen += onConnected;
            client.OnClose += onClosed;
            client.OnError += onError;
            client.OnMessage += onMessage;
        }  

        public void Connect()
        {
            client.Connect();
        }

        public void Disconnect()
        {
            client.Close();
        }

        private void onMessage(object sender, MessageEventArgs e)
        {
            if (!e.IsText)
                return;
            JObject json = JObject.Parse(e.Data);
            if(json.SelectToken("type") != null)
            {
                switch(json.SelectToken("type").ToString())
                {
                    case "command":
                        OnPing?.Invoke(client, new Events.Client.OnPingArgs { UUID = json.SelectToken("extra").SelectToken("uuid").ToString() });
                        break;
                    case "follow":
                        OnFollow?.Invoke(client, new Events.Client.OnFollowArgs
                        {
                            Channel = json.SelectToken("channel").ToString(),
                            Date = Internal.Common.DateTimeStringToObject(json.SelectToken("date").ToString()),
                            Message = json.SelectToken("message")?.ToString(),
                            UserMessage = json.SelectToken("user_message")?.ToString(),
                            Extra = new Models.Client.Follow.Extra(json.SelectToken("extra")),
                            Viewer = new Models.Client.Viewer(json.SelectToken("viewer"))
                        });
                        break;
                    case "subscribe":
                        OnSubscriber?.Invoke(client, new Events.Client.OnSubscriberArgs
                        {
                            Channel = json.SelectToken("channel").ToString(),
                            Date = Internal.Common.DateTimeStringToObject(json.SelectToken("date").ToString()),
                            Message = json.SelectToken("message")?.ToString(),
                            UserMessage = json.SelectToken("user_message")?.ToString(),
                            Extra = new Models.Client.Sub.Extra(json.SelectToken("extra")),
                            Viewer = new Models.Client.Viewer(json.SelectToken("viewer"))
                        });
                        break;
                    case "points_given":
                        OnBits?.Invoke(client, new Events.Client.OnBitsArgs
                        {
                            Channel = json.SelectToken("channel").ToString(),
                            Date = Internal.Common.DateTimeStringToObject(json.SelectToken("date").ToString()),
                            Message = json.SelectToken("message")?.ToString(),
                            UserMessage = json.SelectToken("user_message")?.ToString(),
                            Extra = new Models.Client.Bits.Extra(json.SelectToken("extra")),
                            Viewer = new Models.Client.Viewer(json.SelectToken("viewer"))
                        });
                        break;
                    case "session_change":
                        OnSessionChanged?.Invoke(client, new Events.Client.OnSessionChangeArgs
                        {
                            Channel = json.SelectToken("channel").ToString(),
                            Date = Internal.Common.DateTimeStringToObject(json.SelectToken("date").ToString()),
                            Message = json.SelectToken("message")?.ToString(),
                            UserMessage = json.SelectToken("user_message")?.ToString(),
                            Extra = new Models.Client.SessionChange.Extra(json.SelectToken("extra"))
                        });
                        break;
                    case "hosted":
                        OnHosted?.Invoke(client, new Events.Client.OnHostedArgs
                        {
                            Channel = json.SelectToken("channel").ToString(),
                            Date = Internal.Common.DateTimeStringToObject(json.SelectToken("date").ToString()),
                            Message = json.SelectToken("message")?.ToString(),
                            UserMessage = json.SelectToken("user_message")?.ToString(),
                            Extra = new Models.Client.Hosted.Extra(json.SelectToken("extra")),
                            Viewer = new Models.Client.Viewer(json.SelectToken("viewer"))
                        });
                        break;
                    case "donate":
                        OnDonation?.Invoke(client, new Events.Client.OnDonationArgs
                        {
                            Channel = json.SelectToken("channel").ToString(),
                            Date = Internal.Common.DateTimeStringToObject(json.SelectToken("date").ToString()),
                            Message = json.SelectToken("message")?.ToString(),
                            UserMessage = json.SelectToken("user_message")?.ToString(),
                            Extra = new Models.Client.Donation.Extra(json.SelectToken("extra")),
                            Viewer = new Models.Client.Viewer(json.SelectToken("viewer"))
                        });
                        break;
                }
            }
        }

        private void onConnected(object sender, object e)
        {
            OnConnected?.Invoke(client, new Events.Client.OnConnectedArgs { MuxyOverlayUrl = overlayUrl });
        }

        private void onClosed(object sender, CloseEventArgs e)
        {
            OnDisconnected?.Invoke(client, new Events.Client.OnDisconnectedArgs { MuxyOverlayUrl = overlayUrl });
        }

        private void onError(object sender, ErrorEventArgs e)
        {
            OnClientError?.Invoke(client, new Events.Client.OnClientErrorArgs { Exception = e.Exception });
        }

        private string formatUrlForWebsocket(string url)
        {
            if (url.Contains("ws://"))
                return url;
            if(url.Contains("http"))
            {
                url = url.Replace("https://", "");
                url = url.Replace("http://", "");
            }
            return $"ws://{url}";
        }
    }
}
