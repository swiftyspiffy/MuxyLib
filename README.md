## MuxyLib - [Muxy](https://muxy.io/) Events for .NET
*****
### About
MuxyLib is a .NET library that can interface with the Muxy donation service. It has a number of events that can be subscribed to, each with sets of data relevant to the specified event.
*****
### Events
#### Client Specific
 - `OnConnected` - Fires when connected to Muxy service.
 - `OnDisconnected` - Fires when disconnected from Muxy service.
 - `OnClientError` - Fires when an error occurs in the client.

#### Muxy Specific
 - `OnPing` - Fires when Muxy sends a Ping.
 - `OnBits` - Fires when Muxy detects a user sent bits in chat.
 - `OnFollow` - Fires when Muxy detects a new follower.
 - `OnSubscriber` - Fires when Muxy detects a new subscriber.
 - `OnSessionChange` - Fires when Muxy detects session change (online/offline).
 - `OnHosted` - Fires when Muxy detects a user has started hosting the channel.
 - `OnDonation` - Fires when Muxy receives a donation for the specified channel.
 
*****

### Example Implementations
While the Muxy Test Application provided in this repository demos all of the events in this library, initialization and a few events are shown below in a console app implementation:
```csharp
private static Client client;
static void Main(string[] args)
{
    client = new Client("YOUR_MUXY_OVERLAY_URL_HERE");
    client.OnConnected += onConnected;
    client.OnFollow += onFollow;
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
private static void onDonation(object sender, MuxyLib.Events.Client.OnDonationArgs e)
{
    Console.WriteLine($"A donation was just received from {e.Viewer.Name} in the amount of {e.Extra.Amount}!");
}
```

*****

### Installation/Download
#### [NuGet](https://www.nuget.org/packages/MuxyLib/)

To install this library via NuGet via NuGet console, use:
```
Install-Package MuxyLib
```
and via Package Manager, simply search:
```
MuxyLib
```
#### Build
In addition to the NuGet package listing, you are also welcome to fork/clone this repo and build the project yourself, modifying it as you need.

*****

### Dependencies
* Newtonsoft.Json 7.0.1+ ([nuget link](https://www.nuget.org/packages/Newtonsoft.Json/7.0.1))
* WebSocketSharp-NonPreRelease ([nuget link](https://www.nuget.org/packages/WebSocketSharp-NonPreRelease/))

*****

### License
A license file exists in this project by the name of LICENSE .

*****