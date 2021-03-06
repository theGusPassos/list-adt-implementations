﻿using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;
using System;
using System.Numerics;

namespace ListAdtImplementation.UnitTests.Collections
{
    [TestFixture]
    public class VectorTests
    {
        private const int vectorInitialCapacity = 16;

        [TestFixture]
        public class Creating
        {
            [Test]
            public void ShouldSetCapacityTo16WhenNotSpecified()
            {
                var vector = new VectorAdt<int>();
                vector.Capacity.Should().Be(vectorInitialCapacity);
            }

            [Test]
            public void ShouldSetCapacityWithParametersFromConstructor()
            {
                const int capacity = 5;
                var vector = new VectorAdt<int>(capacity);
                vector.Capacity.Should().Be(capacity);
            }

            [Test]
            public void ShouldInitializeWithCountZero()
            {
                var vector = new VectorAdt<int>();
                vector.Count.Should().Be(0);
            }

            [Test]
            public void ShouldCreateWithCopiedArray()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3, 4, 5);

                var secondVector = new VectorAdt<int>(vector);

                vector.Should().BeEquivalentTo(secondVector);
            }
        }

        [TestFixture]
        public class Adding
        {
            [Test]
            public void ShouldAddToCount()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1);
                vector.Count.Should().Be(1);
            }

            [Test]
            public void ShouldNotChangeCapacityWhenUnderLimit()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1);
                vector.Capacity.Should().Be(vectorInitialCapacity);
            }

            [Test]
            public void ShouldDoubleCapacityWhenOverLimit()
            {
                var vector = new VectorAdt<int>();
                for (int i = 0; i < vectorInitialCapacity + 1; i++)
                    vector.Add(i);

                vector.Capacity.Should().Be(vectorInitialCapacity * 2);
            }

            [Test]
            public void ShouldAddObjectToList()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1);
                vector[0].Should().Be(1);
            }

            [Test]
            public void ShouldAddMultipleObjectsToList()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3, 4);
                vector.Count.Should().Be(4);
            }

            [TestFixture]
            public class AddAt
            {
                private VectorAdt<int> vector;

                [OneTimeSetUp]
                public void AddAtSecondPosition()
                {
                    vector = new VectorAdt<int>();
                    vector.Add(1, 2, 3, 4);
                    vector.AddAt(5, 1);
                }

                [Test]
                public void ShouldAtSecondPosition()
                {
                    vector[1].Should().Be(5);
                }

                [Test]
                public void ShouldSumToCount()
                {
                    vector.Count.Should().Be(5);
                }

                [Test]
                public void ShouldHaveNewOrganizationForVector()
                {
                    var expectedVector = new VectorAdt<int>();
                    expectedVector.Add(1, 5, 2, 3, 4);
                    (vector == expectedVector).Should().BeTrue();
                }
            }
        }

        [TestFixture]
        public class Getting
        {
            [Test]
            public void ShouldReturnValueAdded()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1);
                vector[0].Should().Be(1);
            }

            [Test]
            public void ShouldThrowIndexOutOfRangeIfIsGreaterThanCount()
            {
                var vector = new VectorAdt<int>();
                Action act = () => vector.Get(0);
                act.Should().Throw<IndexOutOfRangeException>();
            }
        }

        [TestFixture]
        public class Equality
        {
            [Test]
            public void ShouldBeEqual()
            {
                VectorAdt<int> first = new VectorAdt<int>();
                first.Add(1, 2, 3);

                VectorAdt<int> second = new VectorAdt<int>(first);

                (first == second).Should().BeTrue();
            }

            [Test]
            public void ShouldNotBeEqual()
            {
                VectorAdt<int> first = new VectorAdt<int>();
                first.Add(1, 2, 3);

                VectorAdt<int> second = new VectorAdt<int>();
                second.Add(4, 5, 6);

                (first == second).Should().BeFalse();
            }
        }

        [TestFixture]
        public class Clearing
        {
            [Test]
            public void ShouldSetCountToZero()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3);
                vector.Clear();

                vector.Count.Should().Be(0);
            }

            [Test]
            public void ShouldThrowIndexOutOfRangeAfterClear()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3);
                vector.Clear();

                Action act = () => vector.Get(0);
                act.Should().Throw<IndexOutOfRangeException>();
            }
        }

        [TestFixture]
        public class RemoveAt
        {
            [Test]
            public void ShouldHaveDifferentValueInIndex()
            {
                const int valueToRemove = 3;
                const int indexToRemove = 2;
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3, 4);
                vector.RemoveAt(indexToRemove);
                vector[indexToRemove].Should().Be(4);
            }

            [Test]
            public void ShouldSubtractFromCount()
            {
                int startCount;
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3);
                startCount = vector.Count;

                vector.RemoveAt(1);
                vector.Count.Should().Be(startCount - 1);
            }
        }

        [TestFixture]
        public class Remove
        { 
            [Test]
            public void ShouldHaveDifferentValueInIndex()
            {
                const int valueToRemove = 2;
                const int indexToRemove = 1;
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3);
                vector.Remove(valueToRemove);

                vector[indexToRemove].Should().Be(3);
            }

            [Test]
            public void ShouldSubtractFromCount()
            {
                int startCount;
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3);
                startCount = vector.Count;

                vector.Remove(2);
                vector.Count.Should().Be(startCount - 1);
            }
        }

        [TestFixture]
        public class Enumerating
        {
            [Test]
            public void ShouldBeEnumerable()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3, 4);

                var copyVector = new VectorAdt<int>();

                foreach (var curr in vector)
                {
                    copyVector.Add(curr);
                }

                (vector == copyVector).Should().BeTrue();
            }
        }

        [TestFixture]
        public class Assigning
        {
            [Test]
            public void ShouldSetNewValue()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1);

                vector[0] = 2;

                vector[0].Should().Be(2);
            }
        }

        [TestFixture]
        public class Emptyness
        {
            [Test]
            public void ShouldReturnTrueWithoutValues()
            {
                var vector = new VectorAdt<int>();

                vector.Empty().Should().BeTrue();
            }

            [Test]
            public void ShouldReturnFalseWithValues()
            {
                var vector = new VectorAdt<int>();
                vector.Add(1, 2, 3);

                vector.Empty().Should().BeFalse();
            }
        }
    }
}
