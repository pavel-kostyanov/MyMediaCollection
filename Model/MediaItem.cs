﻿using My_Media_Collection.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Media_Collection.Model
{
	public class MediaItem
	{
		public int Id { get; set; }
		public string Name { get; set; } 
		public ItemType MediaType { get; set; }
		public LocationType Location { get; set; }
		public Medium MediumInfo { get; set; }



	}
}
