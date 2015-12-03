using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyHelper : MonoBehaviour
{
	// public int rate = 1;
	// public int level = 0;
	public GameObject[] prefabs;
	public string[] EnemyTypeList;
	public string[] eventList;
	public float distanceAwayFromPlayer;
	public float MapDistance = 50;
	public GameObject player;
	// Use this for initialization
	public bool ________;
	public int Level = 1;
	public int current = 0;
	public bool doneWithLast = true;

	void Start ()
	{
		//InvokeRepeating("Spawn", 5, 1);
		//remove all so i can count
		foreach (Transform child in this.transform) {
			Destroy (child.gameObject);
		}
	
		
	}

	#region Ring Stuff
	public bool _______________RingStuff;
	float currentRingState = 0;
	public float ringSpeed = 0.1f;
	public float ringDelay = 0.4f;
	int currentRingType = 0;
	public float ringRadiusbyPie = 40f;
	int RingCount = 0;

	void spawnRing ()
	{
		if (RingCount < 0) { // top when done with spawning
			CancelInvoke ("spawnRing");
			return;
		}
		RingCount -= 1;
		currentRingState += ringSpeed;
		Vector2 newSpot = new Vector3 (Mathf.Cos (currentRingState) * ringRadiusbyPie, Mathf.Sin (currentRingState) * ringRadiusbyPie, 0);

		
		GameObject temp = (GameObject)Instantiate (prefabs [currentRingType], newSpot, transform.rotation);
		temp.GetComponent<BaseEnemy> ().UpLevel (Level);
		temp.transform.parent = this.gameObject.transform;
	
	}
	#endregion
	#region Square Stuff
	public bool _______________SquareStuff;
	float currentSquareState = 0;
	public float SquareDelay = 0.4f;
	int currentSquareType = 0;
	public float SquareMag;
	public int Square_Rows;
	//public int Square_YPart;
	public Vector3 Squareoffset ;
	int SquareCountStart;
	int SquareCount;
	Vector3 currentSquarePos;

	IEnumerator DrawSquare ()
	{
	
		for (int x = 0; x < Square_Rows; x++) {

			print (SquareCountStart + " / " + Square_Rows + " = " + (SquareCountStart / Square_Rows));
			for (int y = 0; y < SquareCountStart / Square_Rows; y++) {
				currentSquarePos = new Vector3 (x * SquareMag, y * SquareMag, 0);
				Vector2 newSpot = currentSquarePos + Squareoffset;
				GameObject temp = (GameObject)Instantiate (prefabs [currentSquareType], newSpot, transform.rotation);
				temp.GetComponent<BaseEnemy> ().UpLevel (Level);
				temp.transform.parent = this.gameObject.transform;
				SquareCount -= 1;

				yield return  new WaitForSeconds (SquareDelay);

			}
		}
	}

	void spawnSquare ()
	{
		if (SquareCount < 0) { // top when done with spawning
			CancelInvoke ("spawnSquare");
			StopCoroutine ("DrawSquare");
			return;
		}
	
		DrawSquare ();
	}
	#endregion
	#region Star Stuff
	public bool _______________StarStuff;
	float currentStarState = 0;
	public float StarDelay;
	int currentStarType = 0;
	public float StarMag;
	public float StarboundsWidth;
	public float StarboundsHeight;
	public float StarboundsX;
	public float StarboundsY;
	public int Star_XPart;
	public int Star_YPart;
	//Vector3 Staroffset = new Vector3(-50,-50, 0);
	int StarCount;
	public int Star_num_points = 99;//must be odd?
	Vector3 currentStarPos;
	Vector3[] edges;

	IEnumerator DrawStar ()
	{
		edges = new  Vector3 [Star_num_points];
		float originalCount = StarCount;
		float rx = StarboundsWidth / 2;
		float ry = StarboundsHeight / 2;
		float cx = StarboundsX + rx;
		float cy = Star_YPart + ry;
		int segmentsInLine = 10;
		// Start at the top.
		float theta = -Mathf.PI / 2;
		float dtheta = 4 * Mathf.PI / Star_num_points;

		for (int i = 0; i < Star_num_points; i++) {
			edges [i] = new Vector3 ((cx + rx * Mathf.Cos (theta)),
			                        (cy + ry * Mathf.Sin (theta)), 0);
			theta += dtheta;

		}





		for (int line = 0; line < Star_num_points; line++) {

			//Draw the line
			if (line > 0) {//skip first
				for (int i = 0; i < segmentsInLine; i++) {
					{
						print (edges);
						Vector2 newSpot = Vector3.Lerp (edges [line - 1], edges [line], (float)i / 10f);
						GameObject temp = (GameObject)Instantiate (prefabs [currentStarType], newSpot, transform.rotation);
						temp.transform.parent = this.gameObject.transform;
						yield return  new WaitForSeconds (StarDelay);
					}
				}

				//first point
				Vector2 newSpotfirst = edges [line];
				
				GameObject temp2 = (GameObject)Instantiate (prefabs [currentStarType], newSpotfirst, transform.rotation);
				temp2.transform.parent = this.gameObject.transform;

			}
		
	

			//lerp her




			yield return  new WaitForSeconds (StarDelay);
		}
		for (int i = 0; i < segmentsInLine; i++) {
			{
				Vector2 newSpot = Vector3.Lerp (edges [Star_num_points - 1], edges [0], (float)i / 10f);//HArd coded point 0 and 1 for last
				GameObject temp = (GameObject)Instantiate (prefabs [currentStarType], newSpot, transform.rotation);
				temp.transform.parent = this.gameObject.transform;
				yield return  new WaitForSeconds (StarDelay);
			}
		}



	}
	
	void spawnStar ()
	{
		if (StarCount < 0) { // top when done with spawning

			CancelInvoke ("spawnStar");
			StopCoroutine ("DrawStar");
			return;
		}
		StarCount -= 1;
		DrawStar ();
	}
	#endregion
	#region QQQ Stuff
	public bool _______________QQQStuff;
	float currentQQQState = 0;
	public float QQQSpeed = 0.1f;
	public float QQQDelay = 0.4f;
	int currentQQQType = 0;
	public float QQQRadiusbyPie = 40f;
	int QQQCount = 0;

	void spawnQQQ ()
	{
		if (QQQCount < 0) { // top when done with spawning
			CancelInvoke ("spawnQQQ");
			return;
		}
		QQQCount -= 1;
		currentQQQState += QQQSpeed;
		Vector2 newSpot = new Vector3 (Mathf.Cos (currentQQQState) * QQQRadiusbyPie, Mathf.Sin (currentQQQState) * QQQRadiusbyPie, 0);
		
		
		GameObject temp = (GameObject)Instantiate (prefabs [currentQQQType], newSpot, transform.rotation);
		temp.GetComponent<BaseEnemy> ().UpLevel (Level);
		temp.transform.parent = this.gameObject.transform;
		print ("boop");
	}
	#endregion
	#region ZZZ Stuff
	public bool _______________ZZZStuff;
	float currentZZZState = 0;
	public float ZZZSpeed = 0.1f;
	public float ZZZDelay = 0.4f;
	int currentZZZType = 0;
	public float ZZZRadiusbyPie = 40f;
	int ZZZCount = 0;

	void spawnZZZ ()
	{
		if (ZZZCount < 0) { // top when done with spawning
			CancelInvoke ("spawnZZZ");
			return;
		}
		ZZZCount -= 1;
		currentZZZState += ZZZSpeed;
		Vector2 newSpot = new Vector3 (Mathf.Cos (currentZZZState) * ZZZRadiusbyPie, Mathf.Sin (currentZZZState) * ZZZRadiusbyPie, 0);
		
		
		GameObject temp = (GameObject)Instantiate (prefabs [currentZZZType], newSpot, transform.rotation);
		temp.GetComponent<BaseEnemy> ().UpLevel (Level);
		temp.transform.parent = this.gameObject.transform;
		print ("boop");
	}
	#endregion




	// Update is called once per frame
	void Update ()
	{

		if (doneWithLast) {
			string option = "";
		
			doneWithLast = false;
			string currentString = string.Copy (eventList [current]);
			if (currentString.Contains ("Ring")) {
				option = "Ring";
				currentString = currentString.Replace ("Ring", "");
			} else if (currentString.Contains ("Square")) {

				option = "Square";
				currentString = currentString.Replace ("Square", "");
			} else if (currentString.Contains ("Star")) {
				option = "Star";
				currentString = currentString.Replace ("Star", "");
			} else if (currentString.Contains ("QQQ")) {
				option = "QQQ";
				currentString = currentString.Replace ("QQQ", "");
			} else if (currentString.Contains ("ZZZ")) {
				option = "ZZZ";
				currentString = currentString.Replace ("ZZZ", "");
			}
			if (currentString.Contains ("Spawn")) {
				currentString = currentString.Replace ("Spawn", "");
		

				if (currentString.Contains ("Random")) {

					currentString = currentString.Replace ("Random", "");
					int count = int.Parse (currentString);
					Spawn (count, 0, EnemyTypeList.Length, option);
					//int count =  int.Parse( eventList[current]);
				} else if (currentString.Contains ("Enemy")) {
					for (int i = 0; i <  EnemyTypeList.Length; i++) {
					

						if (currentString.Contains (EnemyTypeList [i])) {

						
							currentString = currentString.Replace (EnemyTypeList [i], "");
							int count = int.Parse (currentString);
							Spawn (count, i, i, option);
						}
					}
					//int count =  int.Parse( eventList[current]);
				}
	

			}//end of "spawn"
			else if (currentString.Contains ("UpLevel")) {
				currentString = currentString.Replace ("UpLevel", "");
				Level += 1;
			} else if (currentString.Contains ("GoTo")) {
				currentString = currentString.Replace ("GoTo", "");
				current = int.Parse (currentString) - 1;
		
				
			} else {
				
				print ("Error!!! you didnt type something correctllly");
			}



		} else {
			if (transform.childCount < 1 && !IsInvoking ("spawnRing")
				&& !IsInvoking ("spawnSquare") && !IsInvoking ("spawnStar") && !IsInvoking ("spawnQQQ")
				&& !IsInvoking ("spawnZZZ")) {
				doneWithLast = true;
				current ++;
		



			}


		}
		//if ((int)Random.Range (0, 100) == 1) {
		//		GameObject tempObject =	GameObject.Instantiate(prefabs[(int)Random.Range(0,4)]);
		//		tempObject.GetComponent<BaseEnemy>().gameObject.transform.position  = new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0);
		//}
	
	}

	//public int TypeToIndex


	//new Rect(new Vector2(-50, -50, 100,100)).Contains(newSpot))

	void Spawn (int rate, int startType, int endtype, string option)
	{
		if (option == "Ring") {
			//print ("Ring!!");
			currentRingState = 0f;
			currentRingType = startType;
			RingCount = rate;
			InvokeRepeating ("spawnRing", 1, ringDelay);

		} else if (option == "Square") {

			currentSquareState = 0f;
			currentSquareType = startType;
			SquareCount = rate;
			SquareCountStart = rate;
			print (rate);
			StartCoroutine ("DrawSquare");
			InvokeRepeating ("spawnSquare", 1, SquareDelay);
			
		} else if (option == "Star") {
		
			currentStarState = 0f;
			currentStarType = startType;
			StarCount = rate;
			StartCoroutine ("DrawStar");
			InvokeRepeating ("spawnStar", 1, StarDelay);
		} else if (option == "QQQ") {
			print ("QQQ!!");
			currentQQQState = 0f;
			currentQQQType = startType;
			QQQCount = rate;
			InvokeRepeating ("spawnQQQ", 1, QQQDelay);
			
		} else if (option == "ZZZ") {
			print ("ZZZ!!");
			currentZZZState = 0f;
			currentZZZType = startType;
			ZZZCount = rate;
			InvokeRepeating ("spawnZZZ", 1, ZZZDelay);
			
		} else {
		
			for (int i = 0; i < rate; i++) {
				Vector3 newSpot;
				//print (startType+"    " +endtype+0);

				newSpot = new Vector3 (Random.Range (-MapDistance, MapDistance), Random.Range (-MapDistance, MapDistance), 0);

				while ((Vector3.Distance(newSpot, FollowCam.S.poi.transform.position) < distanceAwayFromPlayer)) {
					newSpot = new Vector3 (Random.Range (-MapDistance, MapDistance), Random.Range (-MapDistance, MapDistance), 0);
				}


				//print ("part2" + startType+"    " +endtype+0);

				GameObject temp = (GameObject)Instantiate (prefabs [Random.Range (startType, endtype + 0)], newSpot, transform.rotation);
				//print (i+" Created a "+temp.name);
				temp.GetComponent<BaseEnemy> ().UpLevel (Level);
				temp.transform.parent = this.gameObject.transform;
			}
		}
		// level++;

		/* if (level % 30 == 0)
        {
            rate++;
            print("rate: " + rate);
        }*/
	}
}
