using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class PengaNamn
{
   public static string FormateraMedEnhet(double inSiffra, bool useDecimals = false)
	{
      if (inSiffra < 100 && useDecimals)
      {
         return Math.Round(inSiffra, 2).ToString("#0.00").Replace(",",".");
      }

		var enhet = GetEnhet(inSiffra);
      double tal = inSiffra / enhet.tal;
		var formateratVarde = "";


		if(inSiffra > 1000000) 
         formateratVarde = tal.ToString("#,###.000");
		else
         formateratVarde = tal.ToString("### ###");

      formateratVarde = formateratVarde.Replace(",", ".").Replace(" ", ",");

      if (formateratVarde.Substring(0, 1) == ",")
      {
         formateratVarde = formateratVarde.Remove(0, 1);
      }

      if (formateratVarde == "" || formateratVarde == " ")
         formateratVarde = "0";

      var formateradMedEnhet = formateratVarde + " " + enhet.Text;
		return formateradMedEnhet;
	}

	private static Enhet GetEnhet(double pengar)
	{
		for (int i = Enheter.Count - 1; i >= 0; i--)
		{
			var enhet = Enheter[i];

			if (pengar >= enhet.tal)
			{
				return enhet;
			}
		}

		return Enheter[0];
	}


	class Enhet
	{
		public double tal;
		public string Text;
	}

	static List<Enhet> Enheter = new List<Enhet>();

	static PengaNamn()
	{
		AddEnhet(0, "");
		//AddEnhet(3, "Thousand");
		AddEnhet(6, "Million");
		AddEnhet(9, "Billion");
		AddEnhet(12, "Trillion");
		AddEnhet(15, "Quadrillion");
		AddEnhet(18, "Quintillion");
		AddEnhet(21, "Sextillion");
		AddEnhet(24, "Septillion");
		AddEnhet(27, "Octillion");
		AddEnhet(30, "Nonillion");
		AddEnhet(33, "Decillion");
		AddEnhet(36, "Undecillion");
		AddEnhet(39, "Duodecillion");
		AddEnhet(42, "Tredecillion");
		AddEnhet(45, "Quattuordecillion");
		AddEnhet(48, "Quindecillion");
		AddEnhet(51, "Sedecillion");
		AddEnhet(54, "Septendecillion");
		AddEnhet(57, "Octodecillion");
		AddEnhet(60, "Novendecillion");
		AddEnhet(63, "Vigintillion");
		AddEnhet(66, "Unvigintillion");
		AddEnhet(69, "Duovigintillion");
		AddEnhet(72, "Trevigintillion");
		AddEnhet(75, "Quattuorvigintillion");
		AddEnhet(78, "Quinvigintillion");
		AddEnhet(81, "Sexvigintillion");
		AddEnhet(84, "Septenvigintillion");
		AddEnhet(87, "Octovigintillion");
		AddEnhet(90, "Novemvigintillion");
		AddEnhet(93, "Trigintillion");
		AddEnhet(96, "Untrigintillion");
		AddEnhet(99, "Duotrigintillion");
		AddEnhet(102, "Tretrigintillion");
		AddEnhet(105, "Quattuortrigintillion");
		AddEnhet(108, "Quintrigintillion");
		AddEnhet(111, "Sextrigintillion");
		AddEnhet(114, "Septentrigintillion");
		AddEnhet(117, "Octotrigintillion");
		AddEnhet(120, "Novemtrigintillion");
		AddEnhet(123, "Quadragintillion");
		AddEnhet(126, "Unquadragintillion");
		AddEnhet(129, "Duoquadragintillion");

	}

	private static void AddEnhet(int nollor, string enhet)
	{
		Enheter.Add(new Enhet
		{
			tal = Math.Pow(10, nollor),
			Text = enhet
		});
	}
}
