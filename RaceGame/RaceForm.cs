using RaceGame.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;



namespace RaceGame
{

    public partial class RaceForm : Form
    {
        Animal[] animal = new Animal[6];
        public Punter[] punter = new Punter[3];


        public RaceForm()
        {
            InitializeComponent();
            Race();
        }

        private void playaudio()
        {
            SoundPlayer audio = new SoundPlayer(Resources.gamesound1);
            audio.Play();
        }

        // ************** Method for Racing & betting Texts ******************** 
        private void Race()
        {
            playaudio();

            lblMinimumBet.Text = string.Format("Minimum bet {0:c}", (int)BetAmount.Minimum);

            int StartingPoint = pbanimal_1.Right - pbRaceTrack.Left;
            int raceTrackLength = pbRaceTrack.Size.Width;

            // ******** Animal palce hold & config


            animal[0] = new Animal()
            {
                MyPictureBox = pbanimal_1,
                MyPictureGif = pbanimal1,
                RacetrackLength = raceTrackLength,
                StartingPoint = StartingPoint
            };
            animal[1] = new Animal()
            {
                MyPictureBox = pbanimal_2,
                MyPictureGif = pbanimal2,
                RacetrackLength = raceTrackLength,
                StartingPoint = StartingPoint
            };
            animal[2] = new Animal()
            {
                MyPictureBox = pbanimal_3,
                MyPictureGif = pbanimal3,
                RacetrackLength = raceTrackLength,
                StartingPoint = StartingPoint
            };
            animal[3] = new Animal()
            {
                MyPictureBox = pbanimal_4,
                MyPictureGif = pbanimal4,
                RacetrackLength = raceTrackLength,
                StartingPoint = StartingPoint
            };
            animal[4] = new Animal()
            {
                MyPictureBox = pbanimal_5,
                MyPictureGif = pbanimal5,
                RacetrackLength = raceTrackLength,
                StartingPoint = StartingPoint
            };
            animal[5] = new Animal()
            {
                MyPictureBox = pbanimal_6,
                MyPictureGif = pbanimal6,
                RacetrackLength = raceTrackLength,
                StartingPoint = StartingPoint
            };

            // ********* GET the Punterfrom Factory*********
            for (int i = 0; i < 3; i++)
            {
                punter[i] = Factory.GetPunter(i);

            }

            // ****Method to get value  and show detail ****
            string aa = punter[0].GuyName;



            // ** To find which punter require Laptop in their couse with Name Filter**
            punter[0].GuyName = "Ram";
            punter[1].GuyName = "Sita";
            punter[2].GuyName = "Ali";



            // ** Binds the Radio buttons control between Class & Radio button Name **
            punter[0].MyRadioButton = rbRam;
            punter[1].MyRadioButton = rbSita;
            punter[2].MyRadioButton = rbAli;

            // ** Binds the labels with radio buttons via punter number as Tag **
            punter[0].myLabel = lblRam;
            punter[1].myLabel = lblSita;
            punter[2].myLabel = lblAli;




            // ** Just to count punter count  :-  No much use or can be ignoreable/deleteable
            foreach (var Id in punter)
            {
                if (Factory.PunterCount < Id.PunterID)
                {
                    Factory.PunterCount = Id.PunterID;
                }
                // Need to add one to get a count of students
                Factory.PunterCount += 1;
            }


            // Label method to go on Punter Labels
            foreach (Punter punter in punter)
            {
                punter.UpdateLabels();

            }

        }



        // ******** Race Button Method *********************
        private void btnRace_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningAnimal;
            DateTime StartTime = DateTime.Now;



            // **** Race button to disable *****
            btnRace.Enabled = false;
            btnBets.Enabled = false;
            BetAmount.Enabled = false;
            lbAnimalName.Enabled = false;
            rbRam.Enabled = false;
            rbSita.Enabled = false;
            rbAli.Enabled = false;
            btnResetGame.Enabled = false;

            while (NoWinner)
            {
                // ** provide a action for images *****
                Application.DoEvents();


                //*********** Race Looping method ****************
                for (int i = 0; i < animal.Length; i++)

                {
                    if (animal[i].Run())
                    {
                        winningAnimal = i + 1;

                        NoWinner = false;

                        MessageBox.Show(text: "Animal Number " + winningAnimal + " is winner");
                        foreach (Punter punter in punter)
                        {
                            if (punter.MyBets != null)
                            {

                                punter.Collect(winningAnimal);
                                DateTime EndTime = DateTime.Now;
                                var difference = (EndTime - StartTime).Seconds;

                                punter.MyBets = null;
                                punter.UpdateLabels();

                            }
                        }
                        foreach (Animal animal in animal)
                        {
                            animal.TakeStartingPoint();
                        }
                        break;
                    }
                    // To Control the speed
                    Thread.Sleep(5);
                }

            }

            // **** After Race button to enable *****
            btnRace.Enabled = true;
            btnBets.Enabled = true;
            BetAmount.Enabled = true;
            lbAnimalName.Enabled = true;
            rbRam.Enabled = true;
            rbSita.Enabled = true;
            rbAli.Enabled = true;
            btnResetGame.Enabled = true;
        }


        //****** One method for all Radio button ************
        private void Allrb_CheckedChange(object sender, EventArgs e)
        {
            //**** All Method work after Selecting radio button *****
            //** It include Bust message and game over message ***********
            RadioButton FakeRB = new RadioButton();
            FakeRB = (RadioButton)sender;
            int i = Convert.ToInt16(FakeRB.Tag);
            if (FakeRB.Checked == true)
            {

                lblBettorName.Text = punter[i].GuyName + " bets";
                BetAmount.Maximum = punter[i].Money;

                BetAmount.Value = punter[i].Money;

            }
            if (FakeRB.Checked == true && punter[i].Money == 0)
            {

                lblBettorName.Text = punter[i].GuyName + " bets";
                BetAmount.Maximum = punter[i].Money;

                BetAmount.Value = punter[i].Money;
                punter[i].MyRadioButton.ForeColor = Color.Red;
                punter[i].myLabel.Text = string.Format("{0} has BUSTED", punter[i].GuyName);
                punter[i].myLabel.ForeColor = Color.Red;

                punter[i].MyRadioButton.Enabled = false;



            }

            if (punter[0].MyRadioButton.Enabled == false && punter[1].MyRadioButton.Enabled == false && punter[2].MyRadioButton.Enabled == false && punter[i].Money == 0)
            {

                MessageBox.Show("GAME OVER, Please press Reset Game button to play again");
            }

        }



        // ************ Bet Button method **************
        private void btnBets_Click(object sender, EventArgs e)
        {
            int PunterID = 0;

            if (rbRam.Checked)
            {
                PunterID = 0;
            }
            if (rbSita.Checked)
            {
                PunterID = 1;
            }
            if (rbAli.Checked)
            {
                PunterID = 2;
            }

            punter[PunterID].PlaceBet((int)BetAmount.Value, (int)num_AnimalNumber.Value);
            punter[PunterID].UpdateLabels();
        }


        // ************* For Reset Button to reset game **********
        private void btnResetGame_Click(object sender, EventArgs e)
        {

            btnRace.Enabled = true;
            btnBets.Enabled = true;
            BetAmount.Enabled = true;
            lbAnimalName.Enabled = true;
            rbRam.Enabled = true;
            rbSita.Enabled = true;
            rbAli.Enabled = true;
            rbRam.ForeColor = Color.Black;
            rbSita.ForeColor = Color.Black;
            rbAli.ForeColor = Color.Black;
            lblRam.ForeColor = Color.Black;
            lblSita.ForeColor = Color.Black;
            lblAli.ForeColor = Color.Black;
            Race();
            lblMinimumBet.Text = string.Format("Minimum bet {0:c}", (int)BetAmount.Minimum);
        }


    }
}
