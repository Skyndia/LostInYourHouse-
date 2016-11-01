using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ClientApplicationWF
{
    public partial class Form1 : Form
    {
        private Client client;
        int x;
        int y;
        int hSize;
        int vSize;
        int sizeFactor;
        Random rnd = new Random();
        int mode; // 0 : do nothing | 1 : draw a rectangle | 2 : add a gate  | 3 : add a point

        List<Rectangle> rectangles;
        Rectangle rectangle;

        List<Door> doors; // rect1, rect2, location1, location2
        Door door;
        bool verticalDoor;

        Point aPoint;
        Point bPoint;

        List<Point> answer;

        public Form1()
        {
            InitializeComponent();
            connectRbtn.Checked = false;
            hSize = 100;
            vSize = 100;
            sizeFactor = 20;
            client = new Client();
            mode = 0;
            rectangles = new List<Rectangle>();
            rectangle = new Rectangle();
            doors = new List<Door>();
            door = new Door();

            hSizeCbx.SelectedIndex = 5;
            vSizeCbx.SelectedIndex = 5;

            aPoint = new Point();
            bPoint = new Point();

            answer = new List<Point>();

            infoLbl.Text = "Click \"add a room \" in order to add a rectangle.";

            openMapDialog.Filter = "Text Files (*.json)| *.json";
            saveMapDialog.Filter = "Text Files (*.json)| *.json";
        }
        
        private void Dialog_Initialize()
        {
            if (Properties.Settings.Default.filesLocation == "")
            {
                saveMapDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openMapDialog.InitialDirectory = Directory.GetCurrentDirectory();
            }
            else
            {
                saveMapDialog.InitialDirectory = Properties.Settings.Default.filesLocation;
                openMapDialog.InitialDirectory = Properties.Settings.Default.filesLocation;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            //initiate the random number -> in order to choose the colors
            rnd = new Random(1);

            Pen p = new Pen(Color.Black);
            Graphics graph = panel.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);

            //Draw the saved rectangles
            foreach (Rectangle rect in rectangles)
            {
                p = new Pen(Color.FromArgb(0, Color.Black));
                sb = new SolidBrush(randomColor());
                graph.DrawRectangle(p, rect);
                graph.FillRectangle(sb, rect);
            }

            //Draw the saved doors
            foreach (Door gate in doors)
            {
                p = new Pen(Color.Chocolate);
                p.Width = 4;
                graph.DrawLine(p, gate.loc1, gate.loc2);
            }

            //Draw the points
            p = new Pen(Color.Red);
            sb = new SolidBrush(Color.Red);
            if (aPoint != new Point())
            {
                graph.DrawEllipse(p, aPoint.X, aPoint.Y, 4, 4);
                graph.FillEllipse(sb, aPoint.X, aPoint.Y, 4, 4);
            }
            if (bPoint != new Point())
            {
                graph.DrawEllipse(p, bPoint.X, bPoint.Y, 4, 4);
                graph.FillEllipse(sb, bPoint.X, bPoint.Y, 4, 4);
            }

            //If we are drawing a rectangle
            if (mode == 1 || mode == 11 || mode == 12)
            {
                //draw the new rectangle
                p = new Pen(Color.FromArgb(0, Color.Black));
                sb = new SolidBrush(randomColor());
                rectangle = new Rectangle(x, y, hSize, vSize);
                graph.DrawRectangle(p, rectangle);
                graph.FillRectangle(sb, rectangle);
            }
            else if (mode == 23)
            {
                p = new Pen(Color.Chocolate);
                sb = new SolidBrush(Color.Chocolate);
                Rectangle circle = new Rectangle(x - 4, y - 4, 8, 8);
                graph.DrawEllipse(p, circle);
                graph.FillEllipse(sb, circle);  
            }
            else if (mode == 24)
            {
                p = new Pen(Color.Chocolate);
                p.Width = 4;
                graph.DrawLine(p, door.loc1, door.loc2);
            }
            else if (mode == 4) //Draw the result of the calculation
            {
                p = new Pen(Color.Red);
                p.Width = 3;

                for(int i = 0; i < answer.Count - 1; i++)
                {
                    graph.DrawLine(p, answer.ElementAt(i), answer.ElementAt(i + 1));
                }
            }

            sb.Dispose();
            p.Dispose();
            graph.Dispose();

        }

        private void connectRbtn_Click(object sender, EventArgs e)
        {
            connectRbtn.Checked = false;
            string ipAdress = ipAdressCbx.Text;
            int port = 0;
            int.TryParse(portCbx.Text, out port);

            //Add some tests

            if (client.connected)
            {
                client.Disconnect();
                client.setTarget(ipAdress, port);
                connectRbtn.Checked = false;
                connectionInfoLvl.Text = "Disconnected";
                calcBtn.Visible = false;
                calcBtn.Enabled = false;

                info2Lbl.Visible = true;
                info2Lbl.Text = "You need to connect before starting a calculation.";

            }
            else 
            {
                client.setTarget(ipAdress, port);
                if (client.Connect())
                {
                    connectRbtn.Checked = true;
                    connectionInfoLvl.Text = "Connected";
                    calcBtn.Visible = true;
                    calcBtn.Enabled = true;

                    info2Lbl.Visible = false;
                }
                else
                {
                    connectionInfoLvl.Text = "Enable to establish the connection";
                }
            }
        }

        private Color randomColor()
        {
            Color res = new Color();
            res = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            return res;
        }

        private void addRectBtn_Click(object sender, EventArgs e)
        {
            if (rectangle != new Rectangle()) rectangles.Add(rectangle); //save the previous rectangle
            rectangle = new Rectangle();
            mode = 11;
            infoLbl.Text = "Click somewhere to position your rectangle.";
        }

        private void leftTests(Rectangle rect, int vStep, int hStep)
        {
            //vertical
            if (rect.X <= x && x <= rect.X + rect.Width)
            {
                if (Math.Abs(rect.Y + rect.Height - y) < vStep)
                    y = rect.Y + rect.Height;

                if (Math.Abs(rect.Y - y - vSize) < vStep)
                    y = rect.Y - vSize;
            }

            //horizontal
            if (rect.Y <= y && y <= rect.Y + rect.Height || rect.Y < y + vSize && y + vSize < rect.Y + rect.Height)
            {
                if (Math.Abs(rect.X + rect.Width - x) < hStep)
                    x = rect.X + rect.Width;
            }
        }

        private void rightTests(Rectangle rect, int vStep, int hStep)
        {
            int xtr = x + hSize;
            //vertical
            if (rect.X <= xtr && xtr <= rect.X + rect.Width)
            {
                if (Math.Abs(rect.Y + rect.Height - y) < vStep)
                    y = rect.Y + rect.Height;

                if (Math.Abs(rect.Y - y - vSize) < vStep)
                    y = rect.Y - vSize;
            }

            //horizontal
            if (rect.Y <= y && y <= rect.Y + rect.Height || rect.Y < y + vSize && y + vSize < rect.Y + rect.Height)
            {
                if (Math.Abs(rect.X - xtr) < hStep)
                    x = rect.X - hSize; //xtr = rect.X && xtr = x + hSize
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mode == 11)
            {
                Point p = new Point(e.X, e.Y);
                x = p.X; y = p.Y;

                //the following lines help the user to position the rectangle
                //Detect if there is another rectangle close
                int cpt = 0;
                int n = rectangles.Count;
                int vStep = 20;
                int hStep = 20;
                while (cpt < n)
                {
                    Rectangle rect = rectangles.ElementAt(cpt);
                    leftTests(rect, vStep, hStep);
                    rightTests(rect, vStep, hStep);
                    cpt++;
                }
                panel.Invalidate();
            }
            else if (mode == 23) // if door mode stage 3 -> choose the door location
            {
                #region tests
                Point p = new Point(e.X, e.Y);
                //There are 4 different cases depending on the location of the 2 rectangles.
                //We can eliminate 2 cases by switching the order of the both rectangles when necessary.

                Rectangle rect1 = rectangles.ElementAt(door.rect1);
                Rectangle rect2 = rectangles.ElementAt(door.rect2);
                // if each point of rect2 is at left of rect1
                //if each point of rect2 is upper to rect1
                if (rect2.X + rect2.Width <= rect1.X || rect2.Y + rect2.Height <= rect1.Y)
                {
                    //Switch rect1 and rect2 in order to go the another case
                    int r1 = door.rect2;
                    door.rect2 = door.rect1;
                    door.rect1 = r1;
                }

                // if rect1 is at the left of rect2
                if (rect1.X + rect1.Width <= rect2.X)
                {
                    p.X = rect2.X;

                    //bounds
                    if (p.Y < rect1.Y || p.Y < rect2.Y)
                        p.Y = Math.Max(rect1.Y, rect2.Y);
                    if (p.Y > rect1.Y + rect1.Height || p.Y > rect2.Y + rect2.Height)
                        p.Y = Math.Min(rect1.Y + rect1.Height, rect2.Y + rect2.Height);

                    x = p.X;
                    y = p.Y;

                    verticalDoor = true;
                }
                //if rect1 is upper than rect2
                if (rect1.Y + rect1.Height <= rect2.Y)
                {
                    p.Y = rect2.Y;

                    //bounds
                    if (p.X < rect1.X || p.X < rect2.X)
                        p.X = Math.Max(rect1.X, rect2.X);
                    if (p.X > rect1.X + rect1.Width || p.X > rect2.X + rect2.Width)
                        p.X = Math.Min(rect1.X + rect1.Width, rect2.X + rect2.Width);

                    x = p.X;
                    y = p.Y;

                    verticalDoor = false;
                }
                panel.Invalidate();
                #endregion
            }
            else if (mode == 24) //Stage 4 : chose the door size
            {
                Point p = new Point(e.X, e.Y);
                Rectangle rect1 = rectangles.ElementAt(door.rect1);
                Rectangle rect2 = rectangles.ElementAt(door.rect2);

                double doorMaxSize = 0;

                double scalingSetting = 150;
                double distance = 0;
                double doorSize;
                Point doorCenter = new Point(x, y);
                distance = Math.Sqrt((doorCenter.X - p.X) * (doorCenter.X - p.X) + (doorCenter.Y - p.Y) * (doorCenter.Y - p.Y));

                if (verticalDoor)
                {
                    //calculation of the max size of the door
                    if (rect1.Y < rect2.Y)
                    {
                        if (rect1.Y + rect1.Height < rect2.Y + rect2.Height)
                            doorMaxSize = rect1.Y + rect1.Height - rect2.Y;
                        else
                            doorMaxSize = rect2.Height;
                    }
                    else
                    {
                        if (rect2.Y + rect2.Height < rect1.Y + rect1.Height)
                            doorMaxSize = rect2.Y + rect2.Height - rect1.Y;
                        else
                            doorMaxSize = rect1.Height;
                    }
                    doorSize = (doorMaxSize - 1) / scalingSetting * distance + (299 - doorMaxSize) / 300;

                    door.loc1 = new Point(x, (int)(y - doorSize/2));
                    door.loc2 = new Point(x, (int)(y + doorSize / 2));

                    //bounds
                    if (door.loc1.Y < rect1.Y || door.loc1.Y < rect2.Y)
                        door.loc1 =new Point(door.loc1.X, Math.Max(rect1.Y, rect2.Y));
                    if (door.loc2.Y > rect1.Y + rect1.Height || door.loc2.Y > rect2.Y + rect2.Height)
                        door.loc2 = new Point(door.loc2.X, Math.Min(rect1.Y + rect1.Height, rect2.Y + rect2.Height));
                }
                //horizontal door
                else
                {
                    if (rect1.X < rect2.X)
                    {
                        if (rect1.X + rect1.Width < rect2.X + rect2.Width)
                            doorMaxSize = rect1.X + rect1.Width - rect2.X;
                        else
                            doorMaxSize = rect2.Width;
                    }
                    else
                    {
                        if (rect2.X + rect2.Width < rect1.X + rect1.Width)
                            doorMaxSize = rect2.X + rect2.Width - rect1.X;
                        else
                            doorMaxSize = rect1.Width;
                    }
                    doorSize = (doorMaxSize - 1) / scalingSetting * distance + (299 - doorMaxSize) / 300;

                    door.loc1 = new Point((int)(x - doorSize / 2), y);
                    door.loc2 = new Point((int)(x + doorSize / 2), y);

                    //bounds
                    if (door.loc1.X < rect1.X || door.loc1.X < rect2.X)
                        door.loc1 = new Point(Math.Max(rect1.X, rect2.X), door.loc1.Y );
                    if (door.loc2.X > rect1.X + rect1.Width || door.loc2.X > rect2.X + rect2.Width)
                        door.loc2 = new Point(Math.Min(rect1.X + rect1.Width, rect2.X + rect2.Width), door.loc2.Y);

                }
                panel.Invalidate();
            }
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == 1 || mode == 12) //if "draw rectangle" mode enabled
            {
                Point p = new Point(e.X, e.Y);
                x = p.X; y = p.Y;
                panel.Invalidate();

                if (mode == 11) mode = 12;
                else mode = 11;

                infoLbl.Text = "Click somewhere to position your rectangle.";
            }
            else if (mode == 11) //if "draw rectangle" mode enabled + "mouse move" mode enabled
            {
                panel.Invalidate();
                Console.WriteLine(mode);
                mode = 12;

                infoLbl.Text = "You can change the size of your room, or click it if you want to change the location.";
            }
            else if (mode == 21) //if door mode enabled -> Choose the first rectangle
            {
                Point p = new Point(e.X, e.Y);
                door.loc1 = p;
                door.rect1 = findRect(p);

                if (door.rect1 != -1)
                {
                    mode = 22; // go to stage 2
                    infoLbl.Text = "First rectangle selected. Choose the second one.";
                }
                else
                    infoLbl.Text = "Rectangle not found. Please try again";
            }
            else if (mode == 22) // if door mode, stage 2, -> choose the second rectangle
            {
                Point p = new Point(e.X, e.Y);
                door.loc2 = p;
                door.rect2 = findRect(p);

                if (door.rect2 != -1)
                {
                    mode = 23; // go to stage 3
                    infoLbl.Text = "Both rectangles selected. Choose the location of the door and then click.";
                }
                else
                    infoLbl.Text = "Rectangle not found. Please try again";
            }  
            //We have chosen the door location, and clicked in order to save it
            else if (mode == 23)
            {
                Point p = new Point(x, y);
                door.loc1 = p;
                door.loc2 = p;

                //Save the initial location of the door ( = door center)
                x = door.loc1.X;
                y = door.loc1.Y;

                mode = 24; //go to stage 4
                infoLbl.Text = "Choose the door size by moving the mouse.";
            }
            //if we have chosen the size of the door, and want to save it
            else if (mode == 24)
            {
                doors.Add(door);
                panel.Invalidate();
                infoLbl.Text = "Door created.";
                mode = 0;
                doorBtn_Click(sender, e); //create another door
            }

            //Add the Points
            if (mode == 3)
            {
                if (aPoint == new Point())
                    aPoint = new Point(e.X, e.Y);
                else
                {
                    bPoint = new Point(e.X, e.Y);
                    mode = 0;
                }
                    

                panel.Invalidate();
            }
        }

        //find the index of the rectangle containing the p point.
        private int findRect(Point p)
        {
            int res = -1;
            bool proceed = true;
            int cpt = 0;
            int n = rectangles.Count;

            while (cpt < n && proceed)
            {
                Rectangle rect = rectangles.ElementAt(cpt);
                if (rect.X < p.X && p.X < rect.X + rect.Width)
                    if (rect.Y < p.Y && p.Y < rect.Y + rect.Height)
                    {
                        proceed = false; //exit the loop
                        res = cpt; //get the index of the rectangle whose contains the p point.
                    }
                cpt++;
            }
            
            //return -1 if not found.
            return res;
        }

        private void hSizeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (!int.TryParse(hSizeCbx.SelectedItem.ToString(), out s))
                s = 1;
            hSize = sizeFactor * s;
            panel.Invalidate();
        }

        private void vSizeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = 0;
            if (!int.TryParse(vSizeCbx.SelectedItem.ToString(), out s))
                s = 1;
            vSize = sizeFactor * s;
            panel.Invalidate();
        }

        private void doorBtn_Click(object sender, EventArgs e)
        {
            //Save the current rectangle if existing
            if (rectangle != new Rectangle()) rectangles.Add(rectangle);
            rectangle = new Rectangle();
            mode = 0;

            //Create a new door
            door = new Door();

            mode = 21; //door mode, stage 1
            infoLbl.Text = "Click two rectangles";
        }

        private void addPtsBtn_Click(object sender, EventArgs e)
        {
            //Save the current rectangle if existing
            if (rectangle != new Rectangle()) rectangles.Add(rectangle); //should not happen
            rectangle = new Rectangle();
            mode = 0;

            mode = 3; // point mode

            //clear the both point only if they a both != null. In the other case,
            //it means the user has click the button after chosing only one point,
            //he does not want to choose the first point again.
            if (aPoint != new Point() && bPoint != new Point())
            {
                aPoint = new Point();
                bPoint = new Point();
                panel.Invalidate();
            }

            infoLbl.Text = "Click two points.";
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            //Save the current rectangle if we were building one (should not happen)
            if (rectangle != new Rectangle()) rectangles.Add(rectangle);
            rectangle = new Rectangle();
            mode = 0;

            //Data to send
            Blueprint toSend = new Blueprint(rectangles, doors, aPoint, bPoint);
            client.Send(toSend);

            //get the answer
            int cpt = 0;
            answer = new List<Point>();
            while (cpt < 6 && answer.Count == 0)
            {
                answer = client.GetAnswer();
                cpt++;
                Thread.Sleep(50);
            }

            if (answer.Count == 0)
            {
                Console.WriteLine("no answer");
                info2Lbl.Text = "No answer, please try again.";
                info2Lbl.Visible = true;
            }

            //Draw the result 
            mode = 4;
            panel.Invalidate();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            mode = 0;

            Dialog_Initialize();
            saveMapDialog.ShowDialog();
            if (saveMapDialog.FileName != "")
            {
                Blueprint toSave = new Blueprint(rectangles, doors, aPoint, bPoint);
                File.WriteAllText(saveMapDialog.FileName, toSave.ToString());

                //Save the location of the file in order to open the dialog box there the next time
                Properties.Settings.Default.filesLocation = saveMapDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }
            

        private void loadBtn_Click(object sender, EventArgs e)
        {
            mode = 0;

            Dialog_Initialize();

            //read file
            openMapDialog.ShowDialog();

            if (openMapDialog.FileName != "")
            {
                string file = File.ReadAllText(openMapDialog.FileName);

                //Recover the blueprint
                Blueprint loaded = new Blueprint(file);

                rectangles = loaded.rooms;
                doors = loaded.doors;
                aPoint = loaded.start;
                bPoint = loaded.arrival;

                //Save the location of the file
                Properties.Settings.Default.filesLocation = openMapDialog.FileName;
                Properties.Settings.Default.Save();

                //Redraw
                panel.Invalidate();
            }
        }
    }
}
