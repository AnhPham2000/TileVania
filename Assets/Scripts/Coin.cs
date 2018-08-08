using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	[SerializeField] AudioClip coinPickup;

	private int CoinWorth = 1;

	void OnTriggerEnter2D()
	{
		GameSession.Instance.AddToScore(CoinWorth);
		AudioSource.PlayClipAtPoint(coinPickup, Camera.main.transform.position);
		Destroy(gameObject);
	}

}
