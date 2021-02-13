using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTest : MonoBehaviour
{
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
    public class Point
    {
        int x;
        int y;
        int z;

        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
    }
    public class Line
    {
        Point a;
        Point b;
        int check;

        public Line(Point a, Point b, int check)
        {
            this.a = a;
            this.b = b;
            this.check = check;
        }

        public int Check { get => check; set => check = value; }
        public Point A { get => a; set => a = value; }
        public Point B { get => b; set => b = value; }
    }
    public class Square
    {
        Point tr;
        Point tl;
        Point bl;
        Point br;

        int p_top;
        int p_left;
        int p_bot;
        int p_right;

        public Square(Point tr, Point tl, Point bl, Point br, int p_top, int p_left, int p_bot, int p_right)
        {
            this.tr = tr;
            this.tl = tl;
            this.bl = bl;
            this.br = br;
            this.p_top = p_top;
            this.p_left = p_left;
            this.p_bot = p_bot;
            this.p_right = p_right;
        }

        public int P_top { get => p_top; set => p_top = value; }
        public int P_left { get => p_left; set => p_left = value; }
        public int P_bot { get => p_bot; set => p_bot = value; }
        public int P_right { get => p_right; set => p_right = value; }
        public Point Tr { get => tr; set => tr = value; }
        public Point Tl { get => tl; set => tl = value; }
        public Point Bl { get => bl; set => bl = value; }
        public Point Br { get => br; set => br = value; }
    }

    public GameObject AT;
    public GameObject AL;
    public GameObject AB;
    public GameObject AR;
    public GameObject BTB;
    public GameObject BLR;
    public GameObject BTL;
    public GameObject BTR;
    public GameObject BBL;
    public GameObject BBR;
    public GameObject CT;
    public GameObject CL;
    public GameObject CB;
    public GameObject CR;
    public GameObject D;

    static public Wall at = new Wall(1, 0, 0, 0);
    static public Wall al = new Wall(0, 1, 0, 0);
    static public Wall ab = new Wall(0, 0, 1, 0);
    static public Wall ar = new Wall(0, 0, 0, 1);
    static public Wall btb = new Wall(1, 0, 1, 0);
    static public Wall blr = new Wall(0, 1, 0, 1);
    static public Wall btl = new Wall(1, 1, 0, 0);
    static public Wall btr = new Wall(1, 0, 0, 1);
    static public Wall bbl = new Wall(0, 1, 1, 0);
    static public Wall bbr = new Wall(0, 0, 1, 1);
    static public Wall ct = new Wall(0, 1, 1, 1);
    static public Wall cl = new Wall(1, 0, 1, 1);
    static public Wall cb = new Wall(1, 1, 0, 1);
    static public Wall cr = new Wall(1, 1, 1, 0);
    static public Wall d = new Wall(1, 1, 1, 1);

    public Wall[] squares = { at, al, ab, ar, btb, blr, btl, btr, bbl, bbr, ct, cl, cb, cr, d };

    static public Point X00Y00 = new Point(0, 0, 0); static public Point X00Y01 = new Point(0, 1, 0); static public Point X00Y02 = new Point(0, 2, 0); static public Point X00Y03 = new Point(0, 3, 0); static public Point X00Y04 = new Point(0, 4, 0); static public Point X00Y05 = new Point(0, 5, 0);
    static public Point X01Y00 = new Point(1, 0, 0); static public Point X01Y01 = new Point(1, 1, 0); static public Point X01Y02 = new Point(1, 2, 0); static public Point X01Y03 = new Point(1, 3, 0); static public Point X01Y04 = new Point(1, 4, 0); static public Point X01Y05 = new Point(1, 5, 0);
    static public Point X02Y00 = new Point(2, 0, 0); static public Point X02Y01 = new Point(2, 1, 0); static public Point X02Y02 = new Point(2, 2, 0); static public Point X02Y03 = new Point(2, 3, 0); static public Point X02Y04 = new Point(2, 4, 0); static public Point X02Y05 = new Point(2, 5, 0);
    static public Point X03Y00 = new Point(3, 0, 0); static public Point X03Y01 = new Point(3, 1, 0); static public Point X03Y02 = new Point(3, 2, 0); static public Point X03Y03 = new Point(3, 3, 0); static public Point X03Y04 = new Point(3, 4, 0); static public Point X03Y05 = new Point(3, 5, 0);
    static public Point X04Y00 = new Point(4, 0, 0); static public Point X04Y01 = new Point(4, 1, 0); static public Point X04Y02 = new Point(4, 2, 0); static public Point X04Y03 = new Point(4, 3, 0); static public Point X04Y04 = new Point(4, 4, 0); static public Point X04Y05 = new Point(4, 5, 0);
    static public Point X05Y00 = new Point(5, 0, 0); static public Point X05Y01 = new Point(5, 1, 0); static public Point X05Y02 = new Point(5, 2, 0); static public Point X05Y03 = new Point(5, 3, 0); static public Point X05Y04 = new Point(5, 4, 0); static public Point X05Y05 = new Point(5, 5, 0);

    public Point[] points = {
        X00Y00, X00Y01, X00Y02, X00Y03, X00Y04, X00Y05,
        X01Y00, X01Y01, X01Y02, X01Y03, X01Y04, X01Y05,
        X02Y00, X02Y01, X02Y02, X02Y03, X02Y04, X02Y05,
        X03Y00, X03Y01, X03Y02, X03Y03, X03Y04, X03Y05,
        X04Y00, X04Y01, X04Y02, X04Y03, X04Y04, X04Y05,
        X05Y00, X05Y01, X05Y02, X05Y03, X05Y04, X05Y05
    };

    static public Line a1 = new Line(X00Y00, X00Y01, 0); static public Line a2 = new Line(X00Y01, X00Y02, 0); static public Line a3 = new Line(X00Y02, X00Y03, 0); static public Line a4 = new Line(X00Y03, X00Y04, 0); static public Line a5 = new Line(X00Y04, X00Y05, 0);
    static public Line b1 = new Line(X01Y00, X01Y01, 0); static public Line b2 = new Line(X01Y01, X01Y02, 0); static public Line b3 = new Line(X01Y02, X01Y03, 0); static public Line b4 = new Line(X01Y03, X01Y04, 0); static public Line b5 = new Line(X01Y04, X01Y05, 0);
    static public Line c1 = new Line(X02Y00, X02Y01, 0); static public Line c2 = new Line(X02Y01, X02Y02, 0); static public Line c3 = new Line(X02Y02, X02Y03, 0); static public Line c4 = new Line(X02Y03, X02Y04, 0); static public Line c5 = new Line(X02Y04, X02Y05, 0);
    static public Line d1 = new Line(X03Y00, X03Y01, 0); static public Line d2 = new Line(X03Y01, X03Y02, 0); static public Line d3 = new Line(X03Y02, X03Y03, 0); static public Line d4 = new Line(X03Y03, X03Y04, 0); static public Line d5 = new Line(X03Y04, X03Y05, 0);
    static public Line e1 = new Line(X04Y00, X04Y01, 0); static public Line e2 = new Line(X04Y01, X04Y02, 0); static public Line e3 = new Line(X04Y02, X04Y03, 0); static public Line e4 = new Line(X04Y03, X04Y04, 0); static public Line e5 = new Line(X04Y04, X04Y05, 0);
    static public Line f1 = new Line(X05Y00, X05Y01, 0); static public Line f2 = new Line(X05Y01, X05Y02, 0); static public Line f3 = new Line(X05Y02, X05Y03, 0); static public Line f4 = new Line(X05Y03, X05Y04, 0); static public Line f5 = new Line(X05Y04, X05Y05, 0);

    static public Line A1 = new Line(X00Y00, X01Y00, 0); static public Line A2 = new Line(X00Y01, X02Y00, 0); static public Line A3 = new Line(X02Y00, X03Y00, 0); static public Line A4 = new Line(X03Y00, X04Y00, 0); static public Line A5 = new Line(X04Y00, X05Y00, 0);
    static public Line B1 = new Line(X00Y01, X01Y01, 0); static public Line B2 = new Line(X01Y01, X02Y01, 0); static public Line B3 = new Line(X02Y01, X03Y01, 0); static public Line B4 = new Line(X03Y01, X04Y01, 0); static public Line B5 = new Line(X04Y01, X05Y01, 0);
    static public Line C1 = new Line(X00Y02, X01Y02, 0); static public Line C2 = new Line(X01Y02, X02Y02, 0); static public Line C3 = new Line(X02Y02, X03Y02, 0); static public Line C4 = new Line(X03Y02, X04Y02, 0); static public Line C5 = new Line(X04Y02, X05Y02, 0);
    static public Line D1 = new Line(X00Y03, X01Y03, 0); static public Line D2 = new Line(X01Y03, X02Y03, 0); static public Line D3 = new Line(X02Y03, X03Y03, 0); static public Line D4 = new Line(X03Y03, X04Y03, 0); static public Line D5 = new Line(X04Y03, X05Y03, 0);
    static public Line E1 = new Line(X00Y04, X01Y04, 0); static public Line E2 = new Line(X01Y04, X02Y04, 0); static public Line E3 = new Line(X02Y04, X03Y04, 0); static public Line E4 = new Line(X03Y04, X04Y04, 0); static public Line E5 = new Line(X04Y04, X05Y04, 0);
    static public Line F1 = new Line(X00Y05, X01Y05, 0); static public Line F2 = new Line(X01Y05, X02Y05, 0); static public Line F3 = new Line(X02Y05, X03Y05, 0); static public Line F4 = new Line(X03Y05, X04Y05, 0); static public Line F5 = new Line(X04Y05, X05Y05, 0);

    public Line[] lines =
    {
        a1,a2,a3,a4,a5,
        b1,b2,b3,b4,b5,
        c1,c2,c3,c4,c5,
        d1,d2,d3,d4,d5,
        e1,e2,e3,e4,e5,
        f1,f2,f3,f4,f5,
        A1,A2,A3,A4,A5,
        B1,B2,B3,B4,B5,
        C1,C2,C3,C4,C5,
        D1,D2,D3,D4,D5,
        E1,E2,E3,E4,E5,
        F1,F2,F3,F4,F5
    };

    int rd = Random.Range(0, 15);

    public int Count(Wall a)
    {
        return a.Top + a.Left + a.Bot + a.Right;
    }

    public void sss(Square a)
    {
        if (a.P_top == 1)
        {
            
        }
        if (a.P_left == 1)
        {

        }
        if (a.P_bot == 1)
        {

        }
        if (a.P_right == 1)
        {

        }
    }

    public void SquareCheckTop(Square a)
    {
        Point BL = a.Tl;
        Point BR = a.Tr;
        Point TL = new Point(a.Tl.X, a.Tl.Y - 1);
        Point TR = new Point(a.Tr.X, a.Tr.Y - 1);

        if (PointCheck(points, TL) == 0 && PointCheck(points, TR) == 0)
        {
            
        }

        if (PointCheck(points, TL) ==1 && PointCheck(points, TR) == 1)
        {
            LineCheck(lines, TL, BL);
            LineCheck(lines, TR, BR);
            LineCheck(lines, TL, TR);
        }

        if (PointCheck(points, TL) == 1 && PointCheck(points, TR) == 0)
        {
            LineCheck(lines, TL, BL);
        }

        if (PointCheck(points, TL) == 0 && PointCheck(points, TR) == 1)
        {
            LineCheck(lines, TR, BR);
        }
    }

    public int PointCheck(Point[] p, Point a)
    {
        for (int i = 0; i < p.Length; i++)
        {
            if (a.X == p[i].X)
            {
                if (a.Y == p[i].Y)
                {
                    return p[i].Z;
                }
            }
        }
        return 0;
    }

    public int LineCheck(Line[] a_line, Point x, Point y)
    {
        for (int i = 0; i < a_line.Length; i++) 
        {
            if (x == a_line[i].A)
            {
                if (y == a_line[i].B)
                {
                    return a_line[i].Check;
                }
            }
        }
        return 0;
    }

    public void Map()
    {
        Square[] sqar = new Square[10];

        for (int i = 0; i < 15; i++)
        {
            if (i == 0)
            {
                int rd = Random.Range(0, 15);
                X02Y03.Z = 1;
                X02Y02.Z = 1;
                X03Y02.Z = 1;
                X03Y03.Z = 1;
                sqar[0] = new Square(X02Y03, X02Y02, X03Y02, X03Y03, squares[rd].Top, squares[rd].Left, squares[rd].Bot, squares[rd].Right); 
            }
        }
    }
}
