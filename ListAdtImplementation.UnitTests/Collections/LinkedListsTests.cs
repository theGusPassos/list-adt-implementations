using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListAdtImplementation.UnitTests.Collections
{
    [TestFixture]
    public class LinkedListsTests
    {
        [TestFixture]
        public class Creating
        {
            public void ShouldStartWithCountZero()
            {
                var linkedList = new LinkedListAdt<int>();
                linkedList.Count.Should().Be(0);
            }
        }

        [TestFixture]
        public class AddingInStart
        {
            [TestFixture]
            public class WithoutValues
            {
                private LinkedListAdt<int> linkedList;
                private const int valueAdded = 1;

                [OneTimeSetUp]
                public void AddWithEmptyList()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(1);
                }

                [Test]
                public void HeadShouldBeFirstAdded()
                {
                    linkedList.Head.Value.Should().Be(valueAdded);
                }

                [Test]
                public void CountShouldBeOne()
                {
                    linkedList.Count.Should().Be(1);
                }
            }

            [TestFixture]
            public class WithValues
            {
                private LinkedListAdt<int> linkedList;
                private const int oldHead = 1;
                private const int newHead = 2;

                [OneTimeSetUp]
                public void AddInList()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(oldHead);
                    linkedList.AddToStart(newHead);
                }

                [Test]
                public void NewHeadNextShouldBeOldHead()
                {
                    var oldHeadNode = linkedList.Head.Next;
                    linkedList.Head.Next.Should().Be(oldHeadNode);
                }

                [Test]
                public void OldHeadPreviousShouldBeNewHead()
                {
                    var oldHeadPreviousNode = linkedList.Head.Next.Previous;
                    oldHeadPreviousNode.Should().Be(linkedList.Head);
                }

                [Test]
                public void OldHeadShouldKeepValue()
                {
                    linkedList.Head.Next.Value.Should().Be(oldHead);
                }

                [Test]
                public void CountShouldBeTwo()
                {
                    linkedList.Count.Should().Be(2);
                }
            }
        }

        [TestFixture]
        public class AddingInEnd
        {
            [TestFixture]
            public class WithoutValues
            {
                private LinkedListAdt<int> linkedList;
                private const int valueAdded = 1;

                [OneTimeSetUp]
                public void AddToEndWithoutValues()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToEnd(valueAdded);
                }

                [Test]
                public void ShouldAddToCount()
                {
                    linkedList.Count.Should().Be(1);
                }

                [Test]
                public void ShouldSetValueInHead()
                {
                    linkedList.Head.Value.Should().Be(valueAdded);
                }

                [Test]
                public void ShouldHaveTailNull()
                {
                    linkedList.Tail.Should().BeNull();
                }
            }

            [TestFixture]
            public class WithValuesButNoTail
            {
                private LinkedListAdt<int> linkedList;
                private const int headValue = 1;
                private const int valueAdded = 2;

                [OneTimeSetUp]
                public void AddToListWithHead()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(headValue);
                    linkedList.AddToEnd(valueAdded);
                }

                [Test]
                public void ShouldHaveCountTwo()
                {
                    linkedList.Count.Should().Be(2);
                }

                [Test]
                public void TailPreviousShouldBeHead()
                {
                    linkedList.Tail.Previous.Should().Be(linkedList.Head);
                }

                [Test]
                public void HeadNextShouldBeTail()
                {
                    linkedList.Head.Next.Should().Be(linkedList.Tail);
                }

                [Test]
                public void HeadShouldKeepValue()
                {
                    linkedList.Head.Value.Should().Be(headValue);
                }
            }

            [TestFixture]
            public class WithValuesAndTail
            {
                private LinkedListAdt<int> linkedList;
                private LinkedListAdt<int>.LinkedListNode oldTail;
                private const int addedValue = 3;
                private const int oldTailValue = 2;

                [OneTimeSetUp]
                public void AddWithValuesAndTail()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(1);
                    linkedList.AddToEnd(oldTailValue);
                    oldTail = linkedList.Tail;

                    linkedList.AddToEnd(addedValue);
                }

                [Test]
                public void ShouldHaveCountCountThree()
                {
                    linkedList.Count.Should().Be(3);
                }

                [Test]
                public void OldTailNextShouldBeTail()
                {
                    oldTail.Next.Should().Be(linkedList.Tail);
                }

                [Test]
                public void TailPreviousShouldBeOldTail()
                {
                    linkedList.Tail.Previous.Should().Be(oldTail);
                }

                [Test]
                public void TailValueShouldBeTheAdded()
                {
                    linkedList.Tail.Value.Should().Be(addedValue);
                }

                [Test]
                public void OldTailValueShouldNotChange()
                {
                    oldTail.Value.Should().Be(oldTailValue);
                }
            }
        }

        [TestFixture]
        public class Empty
        {
            [Test]
            public void ShouldStartEmpty()
            {
                new LinkedListAdt<int>().Empty().Should().BeTrue();
            }

            [Test]
            public void ShouldNotBeEmptyWithValues()
            {
                var linkedList = new LinkedListAdt<int>();
                linkedList.AddToStart(1);
                linkedList.Empty().Should().BeFalse();
            }
        }

        [TestFixture]
        public class RemoveFromStart
        {
            [TestFixture]
            public class WithoutValues
            {
                [Test]
                public void ShouldReturnException()
                {
                    var linkedList = new LinkedListAdt<int>();
                    Action act = () => linkedList.RemoveFromStart();
                    act.Should().Throw<InvalidOperationException>();
                }
            }

            [TestFixture]
            public class WithOnlyHead
            {
                private LinkedListAdt<int> linkedList;
                private int startCount;

                [OneTimeSetUp]
                public void RemoveFromListWithOnlyHead()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(1);
                    startCount = linkedList.Count;
                    linkedList.RemoveFromStart();
                }

                [Test]
                public void ShouldSetHeadToNull()
                {
                    linkedList.Head.Should().BeNull();
                }

                [Test]
                public void ShouldSubtractFromCount()
                {
                    linkedList.Count.Should().Be(startCount - 1);
                }
            }

            [TestFixture]
            public class WithHeadAndTail
            {
                private LinkedListAdt<int> linkedList;
                private LinkedListAdt<int>.LinkedListNode oldTail;
                private const int tailValue = 2;
                private int startCount;

                [OneTimeSetUp]
                public void RemoveFromListWithHeadAndTail()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(1);
                    linkedList.AddToEnd(tailValue);
                    startCount = linkedList.Count;
                    oldTail = linkedList.Tail;

                    linkedList.RemoveFromStart();
                }

                [Test]
                public void ShouldHaveHeadAsOldTail()
                { 
                    linkedList.Head.Should().Be(oldTail);
                }

                [Test]
                public void ShouldHaveHeadWithNullPrevious()
                {
                    linkedList.Head.Previous.Should().BeNull();
                }

                [Test]
                public void ShouldHaveTailNull()
                {
                    linkedList.Tail.Should().BeNull();
                }
                
                [Test]
                public void ShouldSubtractFromCount()
                {
                    linkedList.Count.Should().Be(startCount - 1);
                }
            }
        }

        [TestFixture]
        public class RemoveFromEnd
        {
            [TestFixture]
            public class WithoutValues
            {
                [Test]
                public void ShouldReturnException()
                {
                    var linkedList = new LinkedListAdt<int>();
                    Action act = () => linkedList.RemoveFromEnd();
                    act.Should().Throw<InvalidOperationException>();
                }
            }

            [TestFixture]
            public class WithOnlyHead
            {
                private LinkedListAdt<int> linkedList;
                private int startCount;
 
                [OneTimeSetUp]
                public void RemoveFromListWithOnlyHead()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(1);
                    startCount = linkedList.Count;
                    linkedList.RemoveFromEnd();
                }

                [Test]
                public void ShouldSetHeadToNull()
                {
                    linkedList.Head.Should().BeNull();
                }

                [Test]
                public void ShouldSubtractFromCount()
                {
                    linkedList.Count.Should().Be(startCount - 1);
                }
            }
        
            [TestFixture]
            public class WithHeadAndTail
            {
                private LinkedListAdt<int> linkedList;
                private int startCount;

                [OneTimeSetUp]
                public void RemoveFromListWithHeadAndTail()
                {
                    linkedList = new LinkedListAdt<int>();
                    linkedList.AddToStart(1);
                    linkedList.AddToEnd(2);
                    startCount = linkedList.Count;

                    linkedList.RemoveFromEnd();
                }

                [Test]
                public void ShouldHaveTailNull()
                {
                    linkedList.Tail.Should().BeNull();
                }

                [Test]
                public void ShouldHeaveHeadNextNull()
                {
                    linkedList.Head.Next.Should().BeNull();
                }

                [Test]
                public void ShouldSubtractFromCount()
                {
                    linkedList.Count.Should().Be(startCount - 1);
                }
            }
        }
    
        [TestFixture]
        public class Remove
        {
        }

        [TestFixture]
        public class SearchValue
        {
        }

        [TestFixture]
        public class Clearing
        {
        }

        [TestFixture]
        public class Traversing
        {

        }
    }
}
