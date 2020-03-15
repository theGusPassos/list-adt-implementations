using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;
using System;
using System.Collections;
using System.Reflection.Metadata;

namespace ListAdtImplementation.UnitTests.Collections
{
    [TestFixture]
    public class StackTests
    {
        [TestFixture]
        public class Creating
        {
            [Test]
            public void ShouldStartWihCountZero()
            {
                var stack = new StackAdt<int>();
                stack.Count.Should().Be(0);
            }
        }

        [TestFixture]
        public class Adding
        {
            private StackAdt<int> stack;
            private const int valueAdded = 1;

            [OneTimeSetUp]
            public void AddToStack()
            {
                stack = new StackAdt<int>();
                stack.Add(valueAdded);
            }

            [Test]
            public void ShouldAddToCount()
            {
                stack.Count.Should().Be(1);
            }

            [Test]
            public void ShouldHaveValue()
            {
                stack.Peek().Should().Be(valueAdded);
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
                    var stack = new StackAdt<int>();
                    Action action = () => stack.Peek();
                    action.Should().Throw<InvalidOperationException>();
                }
            }

            [TestFixture]
            public class WithValues
            {
                private StackAdt<int> stack;
                private const int lastAdded = 2;
                private int startCount;
                private int valuePeeked;

                [OneTimeSetUp]
                public void PeekLastAdded()
                {
                    stack = new StackAdt<int>();
                    stack.Add(1);
                    stack.Add(lastAdded);
                    startCount = stack.Count;
                    valuePeeked = stack.Peek();
                }

                [Test]
                public void ShouldReturnLastAdded()
                {
                    valuePeeked.Should().Be(lastAdded);
                }

                [Test]
                public void ShouldNotRemoveFromCount()
                {
                    startCount.Should().Be(stack.Count);
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
                    var stack = new StackAdt<int>();
                    Action action = () => stack.Get();
                    action.Should().Throw<InvalidOperationException>();
                }
            }

            [TestFixture]
            public class WithValues
            {
                private StackAdt<int> stack;
                private const int lastAdded = 2;
                private int startCount;
                private int valueRetrieved;

                [OneTimeSetUp]
                public void GetLastAdded()
                {
                    stack = new StackAdt<int>();
                    stack.Add(1);
                    stack.Add(lastAdded);
                    startCount = stack.Count;
                    valueRetrieved = stack.Get();
                }

                [Test]
                public void ShouldRemoveFromCount()
                {
                    stack.Count.Should().Be(startCount - 1);
                }

                [Test]
                public void ShouldReturnLastAdded()
                {
                    valueRetrieved.Should().Be(lastAdded);
                }
            }
        }
    }
}
