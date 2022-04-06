using AspNetCore.Abstractions;
using System;

namespace AspNetCore.Entities
{
    public class Entity: IEntity
    {
        public int Id { get; set; }
    }
}
