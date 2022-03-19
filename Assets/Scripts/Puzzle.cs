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
            //Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
            
            SoundMananger.instance.PlaySuccessSound();
            MovePlayer();
            Score.instance.ChangeScore(40);
        }
        else
        {
            SoundMananger.instance.PlayBombSound();
            Destroy(gameObject);
            MovePlayer();
            Score.instance.ChangeScore(-20);
        }
    }

    private void MovePlayer()
    {
        PlayerMovement.instance.Movement = Vector3.forward;
        PlayerMovement.instance.CanSideMove = true;
        Player.characterAnimator.SetBool("isRunning", true);
    }
}
