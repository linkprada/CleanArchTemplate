﻿// <copyright file="SmtpEmailSender.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using CleanArchTemplate.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace CleanArchTemplate.Infrastructure;

public class SmtpEmailSender : IEmailSender
{
    private readonly ILogger<SmtpEmailSender> _logger;

    public SmtpEmailSender(ILogger<SmtpEmailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(string to, string from, string subject, string body)
    {
        var emailClient = new SmtpClient("localhost");
        var message = new MailMessage
        {

            From = new MailAddress(from),
            Subject = subject,
            Body = body


        };
        message.To.Add(new MailAddress(to));
        await emailClient.SendMailAsync(message);
        _logger.LogWarning("Sending email to {to} from {from} with subject {subject}.", to, from, subject);
    }
}