﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace UdemyClone.CatalogApi.Models
{
	public class Course
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string CategoryId { get; set; }

		public string UserId { get; set; }

		public string Name { get; set; }
		
		public string Description { get; set; }

		[BsonRepresentation(BsonType.Decimal128)]
		public decimal Price { get; set; }	

		public string Picture { get; set; }

		[BsonRepresentation(BsonType.DateTime)]
		public DateTime CreatedTime { get; set; }

		[BsonIgnore]
		public Category Category { get; set; }

	}
}
