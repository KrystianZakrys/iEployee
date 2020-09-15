using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace iEmployee.Domain.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = left.ToExpression();
            Expression<Func<T, bool>> rightExpression = right.ToExpression();

            var parameter = Expression.Parameter(typeof(T));
            var expressionBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            expressionBody = (BinaryExpression) new ParameterReplacer(parameter).Visit(expressionBody);
            return Expression.Lambda<Func<T, bool>>(expressionBody, parameter);
        }

    }
    internal class ParameterReplacer : ExpressionVisitor
    {

        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
    }
}
