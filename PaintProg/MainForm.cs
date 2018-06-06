/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 6. 5. 2018
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using RectangleGetter;
using FloodFill;

namespace PaintProg
{
	/// <summary>
	/// Main window of the application.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Contains supportive calculations for getting data about drawn rectangles and ellipses.
		/// This is a practical example of a custom .dll library.
		/// </summary>
		RectGetter rectGetter = new RectGetter();
		/// <summary>
		/// Contains a function for coloring a single-color area with another color. 
		/// This is a practical example of a custom .dll library.
		/// </summary>
		Fill fl = new Fill();
		
		/// <summary>
		/// Represents a canvas on which user draws.
		/// </summary>
		public static Bitmap bmp;

		/// <summary>
		/// Used for storing points to create a hand drawn line.
		/// </summary>
		List<Point> pointsToDraw = new List<Point>();
		
		/// <summary>
		/// Used for storing "editing state" of a program, i.e. if user draws on canvas or not.
		/// </summary>
		bool isEditing = false;
		
		/// <summary>
		/// Used for checking which mouse button is pressed.
		/// </summary>
		bool rightPressed = false;
		
		/// <summary>
		/// Used for checking if an user wants to draw a filled shape or an outline of it.
		/// </summary>
		public static bool fillingShapes = false;
		
		/// <summary>
		/// Stores an X-coordinate of a mouse.
		/// </summary>
		int mX = 0;
		
		/// <summary>
		/// Stores an Y-coordinate of a mouse.
		/// </summary>
		int mY = 0;
		
		/// <summary>
		/// Used as a switch for selecting desired drawing operation.
		/// </summary>
		public enum ActiveTool {Pen, Fill, Rectangle, Ellipse, Spray};
		
		/// <summary>
		/// Used to store a selected drawing tool.
		/// </summary>
		public static ActiveTool selectedTool = ActiveTool.Pen;
		
		/// <summary>
		/// A width of a pen.
		/// </summary>
		public static float penWidth = 1;
		
		/// <summary>
		/// Contains information about selected colors([0] - left; [1] - right);
		/// </summary>
		public static Color[] colors = {Color.Black, Color.White};
		
		/// <summary>
		/// Supportive point for drawing rectangles and ellipses.
		/// </summary>
		public Point helpPoint = new Point(0,0);
		
		public MainForm()
		{
			InitializeComponent();
			new Intro().ShowDialog();
			
			this.Text = "Plátno";
			ToolBox toolBox = new ToolBox(this);
			toolBox.Show();
			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		}
		
		/// <summary>
		/// Changes the size of an canvas(and bitmap as well). The size is dependent on the sizes
		/// of the entire canvas form.
		/// </summary>
		void ResizeBitmap()
		{
			Bitmap tempBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			
			for(int y = 0; y < tempBmp.Height; y++)
			{
				if(y > bmp.Height-1)
					break;
				
				for(int x = 0; x < tempBmp.Width; x++)
				{
					if(x > bmp.Width-1)
						break;
					
					tempBmp.SetPixel(x, y, bmp.GetPixel(x, y));
				}
			}
			
			bmp = tempBmp;
			pictureBox1.Refresh();
		}
		
		void PictureBox1MouseDown(object sender, MouseEventArgs e)
		{
			rightPressed = true;
			
			//The timer is used to perform the actual drawing without any need of moving
			//a mouse(specifically used with spraying tool.
			timer1.Enabled = true;
			
			if(e.Button == MouseButtons.Left)
				rightPressed = false;
			
			switch(selectedTool)
			{
				case ActiveTool.Pen:
				case ActiveTool.Spray:
				case ActiveTool.Rectangle:
				case ActiveTool.Ellipse:
					isEditing = true;
					pointsToDraw.Add(new Point(e.Location.X, e.Location.Y));
					pointsToDraw.Add(new Point(e.Location.X, e.Location.Y));
					break;
				case ActiveTool.Fill:
					
					Color onPointer = bmp.GetPixel(e.Location.X, e.Location.Y);
					Color toFill = colors[Convert.ToInt16(rightPressed)];
					
					fl.FillRegion(bmp, pictureBox1, new Point(e.Location.X, e.Location.Y), onPointer, toFill);
					
					break;
			}
			
			pointsToDraw.Clear();
			pointsToDraw.Add(new Point(e.Location.X, e.Location.Y));
		}
		
		void PictureBox1MouseUp(object sender, MouseEventArgs e)
		{
			pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
			isEditing = false;
			timer1.Enabled = false;
			pointsToDraw.Clear();
			
		}
		
		void PictureBox1MouseMove(object sender, MouseEventArgs e)
		{
			mX = e.Location.X;
			mY = e.Location.Y;
		}
		
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(bmp, 0, 0);
			
			//Changes the "rightPressed" bool to a number and uses it
			//for selecting appropriate color.
			Color tempCol = colors[(Convert.ToInt16(rightPressed))];
			
			if(pointsToDraw.Count > 1)
			{
				e.Graphics.DrawLines(new Pen(tempCol, penWidth), pointsToDraw.ToArray());
			}
			
			//Due to the way Draw/FillRectangle works with negative coordinates, drawing
			//rectangles has to be solved with polygons instead.
			if(pointsToDraw.Count == 1 && isEditing && selectedTool == ActiveTool.Rectangle)
			{
				var rect = rectGetter.GetRectangularPolygon(pointsToDraw[0], helpPoint);
				
				if(fillingShapes)
					e.Graphics.FillPolygon(new SolidBrush(colors[1]), rect);
				e.Graphics.DrawPolygon(new Pen(colors[0], penWidth), rect);
			}
			
			if(pointsToDraw.Count == 1 && isEditing && selectedTool == ActiveTool.Ellipse)
			{
				var rect = rectGetter.GetRectangle(pointsToDraw[0], helpPoint);
				if(fillingShapes)
					e.Graphics.FillEllipse(new SolidBrush(colors[1]), rect);
				e.Graphics.DrawEllipse(new Pen(colors[0], penWidth), rect);
			}
			
		}
		
		void PictureBox1Resize(object sender, EventArgs e)
		{
			ResizeBitmap();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(selectedTool == ActiveTool.Pen && isEditing)
			{
				pointsToDraw.Add(new Point(mX, mY));
				pictureBox1.Refresh();
			}
			
			if((selectedTool == ActiveTool.Rectangle || selectedTool == ActiveTool.Ellipse) && isEditing)
			{
				
				helpPoint.X = mX;
				helpPoint.Y = mY;
				
				pictureBox1.Refresh();
			}
			
			if(selectedTool == ActiveTool.Spray && isEditing)
			{
				for(int i = 0; i < penWidth*5; i++)
				{
					Random rnd = new Random();
					
					int rndNum = rnd.Next(0, (int)penWidth);
					
					int spreadX = Convert.ToInt16(penWidth-(rndNum*2));
					rndNum = rnd.Next(0, (int)penWidth);
					int spreadY = Convert.ToInt16(penWidth-(rndNum*2));
					
					int pX = mX+spreadX;
					int pY = mY+spreadY;
					
					if(pX >= 0 && pX < bmp.Width-1 && pY >= 0 && pY < bmp.Height-1)
						bmp.SetPixel(mX+spreadX, mY+spreadY, colors[Convert.ToInt16(rightPressed)]);
					
				}
				
				pictureBox1.Refresh();
			}
		}
	}
}
