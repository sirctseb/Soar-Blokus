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
		// squares[y][x] or squares[row][col]
		private Square [][] squares = new Square [20][];

		public Square[] GetRow(int row)
		{
			return squares[19 - row];
		}

		public BoardModel()
		{
			for (int i = 0; i < 20; i++)
			{
				squares[i] = new Square[20];
				for (int j = 0; j < 20; j++)
				{
					squares[i][j] = new Square();
				}
			}
			squares[4][2].color = BlokusColor.Blue;
		}
	}
	public class Square
	{
		public BlokusColor color = BlokusColor.None;
		public Square()
		{
		}
	}
}
