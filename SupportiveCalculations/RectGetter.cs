/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 7. 5. 2018
 * Time: 16:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace RectangleGetter
{
	/// <summary>
	/// Třída pro zisk obdélníků.
	/// </summary>
	public class RectGetter
	{
		/// <summary>
		/// Ze získaných bodů vytvoří obdélník pro vykreslení.
		/// </summary>
		/// <param name="p1">1. krajní bod.</param>
		/// <param name="p2">2. krajní bod.</param>
		/// <returns>Vrátí obdélník</returns>
		public Rectangle GetRectangle(Point p1, Point p2)
		{
			return new Rectangle(p1.X, p1.Y, p2.X-p1.X, p2.Y-p1.Y);
		}
		
		/// <summary>
		/// Ze získaných bodů vytvoří obdélníkový polygon pro vykreslení.
		/// </summary>
		/// <param name="p1">1. krajní bod.</param>
		/// <param name="p2">2. krajní bod.</param>
		/// <returns>Vrátí polygon tvořící obdélník</returns>
		public Point[] GetRectangularPolygon(Point p1, Point p2)
		{
			Point[] rect = new Point[4];
			rect[0] = p1;
			rect[1] = new Point(p2.X, p1.Y);
			rect[2] = p2;
			rect[3] = new Point(p1.X, p2.Y);
			
			return rect;
		}
	}
}