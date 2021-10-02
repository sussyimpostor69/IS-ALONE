
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public GameObject Manager;
	public GameObject firstperson;
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
				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				Debug.Log("game over");
				//Invoke("Heal", healdelay);
				Invoke("yes", dead);
				
	}
	void Update()
	{

		if (currentHealth == 0)
		{

			Invoke("Restart1", dead);
		}
		
		if (Input.GetKeyDown(KeyCode.K))
		{
			TakeDamage(20);
		}
	}
	public void yes()
    {
		deathshit.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
		firstperson.SetActive(false);
		Manager.SetActive(false);
	}

	public GameObject deathshit;
	private float restartdelay = 4f;
	private float healdelay = 1f;
	private float dead = 1f;
}

    