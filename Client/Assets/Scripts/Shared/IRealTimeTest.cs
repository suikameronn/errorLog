using MagicOnion;
using MessagePack;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Reversi.Shared
{
    public interface IRealTimeTestReserver
    {
        void OnJoin(Player player);
        void OnLeave(Player player);
        void OnMove(Player player);
        void OnAppear(Player[] players);
    }

    public interface IRealTimeTest : IStreamingHub<IRealTimeTest,IRealTimeTestReserver>
    {
        ValueTask<Player[]> JoinAsync(string roomName, string username);
        ValueTask LeaveAsync();
        ValueTask MoveAsync(Vector3 position);
        ValueTask AppearPlayersAsync();
        ValueTask Empty();
    }


    [MessagePackObject]
    public class Player
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public Vector3 Position { get; set; }
    }
}
