using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class enemyHelper : MonoBehaviour {
   // public int rate = 1;
   // public int level = 0;
	public GameObject[] prefabs;
	public string [] EnemyTypeList;
	public string [] eventList;
	public float distanceAwayFromPlayer;
	public float MapDistance = 50;
	public GameObject player;
	// Use this for initialization
	public bool ________;
	public int Level =1;
	public int current = 0;
	public bool doneWithLast=true;

	void Start () {
        //InvokeRepeating("Spawn", 5, 1);
		//remove all so i can count
		foreach (Transform child in this.transform) {
			Destroy(child.gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (doneWithLast) {
			doneWithLast = false;
			string currentString = string.Copy (eventList [current]);
			if (currentString.Contains ("Spawn")) {
				currentString = currentString.Replace ("Spawn", "");
		

				if (currentString.Contains ("Random")) {

					currentString = currentString.Replace ("Random", "");
					int count = int.Parse (currentString);
					Spawn (1, 0, EnemyTypeList.Length);
					//int count =  int.Parse( eventList[current]);
				}
	
		
				else if (currentString.Contains ("Enemy")) {
					for (int i = 0; i <  EnemyTypeList.Length; i++) {
					

						if (currentString.Contains (EnemyTypeList [i])) {

						
							currentString = currentString.Replace (EnemyTypeList [i], "");
							int count = int.Parse (currentString);
							Spawn (count, i, i);
						}
					}
					//int count =  int.Parse( eventList[current]);
				}
	

			}//end of "spawn"
			else if (currentString.Contains ("UpLevel")) {
				currentString = currentString.Replace ("UpLevel", "");
				Level +=1;
			}
			else if (currentString.Contains ("GoTo")) {
				currentString = currentString.Replace ("GoTo", "");
				current = int.Parse (currentString) -1;
		
				
			}
			else 
			{
				
				print ("Error!!! you didnt type something correctllly" );
			}



		} else {
			if(transform.childCount <1)
			{
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

    void Spawn(int rate, int startType, int endtype)
    {
        for (int i = 0; i < rate; i++)
        {
			Vector3 newSpot;
			do {

				newSpot = new Vector3(Random.Range(-MapDistance, MapDistance), Random.Range(-MapDistance, MapDistance), 0);
				                      } while (
					(Vector3.Distance(newSpot, player.transform.position)<distanceAwayFromPlayer)
					&&
					//(Rect.MinMaxRect(-MapDistance, -MapDistance, MapDistance,MapDistance).Contains(newSpot))
					true

					);
				                      GameObject temp = (GameObject)Instantiate(prefabs[Random.Range(startType, endtype+1)], newSpot, transform.rotation);
			temp.GetComponent<BaseEnemy>().UpLevel(Level);
			temp.transform.parent = this.gameObject.transform;
			//tempObject.GetComponent<BaseEnemy>().gameObject.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        }

       // level++;

       /* if (level % 30 == 0)
        {
            rate++;
            print("rate: " + rate);
        }*/
    }
}
