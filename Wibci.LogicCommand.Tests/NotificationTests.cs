using NUnit.Framework;

namespace Wibci.LogicCommand.Tests
{
	[TestFixture]
	public class NotificationTests
	{
		private Notification _notification;

		[SetUp]
		public void TestSetup()
		{
			_notification = new Notification();
		}

		[Test]
		public void ToString_Call_ReturnsErrorSummary()
		{
			const string error1 = "test";
			const string error2 = "another";
			_notification.Add(error1);
			_notification.Add(error2);

			string summary = _notification.ToString();

			Assert.IsTrue(summary.Contains(error1), "Expected error 1 to be in the error summary");
			Assert.IsTrue(summary.Contains(error2), "Expected error 2 to be in the error summary");
		}

		[Test]
		public void Severity_GetError_ReturnsCorrectSeverity()
		{
			_notification.Add("Info", NotificationSeverity.Info);
			_notification.Add("Error", NotificationSeverity.Error);

			Assert.AreEqual(NotificationSeverity.Error, _notification.Severity, "Expected Notification Severity to reflect correctly");
		}
	}
}