/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 7. 5. 2018
 * Time: 16:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FloodFill
{
	/// <summary>
	/// Allows to fill a selected area with 1 color. It is used to add "Fill bucket" functionality
	/// to the drawing program(similiar to "Fill bucket" tool in MS Paint).
	/// </summary>
	public class Fill
	{
		/// <summary>
		/// Fils the selected area with a color.
		/// The applied algorithm was taken from https://simpledevcode.wordpress.com/2015/12/29/flood-fill-algorithm-using-c-net/
		/// where it is described in details.
		/// </summary>
		/// <param name="bmp">Bitmap where the area to fill is present..</param>
		/// <param name="pb">Picturebox to be refreshed.</param>
		/// <param name="pt">Initial point, i.e. where an user clicked.</param>
		/// <param name="targetColor">Targeted color, i.e. the color that is to be replaced by other one.</param>
		/// <param name="replacementColor">New color.</param>
		public void FillRegion(Bitmap bmp, PictureBox pb, Point pt, Color targetColor, Color replacementColor)
		{
			Stack<Point> pixels = new Stack<Point>();
			pixels.Push(pt);

			while (pixels.Count > 0)
			{
				Point activePoint = pixels.Pop();
				if (activePoint.X < bmp.Width && activePoint.X >= 0 && activePoint.Y < bmp.Height && activePoint.Y >= 0)
				{
					if (bmp.GetPixel(activePoint.X, activePoint.Y) == targetColor)
					{
						bmp.SetPixel(activePoint.X, activePoint.Y, replacementColor);
						pixels.Push(new Point(activePoint.X - 1, activePoint.Y));
						pixels.Push(new Point(activePoint.X + 1, activePoint.Y));
						pixels.Push(new Point(activePoint.X, activePoint.Y - 1));
						pixels.Push(new Point(activePoint.X, activePoint.Y + 1));
					}
				}
			}
			
			pb.Refresh();
			return;
		}
	}
}