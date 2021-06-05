using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PengaNamn : MonoBehaviour
{

	public static string FormateraMedEnhet(float inSiffra)
	{
		var enhet = GetEnhet(inSiffra);
		float tal = inSiffra / enhet.tal;
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

		//if (inSiffra < 1000)
		//	formateratVarde = tal.ToString("### ##0 ");
		//else
		//	if (tal < 1000)
		//	formateratVarde = tal.ToString("### ##0.000 ");
		//else
		//	formateratVarde = tal.ToString("###.##0 ");
		var formateradMedEnhet = formateratVarde + enhet.Text;
		return formateradMedEnhet;
	}

	private static Enhet GetEnhet(float pengar)
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
		public float tal;
		public string Text;
	}

	static List<Enhet> Enheter = new List<Enhet>();

	static PengaNamn()
	{
		AddEnhet(0, "");
		//AddEnhet(3, "Thousands");
		AddEnhet(6, "Millions");
		AddEnhet(9, "Billions");
		AddEnhet(12, "Trillions");
		AddEnhet(15, "Quadrillions");
		AddEnhet(18, "Quintillions");
		AddEnhet(21, "Sextillions");
		AddEnhet(24, "Septillions");
		AddEnhet(27, "Octillions");
		AddEnhet(30, "Nonillions");
		AddEnhet(33, "Decillions");
		AddEnhet(36, "Undecillions");
		AddEnhet(39, "Duodecillions");
		AddEnhet(42, "Tredecillions");
		AddEnhet(45, "Quattuordecillions");
		AddEnhet(48, "Quindecillions");
		AddEnhet(51, "Sedecillions");
		AddEnhet(54, "Septendecillions");
		AddEnhet(57, "Octodecillions");
		AddEnhet(60, "Novendecillions");
		AddEnhet(63, "Vigintillions");
		AddEnhet(66, "Unvigintillions");
		AddEnhet(69, "Duovigintillions");
		AddEnhet(72, "Trevigintillions");
		AddEnhet(75, "Quattuorvigintillions");
		AddEnhet(78, "Quinvigintillions");
		AddEnhet(81, "Sexvigintillions");
		AddEnhet(84, "Septenvigintillions");
		AddEnhet(87, "Octovigintillions");
		AddEnhet(90, "Novemvigintillions");
		AddEnhet(93, "Trigintillions");
		AddEnhet(96, "Untrigintillions");
		AddEnhet(99, "Duotrigintillions");
		AddEnhet(102, "Tretrigintillions");
		AddEnhet(105, "Quattuortrigintillions");
		AddEnhet(108, "Quintrigintillions");
		AddEnhet(111, "Sextrigintillions");
		AddEnhet(114, "Septentrigintillions");
		AddEnhet(117, "Octotrigintillions");
		AddEnhet(120, "Novemtrigintillions");
		AddEnhet(123, "Quadragintillions");
		AddEnhet(126, "Unquadragintillions");
		AddEnhet(129, "Duoquadragintillions");

		//for (int i = Enheter.Count - 1; i >= 0; i--)
		//{
		//	Debug.Log("Tal: " + Enheter[i].tal);
		//	Debug.Log("Text: " + Enheter[i].Text);
		//}
	}

	private static void AddEnhet(int nollor, string enhet)
	{
		Enheter.Add(new Enhet
		{
			tal = Mathf.Pow(10, nollor),
			Text = enhet
		});
	}
}
