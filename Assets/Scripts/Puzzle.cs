using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string trueAnswer; 

    public void GetAnswer(string answer)
    {
        if (answer == trueAnswer && !Player.characterAnimator.GetBool("isRunning"))
        {            
            Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
            PlayerMovement.instance.Movement = Vector3.forward;
            PlayerMovement.instance.CanSideMove = true;

            Player.characterAnimator.SetBool("isRunning", true);
            //FindObjectOfType<Player>().characterAnimator.SetBool("isRunning", true);
        }
        else
        {
            print("yanlýþ cevap");
        }
    }
}
