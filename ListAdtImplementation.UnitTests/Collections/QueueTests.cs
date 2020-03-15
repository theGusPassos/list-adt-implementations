using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;
using System;
using System.Collections;

namespace ListAdtImplementation.UnitTests.Collections
{
    [TestFixture]
    public class QueueTests
    {
        [TestFixture]
        public class Creating
        {
            private QueueAdt<int> queue;

            [Test]
            public void ShouldStartWithCountZero()
            {
                queue = new QueueAdt<int>();
                queue.Count.Should().Be(0);
            }
        }

        [TestFixture]
        public class Adding
        {
            private QueueAdt<int> queue;
            private const int valueAdded = 1;

            [OneTimeSetUp]
            public void AddToQueue()
            {
                queue = new QueueAdt<int>();
                queue.Add(1);
            }

            [Test]
            public void ShouldAddToCount()
            {
                queue.Count.Should().Be(1);
            }

            [Test]
            public void ShouldHaveValue()
            {
                queue.Peek().Should().Be(valueAdded);
            }
        }

        [TestFixture]
        public class Peeking
        {
            [TestFixture]
            public class WithoutValues
            {
                [Test]
                public void ShouldReturnInvalidOperationException()
                {
                    var queue = new QueueAdt<int>();
                    Action action = () => queue.Peek();
                    action.Should().Throw<InvalidOperationException>();
                }
            }

            [TestFixture]
            public class WithValues
            {
                private QueueAdt<int> queue;
                private const int firstAdded = 1;
                private int valuePicked;
                private int startCount;

                [OneTimeSetUp]
                public void PeekFirstAdded()
                {
                    queue = new QueueAdt<int>();
                    queue.Add(firstAdded);
                    queue.Add(2);
                    startCount = queue.Count; 

                    valuePicked = queue.Peek();
                }
                
                [Test]
                public void ShouldNotChangeCount()
                {
                    queue.Count.Should().Be(startCount);
                }

                [Test]
                public void ShouldReturnFirstAdded()
                {
                    valuePicked.Should().Be(firstAdded);
                }
            }
        }
    
        [TestFixture]
        public class Getting
        {
            [TestFixture]
            public class WithoutValues
            {
                [Test]
                public void ShouldReturnInvalidOperationException()
                {
                    var queue = new QueueAdt<int>();
                    Action action = () => queue.GetNext();
                    action.Should().Throw<InvalidOperationException>();
                }
            }

            [TestFixture]
            public class WithValues
            {
                private QueueAdt<int> queue;
                private const int firstAdded = 1;
                private int valuePicked;
                private int startCount;

                [OneTimeSetUp]
                public void PeekFirstAdded()
                {
                    queue = new QueueAdt<int>();
                    queue.Add(firstAdded);
                    queue.Add(2);
                    startCount = queue.Count; 

                    valuePicked = queue.GetNext();
                }
                
                [Test]
                public void ShouldSubtractFromCount()
                {
                    queue.Count.Should().Be(startCount - 1);
                }

                [Test]
                public void ShouldReturnFirstAdded()
                {
                    valuePicked.Should().Be(firstAdded);
                }
            }
        }
    }
}
