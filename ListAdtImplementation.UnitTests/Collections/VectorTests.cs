using FluentAssertions;
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
    }
}
