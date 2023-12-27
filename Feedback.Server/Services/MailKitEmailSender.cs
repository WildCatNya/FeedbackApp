using Feedback.Server.Services.Abstractions;
using MailKit.Net.Smtp;
using MimeKit;

namespace Feedback.Server.Services;

public sealed class MailKitEmailSender : IMailKitEmailSender
{
    private readonly SmtpClient _client;
    private readonly IConfiguration _configuration;

    public MailKitEmailSender(SmtpClient client, IConfiguration configuration)
    {
        _client = client;
        _configuration = configuration;
    }

    public void Send(MimeMessage message)
    {
        if (!_client.IsConnected)
            _client.Connect(_configuration["SMTP:Address"], 465, MailKit.Security.SecureSocketOptions.SslOnConnect);

        if (!_client.IsAuthenticated)
            _client.Authenticate(_configuration["SMTP:Login"], _configuration["SMTP:Password"]);

        _client.Send(message);

        _client.Disconnect(true);
    }
}