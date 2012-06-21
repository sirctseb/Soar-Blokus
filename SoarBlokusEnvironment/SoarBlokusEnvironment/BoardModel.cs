using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarBlokus
{
	// a class to represent the state of a blokus board
	public class BoardModel
	{
		// The array of squares
		Square [,]squares = new Square [20,20];
	}
	public class Square
	{
		public BlokusColor color = BlokusColor.None;
	}
}
