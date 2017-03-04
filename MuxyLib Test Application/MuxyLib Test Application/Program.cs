using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuxyLib;

namespace MuxyLib_Test_Application
{
    class Program
    {
        private static Client client;
        static void Main(string[] args)
        {
            Console.Title = "MuxyLib Test Application - swiftyspiffy";
            Console.WriteLine("This is a test application to demonstrate all of the events that MuxdyLib provides.");
            client = new Client("YOUR_MUXY_OVERLAY_URL_HERE");
            client.OnConnected += onConnected;
            client.OnFollow += onFollow;
            client.OnBits += onBits;
            client.OnSubscriber += onSubscriber;
            client.OnHosted += onHosted;
            client.OnSessionChanged += onSessionChanged;
            client.OnDonation += onDonation;
            client.Connect();
            while (true) ;
        }

        private static void onConnected(object sender, MuxyLib.Events.Client.OnConnectedArgs e)
        {
            Console.WriteLine("Connected to Muxy service!");
        }

        private static void onFollow(object sender, MuxyLib.Events.Client.OnFollowArgs e)
        {
            Console.WriteLine($"Follower detected! Follower name: {e.Viewer.Name}");
        }

        private static void onBits(object sender, MuxyLib.Events.Client.OnBitsArgs e)
        {
            Console.WriteLine($"Bits detected! From {e.Viewer.Name}, amount: {e.Extra.Amount}");
        }

        private static void onSubscriber(object sender, MuxyLib.Events.Client.OnSubscriberArgs e)
        {
            Console.WriteLine($"Subscriber detected! Name: {e.Viewer.Name}, months: {e.Extra.Amount}");
        }

        private static void onHosted(object sender, MuxyLib.Events.Client.OnHostedArgs e)
        {
            Console.WriteLine($"We were just hosted by {e.Viewer.Name} for {e.Extra.Amount} viewers!");
        }

        private static void onSessionChanged(object sender, MuxyLib.Events.Client.OnSessionChangeArgs e)
        {
            Console.WriteLine($"A session change was detected! Currently live: {e.Extra.IsLive}");
        }

        private static void onDonation(object sender, MuxyLib.Events.Client.OnDonationArgs e)
        {
            Console.WriteLine($"A donation was just received from {e.Viewer.Name} in the amount of {e.Extra.Amount}!");
        }
    }
}
