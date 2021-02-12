using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodieCommunityCase.Domain.Entities.Transactions
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public Guid? UserId { get; set; }

        public string EventType { get; set; }

        public string EventData { get; set; }
    }
}
