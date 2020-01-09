# pocket-tank-client

Clone of Pocket Tank game developed as a solo project as a part of learning multiplayer game development.

The game is having 4 scenes
* Loading secene (connection with the server is established and autherises the client with server)
* Lobby scene (Entered only after the client is autherised by the server)
* Matchmaking scene
* Gameplay scene

## Tools Used
* [Socket.io](https://github.com/floatinghotpot/socket.io-unity) is used for communicating with the server.

## Design Patterns
* MVC - All the inipendent components are implemented using MVC architecture.
* State Machine -  scenes and its transitions are done using state machine pattern.
* Singleton - All the manager and service classes follows singleton architecture.
