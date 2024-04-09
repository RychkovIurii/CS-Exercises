﻿using System;
using System.Collections.Generic;
namespace Tikkupelit
{
	public class BlackjackAivot
	{
		public int BlackjackCounter(List<PeliKortti> hand)
		{
			int returnCount = 0;
			int temporaryReturn = 0;
			bool aceDetected = false;
			foreach (PeliKortti card in hand)
			{
				if (card.KorttiNumero < 10 && card.KorttiNumero != 1)
				{
					returnCount += card.KorttiNumero;
				}
				else if (card.KorttiNumero == 1)
				{
					aceDetected = true;
					temporaryReturn += 1;
				}
				else
				{
					returnCount += 10;
				}
			}
			if (aceDetected == true && (temporaryReturn + returnCount) > 21)
			{
				foreach (PeliKortti card in hand)
				{
					if(card.KorttiNumero == 1)
					{
						temporaryReturn -= 10;
						if((temporaryReturn + returnCount) <= 21)
						{
							break;
						}
					}
				}
			}
			return temporaryReturn + returnCount;
		}
	}

	public class BlackjackVisualizer
	{
		BlackjackAivot rules = new BlackjackAivot();

        public void VisualizeBlackjack(List<KorttiPelaaja> players, bool playerPassed)
		{
			int playerAmount = 0;

			Console.Clear();
			foreach(KorttiPelaaja player in players)
			{
				int playerScore = rules.BlackjackCounter(player.korttiKasi);
				string playerName = "";
				switch(player.PelaajaTyyppi)
				{
					case KorttiPelaajatyyppi.pelaaja:
						playerName = "Player";
						break;
					// Muiden pelaajien case:t lisàtààn myòhemmin
                    case KorttiPelaajatyyppi.dealeri:
                        playerName = "Dealer";
						if (playerPassed == false)
						{
							Console.Write("Dealer's hand: ");
							for(int i=0; i<players.Count; i++)
							{
								if(i == 0)
								{
									player.korttiKasi[0].ShowCard();
								}
								else
								{
									Console.WriteLine("[ }");
								}
								Console.WriteLine();
							}
						}
                        break;
                }
				if (player.PelaajaTyyppi != KorttiPelaajatyyppi.dealeri || playerPassed == true)
				{
					Console.Write(playerName + "'s hand: ");
					player.NaytaKasi();
					Console.Write(playerName + " Score: " + playerScore);
					if (playerScore > 21)
					{
						Console.Write("Bust");
					}
					else if (playerScore == 21)
					{
						Console.Write("Blackjack");
					}
					Console.WriteLine();
				}
                Console.WriteLine("____________________");
            }
            Console.WriteLine();
        }
		public bool AnnounceBlackjackWinner(List<KorttiPelaaja> players)
		{

		}
	}
}

