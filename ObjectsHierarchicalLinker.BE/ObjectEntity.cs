﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace ObjectsHierarchyCreator.BE
{
    public class ObjectEntity
    {

        public static readonly int NoParentIdValue = 0;

        private int _id;

        [JsonPropertyName("id")]
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 1)
                    throw new InvalidInputException($"Invalid id {value}. The value of id needs to be at least 1.");
                _id = value;
            }
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        private int _parentId;

        [JsonPropertyName("parent")]
        public int? ParentId
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value == null || value == Id ? NoParentIdValue : value.Value;
                if (_parentId < NoParentIdValue)
                    throw new InvalidInputException($"Invalid parent {value}. The value of parent needs to be at least 1, or null for indicating no parent.");
            }
        }


        public HierarchyObject AsHierarchyObject()
        {

            return new HierarchyObject() { Id = this.Id, Name = this.Name };
        }


    }

    public class ObjectEntitiesConverter : JsonConverter<List<ObjectEntity>>
    {
        public override List<ObjectEntity> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            try
            {
                var res = JsonSerializer.Deserialize<List<ObjectEntity>>(ref reader);

                return res;
            }
            catch (JsonException e)
            {
                throw new InvalidInputException(e.Message);
            }


        }

        public override void Write(Utf8JsonWriter writer, List<ObjectEntity> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
