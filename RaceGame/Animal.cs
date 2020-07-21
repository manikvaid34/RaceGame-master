using System;
using System.Drawing;
using System.Windows.Forms;

namespace RaceGame
{
    public class Animal
    {
        public int StartingPoint;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public PictureBox MyPictureGif = null;
        public int Location = 0;
        public Random MyRandom;
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public bool Run()
        {
            MyRandom = new Random();
            int distance = MyRandom.Next(1, 6);


            MoveMyPictureGif(distance);

            Location += distance;
            if (Location >= (RacetrackLength - StartingPoint))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPoint()
        {
            MoveMyPictureBox(-Location);

            Location = 0;
        }

        public void MoveMyPictureBox(int distance)
        {
            MyPictureBox.Visible = true;
            MyPictureGif.Visible = false;
            Point p = MyPictureGif.Location;
            p.X += distance;
            MyPictureGif.Location = p;
        }

        public void MoveMyPictureGif(int distance)
        {
            MyPictureBox.Visible = false;
            MyPictureGif.Visible = true;

            Point p = MyPictureGif.Location;
            p.X += distance;
            MyPictureGif.Location = p;
        }
    }

}
