using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
   
    public string trueAnswer; 

    public void GetAnswer(string answer)
    {
        if (answer == trueAnswer)
        {
            Debug.Log("baþarýlý");
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
            PlayerMovement.instance.movement = new Vector3(0, 0, 1);
            PlayerMovement.instance.canSideMove = true;
        }
        else
        {
            print("yanlýþ cevap");
        }
    }


    



}
