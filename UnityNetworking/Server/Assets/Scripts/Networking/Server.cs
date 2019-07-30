using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server: MonoBehaviour {

    private List<NetPlayer> players = new List<NetPlayer>();//NetPlayer.unprocessedInputBuffer NetPlayer.processedInputBuffer

    private int snapshotHistorySize = 50;//the maximum size of tickSnapshotHistory buffer before the oldest snapshot is deleted

    internal Queue<TickSnapshot> tickSnapshotHistory = new Queue<TickSnapshot>();

    internal float TickRate { get; private set; } = 16 / 1000;//the time between command frames, 16 miliseconds (.016 seconds) while healthy

    internal long CurrentTick { get; private set; } = 0;

    private void Tick() {//Server tick loop

        List<NetPacket> outdatedPackets = new List<NetPacket>();

        foreach (NetPlayer player in players) {
            foreach (NetPacket packet in player.unprocessedInputBuffer) {
                if (packet.Tick < CurrentTick) {
                    outdatedPackets.Add(packet);
                }
            }
        }

        if (outdatedPackets.Count > 0) {
            Reconcile(SortOutdatedPackets(outdatedPackets));
        }
        else {
            AdvanceGameState();
        }

        CurrentTick++;
        Invoke(nameof(Tick), TickRate);
    }

    private void Reconcile(List<NetPacket> outdatedPackets) {//expects a list of outdated packets in order from oldest to newest

    }

    private void AdvanceGameState() {
        TickSnapshot newSnapshot = new TickSnapshot();
        RecordTickSnapshot(newSnapshot);
    }

    private void RecordTickSnapshot(TickSnapshot snapshot) {
        tickSnapshotHistory.Enqueue(snapshot);
        if (tickSnapshotHistory.Count > snapshotHistorySize) {
            tickSnapshotHistory.Dequeue();//lost forever
        }
    }

    private List<NetPacket> SortOutdatedPackets(List<NetPacket> packets) {//sort list of packets from oldest to newest
        foreach (NetPacket packet in packets) {
            packet
        }
    }
}
