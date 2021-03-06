﻿using AdlClient.OData;

namespace AdlClient.Models
{
    public class SortSpec
    {
        public ExprField Field { get; private set; }
        public AdlClient.OData.Models.OrderByDirection Direction { get; private set; }

        public SortSpec( ExprField f, AdlClient.OData.Models.OrderByDirection d)
        {
            this.Field = f;
            this.Direction = d;
        }

        public string CreateOrderByString()
        {
            var dir = DirectionToString(this.Direction);
            string orderBy = string.Format("{0} {1}", this.Field.Name, dir);
            return orderBy;
        }

        private static string DirectionToString(AdlClient.OData.Models.OrderByDirection direction)
        {
            var dir = (direction == AdlClient.OData.Models.OrderByDirection.Ascending) ? "asc" : "desc";
            return dir;
        }

    }
}