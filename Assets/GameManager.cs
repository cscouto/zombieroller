using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject selectedObject;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 defaultSize;
    private int selectedPosition = 0;

	// Use this for initialization
	void Start () 
    {
        SelectZombie(selectedObject);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown("left"))
        {
            zombies[selectedPosition].transform.localScale = defaultSize; 
            if (selectedPosition == 0){
                selectedPosition = 3;
            }else{
                selectedPosition -= 1;
            }
        }
        if (Input.GetKeyDown("right"))
        {
            zombies[selectedPosition].transform.localScale = defaultSize; 
            if (selectedPosition == 3)
            {
                selectedPosition = 0;
            }
            else
            {
                selectedPosition += 1;
            }
        }
        if (Input.GetKeyDown("up"))
        {
            PushUp();
        }
        selectedObject = zombies[selectedPosition];
        SelectZombie(selectedObject);
	}

    void SelectZombie(GameObject newZombie) 
    {
        newZombie.transform.localScale = selectedSize;  
    }

    void PushUp()
    {
        Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }
}
