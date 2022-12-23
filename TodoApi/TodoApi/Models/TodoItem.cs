﻿using System;
namespace TodoApi.Models
{
	public class TodoItem
	{
		public Guid Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Date { get; set; }
		public string? Time { get; set; }
		public bool Completed { get; set; }
	}
}

