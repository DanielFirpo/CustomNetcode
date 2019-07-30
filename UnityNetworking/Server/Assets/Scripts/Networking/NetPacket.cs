public class NetPacket {
    internal long Tick { get; private set; }

    internal bool IsIrriversable = true;//It's very important for this to be false if the packet is a game-changing event (like killing a player) that should not be attempted to be reversed. The server will wait to apply this change until it has left the GameStateHistory ie. when it cannot be rewriten anymore.
}
