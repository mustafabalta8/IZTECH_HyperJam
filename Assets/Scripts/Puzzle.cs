using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string trueAnswer;
    [SerializeField] private GameObject particleFX;
    public void GetAnswer(string answer)
    {
        if (answer == trueAnswer && PlayerMovement.instance.CanSideMove == false)
        {
            particleFX.transform.parent = null;
            particleFX.SetActive(true);
            Destroy(gameObject);
            
            SoundMananger.instance.PlaySuccessSound();
            MovePlayer();
            Score.instance.ChangeScore(40);
            
        }
        else if(!PlayerMovement.instance.CanSideMove)
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
