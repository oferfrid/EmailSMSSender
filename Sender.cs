/*
 * Created by SharpDevelop.
 * User: oferfrid
 * Date: 13/02/2009
 * Time: 14:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace EmailSMSSender
{
	/// <summary>
	/// Description of EmailSender.
	/// </summary>
	public static class Sender
	{
		
		
		private static void SendEmail(string FromGmailEmail,
		                              string GmailPassword ,
		                              string ToEmail,
		                              string Subject,
		                              string Body)
		{
			
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
			msg.To.Add(ToEmail);
			msg.Subject = Subject;
			msg.Body = Body;
			msg.IsBodyHtml = false;

			SmtpClient SMPclint = new SmtpClient();
			SMPclint.Host = "smtp.gmail.com";
			SMPclint.EnableSsl = true;
			NetworkCredential NetCry = new NetworkCredential();
			NetCry.UserName = FromGmailEmail;
			NetCry.Password = GmailPassword;
			SMPclint.UseDefaultCredentials = true;
			SMPclint.Credentials = NetCry;
			SMPclint.EnableSsl = true;
			// add the following two sentence.
			MailAddress fromMailAddr = new MailAddress(FromGmailEmail,"Automatic Email Sender");
			msg.From = fromMailAddr;
			SMPclint.Port = 587;
			SMPclint.Send(msg);
		}
		
		public static void SendEmail(string ToEmail,
		                             string Subject,
		                             string Body)
		{
			string FromGmailEmail = ConfigurationManager.AppSettings["GmailSenderUser"];
			string FromEmailPassword = ConfigurationManager.AppSettings["GmailSenderPassword"];
			SendEmail(FromGmailEmail,FromEmailPassword,ToEmail,Subject,Body);
		}
		
		public static void SendSMS(string ToPhone, string Body)
		{
			string ICQSenderUid = System.Configuration.ConfigurationManager.AppSettings["ICQSenderUid"];
			string ICQSenderPassword= System.Configuration.ConfigurationManager.AppSettings["ICQSenderPassword"];
			
			
			SMSManager SM =new SMSManager(ICQSenderUid,ICQSenderPassword);
			SM.SendSMSMessage(ToPhone,Body);
			
		}
		public static void SendICQ(string ToUid, string Body)
		{
			string ICQSenderUid = System.Configuration.ConfigurationManager.AppSettings["ICQSenderUid"];
			string ICQSenderPassword= System.Configuration.ConfigurationManager.AppSettings["ICQSenderPassword"];
			
			
			SMSManager SM =new SMSManager(ICQSenderUid,ICQSenderPassword);
			SM.SendICQMessage(	ToUid,Body);
			SM = null;
			
			
		}
	}
}
