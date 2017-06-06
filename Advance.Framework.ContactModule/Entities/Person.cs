﻿using Advance.Framework.Entities;
using System;
using System.Collections.Generic;

namespace Advance.Framework.ContactModule.Entities
{
    public class Person : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public Person()
        {
            PersonId = Guid.NewGuid();
        }

        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
