using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Reversi.Shared;
using MagicOnion;
using MagicOnion.Server;
using MagicOnion.Server.Hubs;
using UnityEngine;

namespace Server
{
    public class RealTimeTest : StreamingHubBase<IRealTimeTest, IRealTimeTestReserver>, IRealTimeTest
    {
        IGroup room;
        Player self;
        IInMemoryStorage<Player> storage;

        public async ValueTask<Player[]> JoinAsync(string roomName, string userName)
        {
            self = new Player() { Name = userName};

            Console.WriteLine(userName + ":Join");

            // Group can bundle many connections and it has inmemory-storage so add any type per group.
            (room, storage) = await Group.AddAsync(roomName, self);

            // Typed Server->Client broadcast.
            Broadcast(room).OnJoin(self);

            return storage.AllValues.ToArray();
        }
        public async ValueTask LeaveAsync()
        {
            Console.WriteLine("Leave");

            await room.RemoveAsync(this.Context);
            Broadcast(room).OnLeave(self);
        }

        public async ValueTask AppearPlayersAsync()
        {
            Console.WriteLine("Success");
            //return storage.AllValues.ToArray();
        }

        public async ValueTask MoveAsync(Vector3 position)
        {
            self.Position = position;
            Broadcast(room).OnMove(self);
        }

        public async ValueTask Empty()
        {

        }

        protected override ValueTask OnDisconnected()
        {
            // on disconnecting, if automatically removed this connection from group.
            return ValueTask.CompletedTask;
        }
    }
}
