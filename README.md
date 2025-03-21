# EscapeLifeCommon

## Author

- Dan Simonin

## How to Use

### Global

### Dependecies

 - Newtonsoft ([For Unity](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.2/manual/index.html))

#### Guidelines

Unity requires more imports than ASP.NET, remove non required `using` statements only from Unity to make sure you don't break the Unity side.

#### Environnement specic code

Since specific logic needs to be applied from both server and client, the classes are partial and extension methods are added.

The partial implementation only work on the server side as EscapeLifeCommon is placed in the same assembly.
To solve the issue for the Unity side, where git packages are placed in another assembly, extension methods are added to process a method after receiving it.

Example for `ConnectionProcessors.cs`:

```csharp
namespace EscapeLifeCommon.Messages.Connection
{
    public static class ConnectionSuccessfulProcessor
    {
        public static void Process(this ConnectionSuccessfulMessage m)
        {
            Debug.Log($"Connection to game '{m.GameId}' Successful!");
            MainMenuEvents.MissionScreenShown?.Invoke();
        }
    }

    public static class ConnectionFailedProcessor
    {
        public static async void Process(this ConnectionFailedMessage m)
        {
            Debug.Log($"Connection Failed: {m.ConnectionFailedType} !");
            await WebSocketManager.Instance.Close();
        }
    }
}
```

This approach needed more work when calling `Process` for a `MessageBase` object since extension methods do not work with polymorphism.
A `MessageBaseProcessor.cs` resides in the server and client and resolves the concrete class `Process` method using reflection when calling `MessageBase.Process()`.

### Server (ASP.NET)

This git repository is already added into the server git repository as a submodule.
To use it, check the EscapeLifeServer's [README](https://github.com/MikleRe/EscapeLifeServer/blob/main/README.md) file.

### Client (Unity)

This git repository is added as a Unity Package from git directly!

## File Structure

Definitions of the messages that are sent between the server and the client, those implementations need to be shared between both of the parties. 
This allows Newtonsoft (JSON library) to serialize a message, send it and then, on the other side, deserialize it back.

- **EscapeLifeCommon.asmdef**: Definition of the assembly.
- **package.json**: Definition of the Unity package.
- **MessageBase.cs**: Abstract class that defines the common variables and functions of all message type.
- **MessageBaseConverter.cs**: A Newtonsoft converter that allows to deserialize any message to its concrete message class.

The Chat folder contains all the messages that will be displayed in the chat:
 - **AutomaticMessage.cs**: Messages that have localized strings. (Server->Client)
 - **EventMessage.cs**: Relating to a connection or disconnection of a certain user. (Server->Client)
 - **ImageMessage.cs**: An image sent as message in Base64. (All->All)
 - **TextMessage.cs**: Basic text message. (All->All)
 - **VideoMessage.cs**: A video sent as a URI. (Server->Client)

The Connection folder contains all the messages that will be sent to answer a connection:
 - **ConnectionFailedMessage.cs**: Sent to a user that tries to connect to a game that does not exists, is not valid or that is username is not valid. 
 - **ConnectionFailedType.cs**: Enum of causes why the connection was failed.
 - **ConnectionSuccessfulMessage.cs**: Sent to a user that connected successfuly with data relating to the state of the game.

The Game folder contains all the messages relating to the development of the game:
 - **CoordinatesMessage.cs**: Current coordinates. (Client->Server)
 - **EnigmaMessage.cs**: Start of an enigma step. (Server->Client)
 - **FinishMessage.cs**: End of game. (Server->Client)
 - **MoveMessage.cs**: Start of a move step. (Server->Client)

The TriggerKey folder contains the messages relating to trigger keys:
 - **TriggerKeyMessage.cs**: Used to test a Trigger Key with ``Type=TriggerKeyMessageType.Query`` (Client->Server) and to answer a query with ``Type=TriggerKeyMessageType.Success``, ``Type=TriggerKeyMessageType.TriggerSuccess`` or ``Type=TriggerKeyMessageType.Failure`` (Server->Client).  
