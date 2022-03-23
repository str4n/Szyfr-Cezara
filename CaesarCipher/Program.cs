using System;
using System.Text.RegularExpressions;

namespace SzyfrCezara
{
	class Program
	{
		static void Main(string[] args)
		{
			var regex = new Regex("^[a-zA-Z ]*$");

			Console.WriteLine("Podaj tekst: ");

			string text;

			while (true)
			{
				text = Console.ReadLine();

				if (String.IsNullOrWhiteSpace(text))
				{
					ColorMessage(ConsoleColor.DarkRed, "Podaj tekst!");
				}

				else if (!regex.IsMatch(text))
				{
					ColorMessage(ConsoleColor.DarkRed, "Tekst musi się składać z samych liter alfabetu łacińskiego!");
				}

				else
				{
					break;
				}
			}


			Console.WriteLine("Podaj przesunięcie: ");

			int shift;

			while (!int.TryParse(Console.ReadLine(), out shift))
			{
				ColorMessage(ConsoleColor.DarkRed, "Podaj liczbę!");
			}

			ColorMessage(ConsoleColor.DarkGreen, $"Zaszyfrowany tekst: {Regex.Replace(CaesarCipher(text, shift), @"\s+", " ")}");
		}

		static string CaesarCipher(string text, int shift)
		{
			char[] c = text.ToLower().ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				if (!char.IsWhiteSpace(c[i]))
				{
					c[i] = (char)(c[i] + shift);
				}

				if (c[i] > 'z' && !char.IsWhiteSpace(c[i]))
				{
					c[i] = (char)(c[i] - 26);
				}

				else if (c[i] < 'a' && !char.IsWhiteSpace(c[i]))
				{
					c[i] = (char)(c[i] + 26);
				}
			}
			return new string(c);
		}


		static void ColorMessage(ConsoleColor color, string message)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}