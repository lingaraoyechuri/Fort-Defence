using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyWaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

	//public Wave[] waves;

	public Transform spawnPoint;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	public Transform spawnPoint4;
	public Transform enemy;
	public Transform Tank;

	public float timeBetweenWaves = 100f;
	private float countdown = 2f;
	public int WaveNumber = 0;
	public int spawncheck = 1;
	public bool startwave = false;
	Scene m_Scene;
	public int wavenum;
	public Text waveText;

	//public Text waveCountdownText;

	//public GameManager gameManager;

	private int waveIndex = 30;

	void Update ()
	{

		m_Scene = SceneManager.GetActiveScene();

		Debug.Log("m_Scene name	" + m_Scene.name);

		if (EnemiesAlive > 0)
		{
			return;
		}

		// if (waveIndex == waves.Length)
		// {
		// 	//gameManager.WinLevel();
		// 	this.enabled = false;
		// }
		if (m_Scene.name == "level1")
		{
			wavenum = 4;
		}
		else if (m_Scene.name == "level2")
		{
			wavenum = 5;
			Debug.Log("level2 check");

		}
		else if (m_Scene.name == "level3")
		{
			wavenum = 6;
		}



		if (countdown <= 0f & startwave == true & WaveNumber < wavenum)
		{
			int WaveNum = WaveNumber+1;
			if (m_Scene.name == "level1")
			{
				waveText.text = "Wave " + WaveNum + "/4";
			}
			else if (m_Scene.name == "level2")
			{
				waveText.text = "Wave " + WaveNum + "/5";
			}
			else if (m_Scene.name == "level3")
			{
				waveText.text = "Wave " + WaveNum + "/6";
			}

			WaveNumber++;
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}


		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		//waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		//PlayerStats.Rounds++;

		//Wave wave = waves[waveIndex];

		//EnemiesAlive = wave.count;

		for (int i = 0; i < waveIndex; i++)
		{
			
			if (m_Scene.name == "level1")
			{
				SpawnEnemy();
			}
			else if (m_Scene.name == "level2")
			{
				SpawnEnemyL2();
			}
			else if (m_Scene.name == "level3")
			{
				SpawnEnemyL3();
			}

			yield return new WaitForSeconds(0.5f);
		}

		waveIndex = waveIndex+10;
		
		if (m_Scene.name == "level1")
        {
			waveIndex = waveIndex + 10;
			//waveText.text = "Wave " + WaveNumber + "/4";
		}
		else if(m_Scene.name == "level2")
		{
			waveIndex = waveIndex + 15;
			Debug.Log("level2 check wave index");
			//waveText.text = "Wave " + WaveNumber + "/5";
		}
		else if (m_Scene.name == "level3")
        {
			waveIndex = waveIndex + 20;
			//waveText.text = "Wave " + WaveNumber + "/6";
		}

	}

	void SpawnEnemy ()
	{
		if(WaveNumber == 1){
			Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		}
		else if(WaveNumber == 2){
			Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
		}else{
			
			int num = spawncheck%2;
			Debug.Log("spawncheck"+spawncheck);
			Debug.Log("spawncheck%2"+num);
			if(spawncheck%2 == 0){
				Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
				spawncheck++;
			}
			else if(spawncheck%21 == 0)
			{
				Instantiate(Tank, spawnPoint2.position, spawnPoint2.rotation);
				Instantiate(Tank, spawnPoint.position, spawnPoint.rotation);
				spawncheck++;
			}
			else{
				Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
				spawncheck++;
			}
		}
		
	}

	void SpawnEnemyL2()
	{
		if (WaveNumber == 1)
		{
			Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		}
		else if (WaveNumber == 2)
		{
			Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
		}
		else if (WaveNumber == 3)
		{
			Instantiate(enemy, spawnPoint3.position, spawnPoint3.rotation);
		}
		else
		{

			int num = spawncheck % 2;
			Debug.Log("spawncheck" + spawncheck);
			Debug.Log("spawncheck%2" + num);
			if (spawncheck % 2 == 0)
			{
				Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
				spawncheck++;
			}
			else if(spawncheck % 3 == 0)
			{
				Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
				if (spawncheck % 21 == 0)
                {
					Instantiate(Tank, spawnPoint2.position, spawnPoint2.rotation);
					Instantiate(Tank, spawnPoint.position, spawnPoint.rotation);
					Instantiate(Tank, spawnPoint3.position, spawnPoint3.rotation);
				}
					spawncheck++;

			}
			else if (spawncheck % 21 == 0)
			{
				Instantiate(Tank, spawnPoint2.position, spawnPoint2.rotation);
				Instantiate(Tank, spawnPoint.position, spawnPoint.rotation);
				Instantiate(Tank, spawnPoint2.position, spawnPoint3.rotation);
				spawncheck++;
			}
			else
            {
				Instantiate(enemy, spawnPoint3.position, spawnPoint3.rotation);
				spawncheck++;
			}

		}

	}

	void SpawnEnemyL3()
	{
		if (WaveNumber == 1)
		{
			Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
			Instantiate(enemy, spawnPoint3.position, spawnPoint.rotation);
		}
		else if (WaveNumber == 2)
		{
		
			Instantiate(enemy, spawnPoint4.position, spawnPoint2.rotation);
		}
		else
		{

			int num = spawncheck % 2;
			Debug.Log("spawncheck" + spawncheck);
			Debug.Log("spawncheck%2" + num);
			if (spawncheck % 2 == 0)
			{
				Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
				spawncheck++;
			}
			else if (spawncheck % 3 == 0)
			{
				Instantiate(enemy, spawnPoint2.position, spawnPoint2.rotation);
				if (spawncheck % 21 == 0)
				{
					Instantiate(Tank, spawnPoint2.position, spawnPoint2.rotation);
					Instantiate(Tank, spawnPoint.position, spawnPoint.rotation);
					Instantiate(Tank, spawnPoint3.position, spawnPoint3.rotation);
					
				}
				spawncheck++;

			}
			else
			{
			
				Instantiate(enemy, spawnPoint4.position, spawnPoint3.rotation);
				spawncheck++;
			}

		}

	}

	public void startWave(){

		startwave = true;

	}
}
