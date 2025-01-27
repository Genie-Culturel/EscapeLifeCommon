# EscapeLifeMessages

## Author

- Dan Simonin

## How to Use

### Common usage file structure

```md
Parent
├── Models
│   ├── Messages (EscapeLifeMessages)
│   │   ├── Chat
│   │   │   ├── ...
│   │   │   └── ...
│   │   ├── Game
│   │   │   ├── ...
│   │   │   └── ...
│   │   ├── TriggerKey
│   │   │   ├── ...
│   │   │   └── ...
│   │   ├── MessageBase.cs
│   │   ├── MessageBaseConverter.cs
│   │   └── SetupMessage.cs
│   └── Processors
│       ├── ChatProcessors.cs
│       ├── GameProcessors.cs
│       ├── TriggerKeyProcessors.cs
│       ├── MessageBase.cs
│       └── SetupMessage.cs
.
```

### Global

The classes are defined as partial since some specific logic needs to be added on both the server and the client.
Makes sure to define the ``Process()`` method of each class in the ``Processors`` folder under the same namespace as the other file.

Example for ``ChatProcessors.cs``:

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

    public partial class TextMessage
    {
        public override void Process() => throw new NotImplementedException();
    }

    public partial class VideoMessage
    {
        public override void Process() => throw new NotImplementedException();
    }
}
```

### Server

### Client