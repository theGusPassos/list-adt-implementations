using ListAdtImplementation.Collections;
using ListAdtImplementation.Challenges;
using NUnit.Framework;
using FluentAssertions;

namespace ListAdtImplementation.UnitTests.Challenges
{
    [TestFixture]
    public class LinkedListUtilsTests
    {
        [TestFixture]
        public class ReverseList
        {
            private LinkedListAdt<int> linkedList;

            [OneTimeSetUp]
            public void SetUp()
            {
                linkedList = new LinkedListAdt<int>();
                linkedList.AddToStart(1);
                linkedList.AddToEnd(2);
                linkedList.AddToEnd(3);

                linkedList.Reverse();
            }

            [Test]
            public void FirstShouldBe3()
                => linkedList.Head.Value.Should().Be(3);

            [Test]
            public void SecondShouldBe2()
                => linkedList.Head.Next.Value.Should().Be(2);

            [Test]
            public void ThirdShouldBe1()
                => linkedList.Head.Next.Next.Value.Should().Be(1);
        }
    }
}
