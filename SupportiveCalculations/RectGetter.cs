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
	/// Contains functions to return polygons and rectangles used in drawing
	/// features of application.
	/// </summary>
	public class RectGetter
	{
		/// <summary>
		/// Creates a rectangle from 2 points.
		/// </summary>
		/// <param name="p1">1. point.</param>
		/// <param name="p2">2. point.</param>
		/// <returns>Rectangle</returns>
		public Rectangle GetRectangle(Point p1, Point p2)
		{
			return new Rectangle(p1.X, p1.Y, p2.X-p1.X, p2.Y-p1.Y);
		}
		
		/// <summary>
		/// Ze získaných bodů vytvoří obdélníkový polygon pro vykreslení.
		/// </summary>
		/// <param name="p1">1. point.</param>
		/// <param name="p2">2. point.</param>
		/// <returns>Polygon that represents a rectangle.</returns>
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