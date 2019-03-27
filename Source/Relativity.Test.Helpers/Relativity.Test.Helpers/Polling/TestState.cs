using System;

namespace Relativity.Test.Helpers.Polling
{
	public class TestState
	{
		private Func<bool> _condition;

		public bool IsMet { get; private set; }

		public TestState(Func<bool> condition)
		{
			_condition = condition;
			IsMet = false;
		}

		public void Check()
		{
			IsMet = _condition.Invoke();
		}
	}
}