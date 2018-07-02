using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTreeToolkit
{
    public partial class ExpressionEqualityComparer : IEqualityComparer<DefaultExpression>
    {
        private bool EqualsDefault(DefaultExpression x, DefaultExpression y)
        {
            return true;
        }

        private IEnumerable<int> GetHashElementsDefault(DefaultExpression defaultExpression)
        {
            return null;
        }

        public bool Equals(DefaultExpression x, DefaultExpression y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return EqualsExpression(x, y)
                   && EqualsDefault(x, y);

        }

        public int GetHashCode(DefaultExpression obj)
        {
            if (obj == null) return 0;

            return GetHashCodeExpression(
                obj,
                GetHashElementsDefault(obj));
        }
    }
}