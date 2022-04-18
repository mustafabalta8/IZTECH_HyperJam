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
            HandleTrueAnswer();

        }
        else if(!PlayerMovement.instance.CanSideMove)
        {
            HandleWrongAnswer();
        }
    }

    private void HandleWrongAnswer()
    {
        SoundMananger.instance.PlayBombSound();
        Destroy(gameObject);
        MovePlayer();
        Score.ChangeScore(-20);
    }

    private void HandleTrueAnswer()
    {
        particleFX.transform.parent = null;
        particleFX.SetActive(true);
        Destroy(gameObject);
        SoundMananger.instance.PlaySuccessSound();
        MovePlayer();
        Score.ChangeScore(40);
    }

    private void MovePlayer()
    {
        PlayerMovement.instance.Movement = Vector3.forward;
        PlayerMovement.instance.CanSideMove = true;
        Player.CharacterAnimator.SetBool("isRunning", true);
    }
}
