using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoarBlokus
{
	public enum BlokusColor
	{
		Blue,
		Yellow,
		Red,
		Green,
		None
	};

	public class BlokusModel
	{
		public BoardModel boardModel = new BoardModel();
	}
}
