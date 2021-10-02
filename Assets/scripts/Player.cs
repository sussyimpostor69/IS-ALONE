
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public Transform point;
	public int maxHealth = 100;
	public int currentHealth;
	
	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}



	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
	void Heal()
    {
		healthBar.SetHealth(maxHealth);
    }
	

	public void Restart1()
	{




			if (dead == false)
			{
				dead = true;
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				Debug.Log("game over");
				Invoke("Heal", healdelay);
				dead = false;
				
			}
		
	}
	void Update()
	{

		if (currentHealth == 0)
		{

			Invoke("Restart1", restartdelay);
		}
		
		if (Input.GetKeyDown(KeyCode.K))
		{
			TakeDamage(20);
		}
	}

	public bool dead = false;
	public float restartdelay = 1f;
	public float healdelay = 1f;
}

    