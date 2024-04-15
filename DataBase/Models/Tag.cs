using System;
using System.ComponentModel.DataAnnotations;
using DataBase.Interfaces;

namespace DataBase.Models
{
	public class Tag: IBaseDbModel
    {
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
	}
}

