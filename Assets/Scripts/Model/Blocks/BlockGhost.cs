using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGhost : DestroyedBlock
{
    private Ball ball;
    private float ghostDelay = 1.0f;

    private void Start()
    {
        ball = MainManager.inst.SceneController.Ball;
        base.SetColor();
    }

    protected override void DestroyAction()
    {
        ball.EnableGhost(ghostDelay);
        base.DestroyAction();
    }

}
