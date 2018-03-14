using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour {

	string progress;
	public string nextLevel;
	bool complete = false;

	int progressIndex;
	int nextIndex;

	public int goalPages;
	public int pagesGot;

	public float goalTime;
	float currentTime;

	private int goalLives; //lives entered scene with

	private int gradeCase = 0;
	private string[] grades = new string[]{"C","B","A","S"};
	private string checkGrade;
	//C = no pages, you died, and didnt complete in time
	//B = 1/3
	//A = 2/3
	//S = 3/3 perfect!

	public GameObject levelComplete;
	public GameObject nextLevelButton;

	public GameObject pageIcon;
	public Text pages; 

	public GameObject timerIcon;
	public Text timed;

	public GameObject lifeIcon;
	public Text lives;

	public GameObject gradeIcon;
	public Text grade;

	private string currentGrade;
	public string currentLevel;

	public void Start()
	{
		//PlayerPrefs.SetInt ("lives", 5);
		goalLives = PlayerPrefs.GetInt("lives");//PlayerPrefs.GetInt ("lives");

		if(currentLevel == "2 - 1")
		{
			PlayerPrefs.SetInt ("hasCat", 1);
		}
		if(currentLevel == "3 - 1")
		{
			PlayerPrefs.SetInt ("hasCat", 1);
			PlayerPrefs.SetInt ("hasMonkey", 1);
		}
	}

	public void Update()
	{
		if (currentLevel.Equals ("2 - 1")) {
			PlayerPrefs.SetInt ("hasCat", 1);
		}
		if (currentLevel.Equals ("3 - 1")) {
			PlayerPrefs.SetInt ("hasCat", 1);
			PlayerPrefs.SetInt ("hasMonkey", 1);
		}
		currentTime += Time.deltaTime;
		//runs once
		//this is super placeholder and not fleshed out at all
		//it works perfectly just needs to actually look nice
		if(complete)
		{
			panel (true);
			//open overlay and display results
			//based on amount of pages collected run "collected page" animation
			if(goalPages == pagesGot)//decremented when collide with page
			{
				gradeCase++;
			}
			pages.text = pagesGot.ToString () + " / " + goalPages.ToString () + "  Collected";

			//based on time taken to complete display check or not
			if(currentTime <= goalTime)
			{
				gradeCase++;
			}


			timed.text = currentTime.ToString ("0.00") + " / " + goalTime.ToString ("0.00") + "  Seconds";

			//no lives lost since entering scene then increment grade
			if(goalLives == PlayerPrefs.GetInt("lives"))
			{
				gradeCase++;
			}
			lives.text = PlayerPrefs.GetInt("lives").ToString () + " / " + goalLives.ToString () + "  Lives";

			//display grade
			grade.text = "Grade: " + grades[gradeCase];



		}
		complete = false;

	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) 
		{
			pauseGame ();
		}
	}

	//called by on click of button in end stage overlay
	public void levelAccess()
	{
		//check if the current level has a grade, if yes then set, else no
		checkGrade = PlayerPrefs.GetString(currentLevel, "none");

		//so if you have progressed further and go backwards it doesnt reset progress
		//pipes tho

		//print (checkGrade);

		print (checkGrade);

		if(checkGrade.Equals("none"))
		{
			print ("worked");
			PlayerPrefs.SetString ("LevelAccess", nextLevel);
		}

		//set grade for this level in PlayerPrefs, will be displayed on level select
		//only sets if new grade is better than past grade
		currentGrade = PlayerPrefs.GetString(SceneManager.GetActiveScene().name);

		if (currentGrade == grades [gradeCase]) { //same value
			PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
		} else if (currentGrade != "S") {//set if anything other than S in past score

			if (currentGrade == "A") {
				if (grades [gradeCase] == "S") {
					PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
				}
			} else if (currentGrade == "B") {
				if (grades [gradeCase] == "S") {
					PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
				} else if (grades [gradeCase] == "A") {
					PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
				}
			} else if (currentGrade == "C") {
				if (grades [gradeCase] == "S") {
					PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
				} else if (grades [gradeCase] == "A") {
					PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
				} else if (grades [gradeCase] == "B") {
					PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
				}
			} else { //if nothing 
				PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, grades [gradeCase]);
			}
		}
		panel (false);



		Time.timeScale = 1;
		Destroy (GameObject.Find("Canvas"));
		SceneManager.LoadScene (nextLevel);
	}

	void pauseGame()
	{
		complete = true;
		Time.timeScale = 0;
		FindObjectOfType<AudioManager>().Pause("Sewer1");
	}

	void panel(bool active)
	{
		levelComplete.SetActive (active);
		pageIcon.SetActive (active);
		timerIcon.SetActive (active);
		nextLevelButton.SetActive (active);
		lifeIcon.SetActive (active);
		gradeIcon.SetActive (active);
	}

	void FinishLevel() {
		complete = true;
	}
}
