using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace VentasDia.Utilidades
{
	public class Ticket
	{
		public static string SEPARATOR = "------------------------------------------";

		public static string DOUBLE_SEPARATOR = "==========================================";

		public static string LOWER_SEPARATOR = "__________________________________________";

		public static string NEXT_LINE = "\n";

		public static string DOUBLE_LINE = "\n\n";

		public static string CUT_PAPPER = "\u001bm";

		public static string FORMAT_NORMAL = "\u001b!\u0002";

		public static string FORMAT_SMALL = "\u001b!\u0001";

		public static string FORMAT_BOLD = "\u001b!\b";

		public static string FORMAT_SMALL_BOLD = "\u001b!\t";

		public static string FORMAT_LARGE = "\u001b!\u0016";

		public static string FORMAT_LARGE_BOLD = "\u001b!\u0018";

		public static string FORMAT_LARGE_SMALL_BOLD = "\u001b!\u001f";

		public static string FORMAT_SPACED = "\u001b! ";

		public static string FORMAT_SPACED_SMALL = "\u001b!!";

		public static string FORMAT_SPACED_BOLD = "\u001b!(";

		public static string FORMAT_SPACED_SMALL_BOLD = "\u001b!)";

		public static string FORMAT_BIG = "\u001b!0";

		public static string FORMAT_SMALL_BIG = "\u001b!1";

		public static string FORMAT_BIG_BOLD = "\u001b!;";

		public static string FORMAT_SMALL_BIG_BOLD = "\u001b!9";

		private string comPort;

		private List<string> text;

		public Ticket(string comport)
		{
			if (comport != null)
			{
				this.comPort = comport;
			}
			else
			{
				this.comPort = "COM1";
			}
			this.text = new List<string>();
		}

		public void addLine(string text)
		{
			this.text.Add(text + Ticket.NEXT_LINE);
		}

		public void addSeparator()
		{
			this.text.Add(Ticket.SEPARATOR + Ticket.NEXT_LINE);
		}

		public void addDoubleSeparator()
		{
			this.text.Add(Ticket.DOUBLE_SEPARATOR + Ticket.NEXT_LINE);
		}

		public void addLowerSeparator()
		{
			this.text.Add(Ticket.LOWER_SEPARATOR + Ticket.NEXT_LINE);
		}

		public void addCutPapper()
		{
			this.text.Add(Ticket.DOUBLE_LINE);
			this.text.Add(Ticket.DOUBLE_LINE);
			this.text.Add(Ticket.CUT_PAPPER);
		}

		public void addLineFormat(string format, string text)
		{
			this.text.Add(format);
			this.text.Add(text);
			this.text.Add(Ticket.FORMAT_NORMAL);
			this.text.Add(Ticket.NEXT_LINE);
		}

		public void adddraweropening()
		{
			this.text.Add("\u001bp\0\u000f\u0096");
		}

		public void addFormat(string format)
		{
			this.text.Add(format);
		}

		public void print()
		{
			SerialPort serialPort = new SerialPort(this.comPort, 9600, Parity.None, 8, StopBits.One);
			if (serialPort.IsOpen)
			{
				serialPort.Close();
			}
			serialPort.Open();
			foreach (string current in this.text)
			{
				serialPort.Write(current);
			}
			serialPort.Close();
		}
	}
}