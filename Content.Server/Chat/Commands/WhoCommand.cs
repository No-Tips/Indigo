using System.Text;
using Robust.Shared.Console;
using Robust.Server.Player;
using Robust.Shared.Enums;
using Content.Shared.Administration;

namespace Content.Server.Chat.Commands
{

    [AnyCommand]
    internal sealed class WhoCommand : IConsoleCommand
    {
        public string Command => "who";
        public string Description => "Lists all connected players.";
        public string Help => "Usage: who";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            var playerManager = IoCManager.Resolve<IPlayerManager>();
            var sb = new StringBuilder();

            sb.AppendLine("Connected players:");

            foreach (var player in playerManager.Sessions)
            {
                string status;
                if (player.Status == SessionStatus.InGame)
                {
                    status = "Playing";
                }
                else if (player.Status == SessionStatus.Connected)
                {
                    status = "In Lobby";
                }
                else
                {
                    status = player.Status.ToString();
                }

                sb.AppendLine($"- {player.Name} - {status}");
            }

            shell.WriteLine(sb.ToString());
        }
    }
}
