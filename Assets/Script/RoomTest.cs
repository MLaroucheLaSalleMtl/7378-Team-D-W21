using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTest : MonoBehaviour
{

    public static GameObject AT;
    public static GameObject AL;
    public static GameObject AB;
    public static GameObject AR;
    public static GameObject BTB;
    public static GameObject BLR;
    public static GameObject BTL;
    public static GameObject BTR;
    public static GameObject BBL;
    public static GameObject BBR;
    public static GameObject CT;
    public static GameObject CL;
    public static GameObject CB;
    public static GameObject CR;
    public static GameObject D;

    public GameObject[] Rooms = { AT, AL, AB, AR, BTB, BLR, BTL, BTR, BBL, BBR, CT, CL, CB, CR, D };

    public class Wall
    {
        int top;
        int left;
        int bot;
        int right;

        public Wall(int top, int left, int bot, int right)
        {
            this.top = top;
            this.left = left;
            this.bot = bot;
            this.right = right;
        }

        public int Top { get => top; set => top = value; }
        public int Left { get => left; set => left = value; }
        public int Bot { get => bot; set => bot = value; }
        public int Right { get => right; set => right = value; }
    }

    class Program
    {
        static public Wall at = new Wall(1, 2, 2, 2);
        static public Wall al = new Wall(2, 1, 2, 2);
        static public Wall ab = new Wall(2, 2, 1, 2);
        static public Wall ar = new Wall(2, 2, 2, 1);
        static public Wall btb = new Wall(1, 2, 1, 2);
        static public Wall blr = new Wall(2, 1, 2, 1);
        static public Wall btl = new Wall(1, 1, 2, 2);
        static public Wall btr = new Wall(1, 2, 2, 1);
        static public Wall bbl = new Wall(2, 1, 1, 2);
        static public Wall bbr = new Wall(2, 2, 1, 1);
        static public Wall ct = new Wall(2, 1, 1, 1);
        static public Wall cl = new Wall(1, 2, 1, 1);
        static public Wall cb = new Wall(1, 1, 2, 1);
        static public Wall cr = new Wall(1, 1, 1, 2);
        static public Wall d = new Wall(1, 1, 1, 1);

        static int maxNum = 8;

        public static Wall[] walls = { at, al, ab, ar, btb, blr, btl, btr, bbl, bbr, ct, cl, cb, cr, d };

        public static int[,] points = new int[maxNum + 1, maxNum + 1];
        public static int[,] lineX = new int[maxNum + 1, maxNum];
        public static int[,] lineY = new int[maxNum, maxNum + 1];

        static void FirstRoom()
        {
            int Px, Py;
            int frNum = maxNum / 2;
            int rdmNum;
            points[frNum, frNum] = 1;
            points[frNum + 1, frNum] = 1;
            points[frNum + 1, frNum + 1] = 1;
            points[frNum, frNum + 1] = 1;
            rdmNum = Random.Range(0, 15);
            lineX[frNum, frNum] = walls[rdmNum].Top;
            lineY[frNum, frNum] = walls[rdmNum].Left;
            lineX[frNum + 1, frNum] = walls[rdmNum].Bot;
            lineY[frNum, frNum + 1] = walls[rdmNum].Right;
            Px = frNum;
            Py = frNum;

            RoomMaker(Px, Py);
        }

        public static void TopRoom(int a, int b)
        {
            if (lineX[a, b] == 1)
            {
                int rdmNum = 0;
                int Px = a - 1;
                int Py = b;

                int top = lineX[Px, Py];
                int bot = lineX[Px + 1, Py];
                int left = lineY[Px, Py];
                int right = lineY[Px, Py + 1];

                if ((left == 0 || right == 0 || top == 0 || bot == 0) && (points[Px, Py] == 0 || points[Px + 1, Py] == 0 || points[Px, Py + 1] == 0 || points[Px + 1, Py + 1] == 0))
                {

                    if (left != 1 && right != 1 && top != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1);
                    }
                    else if (left == 1 && right != 1 && top != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1 && walls[rdmNum].Left != 1);
                    }
                    else if (left != 1 && right == 1 && top != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1 && walls[rdmNum].Right != 1);
                    }
                    else if (left != 1 && right != 1 && top == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (left == 1 && right == 1 && top != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1 && walls[rdmNum].Left != 1 && walls[rdmNum].Right != 1);
                    }
                    else if (left == 1 && right != 1 && top == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1 && walls[rdmNum].Left != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (left != 1 && right == 1 && top == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Bot != 1 && walls[rdmNum].Right != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (left == 1 && right == 1 && top == 1)
                    {
                        rdmNum = 14;
                    }

                    points[Px, Py] = 1;
                    points[Px + 1, Py] = 1;
                    points[Px + 1, Py + 1] = 1;
                    points[Px, Py + 1] = 1;

                    lineX[Px, Py] = walls[rdmNum].Top;
                    lineY[Px, Py] = walls[rdmNum].Left;
                    lineX[Px + 1, Py] = walls[rdmNum].Bot;
                    lineY[Px, Py + 1] = walls[rdmNum].Right;

                    TopRoom(Px, Py);
                    LeftRoom(Px, Py);
                    RightRoom(Px, Py);


                }
            }
        }

        public static void BotRoom(int a, int b)
        {
            if (lineX[a + 1, b] == 1)
            {
                int rdmNum = 0;
                int Px = a + 1;
                int Py = b;

                int top = lineX[Px, Py];
                int bot = lineX[Px + 1, Py];
                int left = lineY[Px, Py];
                int right = lineY[Px, Py + 1];

                if ((left == 0 || right == 0 || top == 0 || bot == 0) && (points[Px, Py] == 0 || points[Px + 1, Py] == 0 || points[Px, Py + 1] == 0 || points[Px + 1, Py + 1] == 0))
                {
                    if (left != 1 && right != 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1);
                    }
                    else if (left == 1 && right != 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1 && walls[rdmNum].Left != 1);
                    }
                    else if (left != 1 && right == 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1 && walls[rdmNum].Right != 1);
                    }
                    else if (left != 1 && right != 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (left == 1 && right == 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1 && walls[rdmNum].Left != 1 && walls[rdmNum].Right != 1);
                    }
                    else if (left == 1 && right != 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1 && walls[rdmNum].Left != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (left != 1 && right == 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Top != 1 && walls[rdmNum].Right != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (left == 1 && right == 1 && bot == 1)
                    {
                        rdmNum = 14;
                    }

                    points[Px, Py] = 1;
                    points[Px + 1, Py] = 1;
                    points[Px + 1, Py + 1] = 1;
                    points[Px, Py + 1] = 1;

                    lineX[Px, Py] = walls[rdmNum].Top;
                    lineY[Px, Py] = walls[rdmNum].Left;
                    lineX[Px + 1, Py] = walls[rdmNum].Bot;
                    lineY[Px, Py + 1] = walls[rdmNum].Right;

                    BotRoom(Px, Py);
                    LeftRoom(Px, Py);
                    RightRoom(Px, Py);
                }
            }
        }

        public static void LeftRoom(int a, int b)
        {
            if (lineY[a, b] == 1)
            {
                int rdmNum = 0;
                int Px = a;
                int Py = b - 1;

                int top = lineX[Px, Py];
                int bot = lineX[Px + 1, Py];
                int left = lineY[Px, Py];
                int right = lineY[Px, Py + 1];

                if ((left == 0 || right == 0 || top == 0 || bot == 0) && (points[Px, Py] == 0 || points[Px + 1, Py] == 0 || points[Px, Py + 1] == 0 || points[Px + 1, Py + 1] == 0))
                {
                    if (left != 1 && top != 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1);
                    }
                    else if (left == 1 && top != 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1 && walls[rdmNum].Left != 1);
                    }
                    else if (left != 1 && top == 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (left != 1 && top != 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (left == 1 && top == 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1 && walls[rdmNum].Left != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (left == 1 && top != 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1 && walls[rdmNum].Left != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (left != 1 && top == 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Right != 1 && walls[rdmNum].Top != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (left == 1 && top == 1 && bot == 1)
                    {
                        rdmNum = 14;
                    }

                    points[Px, Py] = 1;
                    points[Px + 1, Py] = 1;
                    points[Px + 1, Py + 1] = 1;
                    points[Px, Py + 1] = 1;

                    lineX[Px, Py] = walls[rdmNum].Top;
                    lineY[Px, Py] = walls[rdmNum].Left;
                    lineX[Px + 1, Py] = walls[rdmNum].Bot;
                    lineY[Px, Py + 1] = walls[rdmNum].Right;

                    LeftRoom(Px, Py);
                    TopRoom(Px, Py);
                    BotRoom(Px, Py);
                }
            }
        }

        public static void RightRoom(int a, int b)
        {
            if (lineY[a, b + 1] == 1)
            {
                int rdmNum = 0;
                int Px = a;
                int Py = b + 1;

                int top = lineX[Px, Py];
                int bot = lineX[Px + 1, Py];
                int left = lineY[Px, Py];
                int right = lineY[Px, Py + 1];

                if ((left == 0 || right == 0 || top == 0 || bot == 0) && (points[Px, Py] == 0 || points[Px + 1, Py] == 0 || points[Px, Py + 1] == 0 || points[Px + 1, Py + 1] == 0))
                {
                    if (right != 1 && top != 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1);
                    }
                    else if (right == 1 && top != 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1 && walls[rdmNum].Right != 1);
                    }
                    else if (right != 1 && top == 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (right != 1 && top != 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (right == 1 && top == 1 && bot != 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1 && walls[rdmNum].Right != 1 && walls[rdmNum].Top != 1);
                    }
                    else if (right == 1 && top != 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1 && walls[rdmNum].Right != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (right != 1 && top == 1 && bot == 1)
                    {
                        do
                        {
                            rdmNum = Random.Range(0, 15);
                        } while (walls[rdmNum].Left != 1 && walls[rdmNum].Top != 1 && walls[rdmNum].Bot != 1);
                    }
                    else if (right == 1 && top == 1 && bot == 1)
                    {
                        rdmNum = 14;
                    }

                    points[Px, Py] = 1;
                    points[Px + 1, Py] = 1;
                    points[Px + 1, Py + 1] = 1;
                    points[Px, Py + 1] = 1;

                    lineX[Px, Py] = walls[rdmNum].Top;
                    lineY[Px, Py] = walls[rdmNum].Left;
                    lineX[Px + 1, Py] = walls[rdmNum].Bot;
                    lineY[Px, Py + 1] = walls[rdmNum].Right;

                    TopRoom(Px, Py);
                    BotRoom(Px, Py);
                    RightRoom(Px, Py);
                }
            }
        }

        public static void RoomMaker(int a, int b)
        {
            TopRoom(a, b);
            BotRoom(a, b);
            LeftRoom(a, b);
            RightRoom(a, b);
        }

        public static void BorderSet(int[,] p, int[,] lx, int[,] ly)
        {
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if ((i == 0 || j == 0) || (i == p.GetLength(0) - 1 || j == p.GetLength(1) - 1))
                    {
                        p[i, j] = 2;
                    }
                }
            }

            for (int i = 0; i < lx.GetLength(0); i++)
            {
                for (int j = 0; j < lx.GetLength(1); j++)
                {
                    if ((i == 0) || (i == lx.GetLength(0) - 1))
                    {
                        lx[i, j] = 2;
                    }
                }
            }

            for (int i = 0; i < ly.GetLength(0); i++)
            {
                for (int j = 0; j < ly.GetLength(1); j++)
                {
                    if ((j == 0) || (j == ly.GetLength(1) - 1))
                    {
                        ly[i, j] = 2;
                    }
                }
            }
        }

        static void MapCreater()
        {
            
        }

        static void Start()
        {

        }

    }

}
