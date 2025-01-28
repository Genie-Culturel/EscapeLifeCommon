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

Clone this repository under `/Assets/Scripts/` on commit `3c2db94`:

```bash
cd /Assets/Scripts/
git clone https://github.com/MikleRe/EscapeLife.git
git checkout 3c2db94
```

Remember that `/Assets/Scripts/EscapeLife` is ignored in Plastic.