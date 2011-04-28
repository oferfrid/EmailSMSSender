/*
 * Created by SharpDevelop.
 * User: oferfrid
 * Date: 25/06/2009
 * Time: 09:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("sending email...");
			EmailSMSSender.Sender.SendEmail("oferfrid@gmail.com","test","old param test \n" + DateTime.Now.ToString());
			
			// TODO: Implement Functionality Here
			
			Console.Write("Email send \nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
