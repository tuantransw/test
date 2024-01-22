using Discord;
using Discord.WebSocket;

namespace TestDiscord
{
    internal class Program
    {
        private DiscordSocketClient _client;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;

            // Token của Bot
            var token = "YOUR_BOT_TOKEN";

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Chặn chương trình kết thúc cho đến khi bot thoát
            await Task.Delay(-1);
        }
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private async Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            // Gửi tin nhắn vào kênh cụ thể
            var channelId = 123456789012345678; // ID của kênh Discord
            var channel = _client.GetChannel(channelId) as IMessageChannel;
            await channel.SendMessageAsync("Hello World!");
        }
    }
}
