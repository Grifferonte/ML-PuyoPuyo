using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuyoController2 : MonoBehaviour
{
    public static void puyoCreate()
    {
        GameMaster2.controlMainPuyo = GameMaster2.puyoInventory.Dequeue();
        GameMaster2.controlSubPuyo = GameMaster2.puyoInventory.Dequeue();
        GameMaster2.puyoInventory.ElementAt(1).getPuyoObj().transform.localPosition = new Vector3(160, 210, 0);
        GameMaster2.puyoInventory.ElementAt(1).Show();
        GameMaster2.puyoInventory.ElementAt(0).getPuyoObj().transform.localPosition = new Vector3(160, 258, 0);
        GameMaster2.puyoInventory.ElementAt(0).Show();
        GameMaster2.puyoInventory.Enqueue(PuyoCreater.PuyoCreate2(750, 18));
        GameMaster2.puyoInventory.ElementAt(2).Hide();
        GameMaster2.puyoInventory.Enqueue(PuyoCreater.PuyoCreate2(750, 50));
        GameMaster2.puyoInventory.ElementAt(3).Hide();
        GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3(0, 312, 0);
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3(0, 360, 0);
        GameMaster2.controlMainPuyo.setPosition(new Vector2(3, 12));
        GameMaster2.controlSubPuyo.setPosition(new Vector2(3, 13));
        GameMaster2.subPuyoDirection = 0;
        GameMaster2.comboNumber = 0;
        GameMaster2.mainPuyoShinyObj.transform.localPosition = new Vector3(0, 312, 0);
        GameMaster2.mainPuyoShinyObj.transform.SetAsLastSibling();
        ImageController.setShinyPuyo2(GameMaster2.controlMainPuyo.getColor());
    }

    public static void puyoDown(bool moveShinyPuyo)
    {
        GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3
                    (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y - 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.x, GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.y - 48, GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlMainPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x, GameMaster2.controlMainPuyo.getPosition().y - 1));
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlSubPuyo.getPosition().x, GameMaster2.controlSubPuyo.getPosition().y - 1));
        if (moveShinyPuyo)
        {
            GameMaster2.mainPuyoShinyObj.transform.localPosition = GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition;
        }
    }

    public static void puyoLeft(bool moveShinyPuyo)
    {
        GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3
                    (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x - 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.x - 48, GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.y, GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlMainPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x - 1, GameMaster2.controlMainPuyo.getPosition().y));
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlSubPuyo.getPosition().x - 1, GameMaster2.controlSubPuyo.getPosition().y));
        if (moveShinyPuyo)
        {
            GameMaster2.mainPuyoShinyObj.transform.localPosition = GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition;
        }
    }
    

    public static void puyoRight(bool moveShinyPuyo)
    {
        GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition = new Vector3
                    (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x + 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.x + 48, GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.y, GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlMainPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x + 1, GameMaster2.controlMainPuyo.getPosition().y));
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlSubPuyo.getPosition().x + 1, GameMaster2.controlSubPuyo.getPosition().y));
        if (moveShinyPuyo)
        {
            GameMaster2.mainPuyoShinyObj.transform.localPosition = GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition;
        }
}
    

    public static void puyoCounterclockwise()
    {
        int x = (int)GameMaster2.controlMainPuyo.getPosition().x;
        int y = (int)GameMaster2.controlMainPuyo.getPosition().y;
        if (GameMaster2.subPuyoDirection == 0)
        {
            if ((x == 0 || GameMaster2.puyoArr[x - 1, y] == null) && (x == 5 || GameMaster2.puyoArr[x + 1, y] == null))
            {
                if (x == 0 || GameMaster2.puyoArr[x - 1, y] != null)
                {
                    puyoRight(true);
                }
                GameMaster2.subPuyoDirection = 3;
                subPuyoMoveToLeft();
            }
        }
        else if (GameMaster2.subPuyoDirection == 1)
        {
            GameMaster2.subPuyoDirection = 0;
            subPuyoMoveToTop();
        }
        else if (GameMaster2.subPuyoDirection == 2)
        {
            if ((x == 5 || GameMaster2.puyoArr[x + 1, y] == null) && (x == 0 || GameMaster2.puyoArr[x - 1, y] == null))
            {
                if (x == 5 || GameMaster2.puyoArr[x + 1, y] != null)
                {
                    puyoLeft(true);
                }
                GameMaster2.subPuyoDirection = 1;
                subPuyoMoveToRight();
            }
        }
        else if (GameMaster2.subPuyoDirection == 3)
        {
            if (y != 0)
            {
                GameMaster2.subPuyoDirection = 2;
                subPuyoMoveToDown();
            }
        }

    }

    public static void puyoClockwise()
    {
        int x = (int)GameMaster2.controlMainPuyo.getPosition().x;
        int y = (int)GameMaster2.controlMainPuyo.getPosition().y;
        if (GameMaster2.subPuyoDirection == 0)
        {
            if ((x == 5 || GameMaster2.puyoArr[x + 1, y] == null) && (x == 0 || GameMaster2.puyoArr[x - 1, y] == null))
            {
                if (x == 5 || GameMaster2.puyoArr[x + 1, y] != null)
                {
                    puyoLeft(true);
                }
                GameMaster2.subPuyoDirection = 1;
                subPuyoMoveToRight();
            }
        }
        else if (GameMaster2.subPuyoDirection == 1)
        {
            if (y != 0)
            {
                GameMaster2.subPuyoDirection = 2;
                subPuyoMoveToDown();
            }
        }
        else if (GameMaster2.subPuyoDirection == 2)
        {
            if ((x == 0 || GameMaster2.puyoArr[x - 1, y] == null) && (x == 5 || GameMaster2.puyoArr[x + 1, y] == null))
            {
                if (x == 0 || GameMaster2.puyoArr[x - 1, y] != null)
                {
                    puyoRight(true);
                }
                GameMaster2.subPuyoDirection = 3;
                subPuyoMoveToLeft();
            }
        }
        else if (GameMaster2.subPuyoDirection == 3)
        {
            GameMaster2.subPuyoDirection = 0;
            subPuyoMoveToTop();
        }

    }

    public static void puyoArrange()
    {
        GameMaster2.mainPuyoShinyObj.transform.localPosition = new Vector3(0, 312, 0);
        //If a puyo on the air, then make it fall to bottom.
        for (int y = 1; y < 13; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    if (GameMaster2.puyoArr[x, y - 1] == null)
                    {
                        GameObject tempPuyo = GameMaster2.puyoArr[x, y].getPuyoObj();
                        tempPuyo.transform.localPosition = new Vector3(tempPuyo.transform.localPosition.x, tempPuyo.transform.localPosition.y - 48, tempPuyo.transform.localPosition.z);
                        GameMaster2.puyoArr[x, y - 1] = GameMaster2.puyoArr[x, y];
                        GameMaster2.puyoArr[x, y] = null;
                        y = 1;
                        x = -1;
                    }
                }
            }
        }
    }

    public static bool reachBottom(int x, int y)
    {
        if (y == 0)
        {
            return true;
        }
        if (GameMaster2.puyoArr[x, y - 1] != null)
        {
            return true;
        }
        return false;
    }

    //0=left, 1=right
    public static bool havingObstacle(int type, int x, int y)
    {
        if (y >= 13)
            return false;

        if (x <= 0 && type == 0)
            return true;

        if (x >= 5 && type == 1)
            return true;

        if (type == 0)
        {
            if (GameMaster2.puyoArr[x - 1, y] != null)
            {
                return true;
            }
        }
        else
        {
            if (GameMaster2.puyoArr[x + 1, y] != null)
            {
                return true;
            }
        }
        return false;
    }

    public static void subPuyoMoveToTop()
    {
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y + 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x, GameMaster2.controlMainPuyo.getPosition().y + 1));
    }

    public static void subPuyoMoveToDown()
    {
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y - 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x, GameMaster2.controlMainPuyo.getPosition().y - 1));
    }

    public static void subPuyoMoveToLeft()
    {
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x - 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x - 1, GameMaster2.controlMainPuyo.getPosition().y));
    }

    public static void subPuyoMoveToRight()
    {
        GameMaster2.controlSubPuyo.getPuyoObj().transform.localPosition = new Vector3
            (GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.x + 48, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.y, GameMaster2.controlMainPuyo.getPuyoObj().transform.localPosition.z);
        GameMaster2.controlSubPuyo.setPosition(new Vector2(GameMaster2.controlMainPuyo.getPosition().x + 1, GameMaster2.controlMainPuyo.getPosition().y));
    }

    public static void linkSamePuyo()
    {
        //Link horizontal obj
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 5; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    if (GameMaster2.puyoArr[x + 1, y] != null && GameMaster2.puyoArr[x, y].getColor() == GameMaster2.puyoArr[x + 1, y].getColor())
                    {
                        if (ImageController.LINK_LEFT == GameMaster2.puyoArr[x, y].getLinkStatus())
                            GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_RIGHT_LEFT);
                        else
                            GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_RIGHT);
                        GameMaster2.puyoArr[x + 1, y].setLinkStatus(ImageController.LINK_LEFT);

                        setPuyoALinkList(GameMaster2.puyoArr[x, y], GameMaster2.puyoArr[x + 1, y]);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        //Link vertical obj
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    if (GameMaster2.puyoArr[x, y + 1] != null && GameMaster2.puyoArr[x, y].getColor() == GameMaster2.puyoArr[x, y + 1].getColor())
                    {
                        switch (GameMaster2.puyoArr[x, y + 1].getLinkStatus())
                        {
                            case ImageController.NORMAL:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_DOWN);
                                break;
                            case ImageController.LINK_TOP:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_DOWN);
                                break;
                            case ImageController.LINK_LEFT:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_LEFT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_RIGHT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT_LEFT:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_RIGHT_LEFT_DOWN);
                                break;
                            case ImageController.LINK_TOP_LEFT:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_LEFT_DOWN);
                                break;
                            case ImageController.LINK_TOP_RIGHT:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_RIGHT_DOWN);
                                break;
                            case ImageController.LINK_TOP_RIGHT_LEFT:
                                GameMaster2.puyoArr[x, y + 1].setLinkStatus(ImageController.LINK_TOP_RIGHT_LEFT_DOWN);
                                break;
                        }
                        switch (GameMaster2.puyoArr[x, y].getLinkStatus())
                        {
                            case ImageController.NORMAL:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP);
                                break;
                            case ImageController.LINK_LEFT:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_LEFT);
                                break;
                            case ImageController.LINK_RIGHT:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT);
                                break;
                            case ImageController.LINK_RIGHT_LEFT:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT_LEFT);
                                break;
                            case ImageController.LINK_DOWN:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_DOWN);
                                break;
                            case ImageController.LINK_LEFT_DOWN:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_LEFT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT_DOWN:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT_DOWN);
                                break;
                            case ImageController.LINK_RIGHT_LEFT_DOWN:
                                GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.LINK_TOP_RIGHT_LEFT_DOWN);
                                break;
                        }

                        setPuyoALinkList(GameMaster2.puyoArr[x, y], GameMaster2.puyoArr[x, y + 1]);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        updatePuyoImage();
    }

    public static void updatePuyoImage()
    {
        //change img
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    //print("("+x+", "+y+")===>"+GameMaster2.puyoArr[x, y].getLinkPuyoList().Count);
                    emptyRow = false;
                    ImageController.setPuyoImage(GameMaster2.puyoArr[x, y], GameMaster2.puyoArr[x, y].getLinkStatus());
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static void setPuyoALinkList(Puyo puyoA, Puyo puyoB)
    {
        List<Puyo> puyoAList = puyoA.getLinkPuyoList();
        if (!puyoAList.Contains(puyoB))
        {
            puyoAList.Add(puyoB);
        }
        List<Puyo> puyoBList = puyoB.getLinkPuyoList();
        if (!puyoBList.Contains(puyoA))
        {
            puyoBList.Add(puyoA);
        }
        List<Puyo> puyoCList = puyoAList.Union(puyoBList).ToList<Puyo>();

        for (int i = 0; i < puyoAList.Count; i++)
        {
            puyoAList[i].setLinkPuyoList(puyoCList);
        }
        for (int i = 0; i < puyoBList.Count; i++)
        {
            puyoBList[i].setLinkPuyoList(puyoCList);
        }
    }

    public static void resetPuyoStatusAndLinkPuyoList()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.NORMAL);
                    List<Puyo> puyoList = new List<Puyo>();
                    puyoList.Add(GameMaster2.puyoArr[x, y]);
                    GameMaster2.puyoArr[x, y].setLinkPuyoList(puyoList);
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static bool readyToEliminatePuyo()
    {
        bool haveLinkPuyo = false;
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    emptyRow = false;
                    //print(puyoArr[x, y].getColor()+" " +puyoArr[x, y].getLinkedPuyoList().Count);
                    if (GameMaster2.puyoArr[x, y].getLinkPuyoList().Count >= 4)
                    {
                        haveLinkPuyo = true;
                        GameMaster2.puyoArr[x, y].setLinkStatus(ImageController.ELIMINATE_FACE);
                    }
                }
            }
            if (emptyRow)
                break;
        }
        updatePuyoImage();
        return haveLinkPuyo;
    }

    public static void eliminatePuyo()
    {
        for (int y = 0; y < 13; y++)
        {
            bool emptyRow = true;
            for (int x = 0; x < 6; x++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    if (ImageController.ELIMINATE_FACE == GameMaster2.puyoArr[x, y].getLinkStatus())
                    {
                        if (GameMaster2.puyoArr[x + 1, y].getColor() == 5)
                        {
                            Destroy(GameMaster2.puyoArr[x + 1, y].getPuyoObj());
                            GameMaster2.puyoArr[x + 1, y] = null;
                        }
                        if (GameMaster2.puyoArr[x - 1, y].getColor() == 5)
                        {
                            Destroy(GameMaster2.puyoArr[x - 1, y].getPuyoObj());
                            GameMaster2.puyoArr[x - 1, y] = null;
                        }
                        if (GameMaster2.puyoArr[x, y + 1].getColor() == 5)
                        {
                            Destroy(GameMaster2.puyoArr[x, y + 1].getPuyoObj());
                            GameMaster2.puyoArr[x, y + 1] = null;
                        }
                        if (GameMaster2.puyoArr[x, y - 1].getColor() == 5)
                        {
                            Destroy(GameMaster2.puyoArr[x + 1, y - 1].getPuyoObj());
                            GameMaster2.puyoArr[x, y - 1] = null;
                        }
                        Destroy(GameMaster2.puyoArr[x, y].getPuyoObj());
                        GameMaster2.puyoArr[x, y] = null;
                    }
                    emptyRow = false;
                }
            }
            if (emptyRow)
                break;
        }
    }

    public static bool isGameOver()
    {
        if (GameMaster2.controlMainPuyo.getPosition().y >= 12 || GameMaster2.controlSubPuyo.getPosition().y >= 12)
            return true;

        return false;
    }

    public static void hold()
    {
        int tempMainColor = GameMaster2.puyoInventory.ElementAt(1).getColor();
        int tempSubColor = GameMaster2.puyoInventory.ElementAt(0).getColor();
        GameMaster2.puyoInventory.ElementAt(1).setColor(GameMaster2.controlMainPuyo.getColor());
        GameMaster2.puyoInventory.ElementAt(0).setColor(GameMaster2.controlSubPuyo.getColor());
        GameMaster2.controlMainPuyo.setColor(tempMainColor);
        GameMaster2.controlSubPuyo.setColor(tempSubColor);
        ImageController.setPuyoImage(GameMaster2.puyoInventory.ElementAt(1), ImageController.NORMAL);
        ImageController.setPuyoImage(GameMaster2.puyoInventory.ElementAt(0), ImageController.NORMAL);
        ImageController.setPuyoImage(GameMaster2.controlMainPuyo, ImageController.NORMAL);
        ImageController.setPuyoImage(GameMaster2.controlSubPuyo, ImageController.NORMAL);
    }
}