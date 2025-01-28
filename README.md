# EscapeLife

## Author

- Dan Simonin

## How to Use

### Common usage file structure

Parent is equals to `EscapeLifeServer/Models` for the server and `Assets/Scripts/` for the client.

```md
Parent
├── EscapeLife
│   ├── Chat
│   │   ├── ...
│   │   └── ...
│   ├── Game
│   │   ├── ...
│   │   └── ...
│   ├── TriggerKey
│   │   ├── ...
│   │   └── ...
│   ├── MessageBase.cs
│   ├── MessageBaseConverter.cs
│   └── SetupMessage.cs
└── Processors
│   ├── ChatProcessors.cs
.   ├── GameProcessors.cs
.   ├── TriggerKeyProcessors.cs
    ├── MessageBase.cs
    └── SetupMessage.cs
```

### Global

#### Guidelines

Unity requires more imports than ASP.NET, remove non required `using` statements only from Unity to make sure you don't break the Unity side.

#### Environnement specic code

The classes are defined as partial since some specific logic needs to be added on both the server and the client.
By overriding the `Process()` method of a class that implements `MessageBase`, you can write specific environnement code. 
To do so, create a `Processors` folder under the parent folder with the same namespace as the other file.

Example for `ChatProcessors.cs`:

```csharp
namespace EscapeLife.Models.Messages.Chat
{
    public partial class EventMessage
    {
        public override void Process() {
            // your code here
        }
    }

    public partial class ImageMessage
    {
        public override void Process() => throw new NotImplementedException();
    }
}
```

### Server (ASP.NET)

This git repository is already added into the server git repository as a submodule.
To use it, check the EscapeLifeServer's [README](https://github.com/MikleRe/EscapeLifeServer/blob/main/README.md) file.

### Client (Unity)

Clone this repository under `/Assets/Scripts/`:

```bash
cd /Assets/Scripts/
git clone https://github.com/MikleRe/EscapeLife.git
```

Remember that `/Assets/Scripts/EscapeLife` is ignored in Plastic.

## File Structure

Definitions of the messages that are sent between the server and the client, those implementations need to be shared between both of the parties. 
This allows Newtonsoft (JSON library) to serialize a message, send it and then, on the other side, deserialize it back.

- **MessageBase.cs**: Abstract class that defines the common variables and functions of all message type.
- **MessageBaseConverter.cs**: A Newtonsoft converter that allows to deserialize any message to its concrete message class.
- **SetupMessage.cs**: Message sent to newly connected users with data relating to the state of the game.

The Chat folder contains all the messages that will be displayed in the chat:
 - **EventMessage.cs**: Relating to a connection or disconnection of a certain user. (Server->Client)
 - **ImageMessage.cs**: An image sent as message in Base64. (All->All)
 - **TextMessage.cs**: Basic text message. (All->All)
 - **VideoMessage.cs**: A video sent as a URI. (Server->Client)

The Game folder contains all the messages relating to the development of the game:
 - **CoordinatesMessage.cs**: Current coordinates. (Client->Server)
 - **EnigmaMessage.cs**: Start of an enigma step. (Server->Client)
 - **FinishMessage.cs**: End of game. (Server->Client)
 - **MoveMessage.cs**: Start of a move step. (Server->Client)

The TriggerKey folder contains the messages relating to trigger keys:
 - **TriggerKeyMessage.cs**: Used to test a Trigger Key with ``Type=TriggerKeyMessageType.Query`` (Client->Server) and to answer a query with ``Type=TriggerKeyMessageType.Success`` or ``Type=TriggerKeyMessageType.Failure`` (Server->Client).  
