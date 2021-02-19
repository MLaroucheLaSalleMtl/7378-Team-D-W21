using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomTemplates templates;

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

    public Wall[] squares = { at, al, ab, ar, btb, blr, btl, btr, bbl, bbr, ct, cl, cb, cr, d };

    static int maxNum = 31;

    public static int[,] points = new int[maxNum + 1, maxNum + 1];
    public static int[,] laneX = new int[maxNum, maxNum];
    public static int[,] laneY = new int[maxNum, maxNum];

    /*
    public bool PointCheck(int a[][], int[,] b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < a.Length; j++)
            {
                if (a == a)
                {
                    points[1, 2] = 1;
                    points[99, 99] = 1;
                    return true;
                }
            }
        }
        return false;
    }
    */
    public void BorderSet(int[,] p, int[,] lx, int[,] ly)
    {
        for (int i = 0; i < p.Length; i++)
        {
            for (int j = 0; j < p.Length; j++)
            {
                if ((i == 0 || j == 0)||(i == p.Length || j == p.Length))
                {
                    p[i, j] = 1;
                }
            }
        }

    }

}
