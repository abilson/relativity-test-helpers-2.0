using System.Collections.Generic;

namespace Relativity.Test.Helpers.Polling
{
	/// <summary>
	/// A helper to manage waiting for events to happen in the system before asserting success/failure
	/// </summary>
	/// <remarks>Most Relativity integration tests require waiting for an agent to complete work. A tester often needs to poll for the status of that work before making assertions about whether it was successful or not. This helper gives them a simple framework to queue up one or more circumstances that must be true before an assertion can take place.</remarks>
	public class PollHelper
	{
		private int _maxPollDuration;
		private int _waitBetweenPollDuration;
		private int _cumulativeDuration = 0;

		private int ConvertToMilliseconds(int seconds) => seconds * 1000;

		private bool TimeoutMet() => _maxPollDuration > _cumulativeDuration;

		private void Wait() => System.Threading.Thread.Sleep(_waitBetweenPollDuration);

		private void IncrementTime() => _cumulativeDuration += _waitBetweenPollDuration;

		/// <summary>
		///
		/// </summary>
		/// <param name="maxPollDurationInSec">Max poll duration is the length of time in seconds that a poll will take place before moving on. This avoids infinite loops and gives you the freedom to have longer-running tests.</param>
		/// <param name="intervalBetweenPollsInSec">Interval between polls is the length of time in seconds that the system will wait until checking for the state condition again. This keeps a buffer between query executions so that API calls aren't bottlenecked by continuous execution. </param>
		public PollHelper(int maxPollDurationInSec = 60, int intervalBetweenPollsInSec = 2)
		{
			_maxPollDuration = ConvertToMilliseconds(maxPollDurationInSec);
			_waitBetweenPollDuration = ConvertToMilliseconds(intervalBetweenPollsInSec);
		}

		/// <summary>
		/// Checks at specified interval for the state condition to be true. Will end at specified timeout.
		/// </summary>
		/// <param name="state"></param>
		public void Until(TestState state)
		{
			do
			{
				Wait();
				state.Check();
				IncrementTime();
			} while (state.IsMet == false && TimeoutMet());
		}

		/// <summary>
		/// Iterates over an ordered set of states, checking each one at a specified interval for success. If it reaches timeout, will check all state conditions once before exit.
		/// </summary>
		/// <param name="states"></param>
		public void Until(Queue<TestState> states)
		{
			while (states.Count > 0)
			{
				TestState nextState = states.Dequeue();

				Until(nextState);
			}
		}
	}
}