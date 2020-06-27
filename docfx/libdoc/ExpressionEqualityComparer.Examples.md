---
uid: ExpressionTreeToolkit.ExpressionEqualityComparer
example:
    - *content
---

The following example a dictionary collection of objects of type <xref:System.Linq.Expressions.Expression> with the <xref:ExpressionTreeToolkit.ExpressionEqualityComparer.Default> expression equality comparer.

```csharp
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExpressionTreeToolkit;

public class Program
{
	static Dictionary<Expression, String> expressions;
	public static void Main()
	{
		expressions = new Dictionary<Expression, string>(ExpressionEqualityComparer.Default);

		Console.WriteLine("Expression equality:");
		Expression<Func<int, int, int>> sumXYExpression = (x, y) => x + y;
		Expression<Func<int, int, int>> prodXYExpression = (x, y) => x * y;
		Expression<Func<int, int, int>> sumABExpression = (a, b) => a + b;
		Expression<Func<int, int, int>> diffABExpression = (a, b) => a - b;
		AddExpression(sumXYExpression, "x + y");
		AddExpression(prodXYExpression, "x * y");
		AddExpression(sumABExpression, "a + b");
		AddExpression(diffABExpression, "a - b");
		Console.WriteLine();
	}

	static void AddExpression(Expression exp, string name)
	{
		try
		{
			expressions.Add(exp, name);
			Console.WriteLine("Added {0}, Count = {1}, HashCode = {2}",
                name, expressions.Count.ToString(), exp.GetHashCode());
		}
		catch (ArgumentException)
		{
			Console.WriteLine("An expression equal to {0} is already in the collection.", name);
		}
	}
}
/* This example produces the following output:
 *
    Expression equality:
    Added x + y, Count = 1, HashCode = 9265398
    Added x * y, Count = 2, HashCode = 261086
    An expression equal to a + b is already in the collection.
    Added a - b, Count = 3, HashCode = 7571494
 *
*/
```
