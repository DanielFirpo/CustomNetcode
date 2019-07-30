
using System.Collections.Generic;

public class NetPlayer : NetEntity {
    internal List<NetPacket> processedInputBuffer = new List<NetPacket>();
    internal List<NetPacket> unprocessedInputBuffer = new List<NetPacket>();
}
