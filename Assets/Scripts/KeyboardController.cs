using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    // Update is called once per frame

    void Update() {
        if (GameMaster.gameStatus == GameMaster.GameStatus.PuyoFalling)
        {


            if (Input.GetKeyUp(KeyCode.Q) && (!PuyoController.havingObstacle(0, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                     !PuyoController.havingObstacle(0, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
            {
                PuyoController.puyoLeft(true);
            }
            if (Input.GetKeyUp(KeyCode.D) && (!PuyoController.havingObstacle(1, (int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController.havingObstacle(1, (int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y))) { 

                PuyoController.puyoRight(true);}
        
        if (Input.GetKeyUp(KeyCode.S) && (!PuyoController.reachBottom((int)GameMaster.controlMainPuyo.getPosition().x, (int)GameMaster.controlMainPuyo.getPosition().y) &&
                                                   !PuyoController.reachBottom((int)GameMaster.controlSubPuyo.getPosition().x, (int)GameMaster.controlSubPuyo.getPosition().y)))
        {
            PuyoController.puyoDown(true);
        }
        //counterclockwise
        if (Input.GetKeyUp(KeyCode.A))
        {
            PuyoController.puyoCounterclockwise();
        }
        //clockwise
        if (Input.GetKeyUp(KeyCode.E))
        {
            PuyoController.puyoClockwise();
        }
       
    }
    if (GameMaster2.gameStatus == GameMaster2.GameStatus.PuyoFalling)
        {

            if (Input.GetKeyUp(KeyCode.LeftArrow) && (!PuyoController2.havingObstacle(0, (int)GameMaster2.controlMainPuyo.getPosition().x, (int)GameMaster2.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController2.havingObstacle(0, (int)GameMaster2.controlSubPuyo.getPosition().x, (int)GameMaster2.controlSubPuyo.getPosition().y)))
            {
                PuyoController2.puyoLeft(true);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && (!PuyoController2.havingObstacle(1, (int)GameMaster2.controlMainPuyo.getPosition().x, (int)GameMaster2.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController2.havingObstacle(1, (int)GameMaster2.controlSubPuyo.getPosition().x, (int)GameMaster2.controlSubPuyo.getPosition().y)))
            {
                PuyoController2.puyoRight(true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && (!PuyoController2.reachBottom((int)GameMaster2.controlMainPuyo.getPosition().x, (int)GameMaster2.controlMainPuyo.getPosition().y) &&
                                                       !PuyoController2.reachBottom((int)GameMaster2.controlSubPuyo.getPosition().x, (int)GameMaster2.controlSubPuyo.getPosition().y)))
            {
                PuyoController2.puyoDown(true);
            }
            //counterclockwise
            if (Input.GetKeyUp(KeyCode.Keypad1))
            {
                PuyoController2.puyoCounterclockwise();
            }
            //clockwise
            if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                PuyoController2.puyoClockwise();
            }
       
        }
    } 
}
