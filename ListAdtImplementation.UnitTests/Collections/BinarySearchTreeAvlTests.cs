using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListAdtImplementation.UnitTests.Collections
{
    public class BinarySearchTreeAvlTests
    {
        [TestFixture]
        public class Adding
        {
            [TestFixture]
            public class AddInEmptyTree
            {
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int valueAdded = 1;

                [OneTimeSetUp]
                public void AddToEmptyList()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
                    binarySearchTree.Add(valueAdded);
                }

                [Test]
                public void ShouldSetAsRoot()
                    => binarySearchTree.Root.Value.Should().Be(valueAdded);

                [Test]
                public void RootShouldBeLeaf()
                    => binarySearchTree.Root.IsLeaf().Should().BeTrue();
            }
            
            [TestFixture]
            public class AddSameAsRoot
            {
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 1;

                [OneTimeSetUp]
                public void AddToEmptyList()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(rootValue);
                }

                [Test]
                public void ShouldNotChangeRoot()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);

                [Test]
                public void RootShouldStillBeLeaf()
                    => binarySearchTree.Root.IsLeaf().Should().BeTrue();
            }

            [TestFixture]
            public class AddGreaterThanRoot
            {
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 1;
                private const int valueAdded = 2;

                [OneTimeSetUp]
                public void AddGreaterValue()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(valueAdded);
                }

                [Test]
                public void ShouldSetRightToRoot()
                    => binarySearchTree.Root.Right.Value.Should().Be(valueAdded);

                [Test]
                public void RootShouldBeOriginalValue()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);
            }

            [TestFixture]
            public class AddLessThanRoot
            {
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 1;
                private const int valueAdded = -1;

                [OneTimeSetUp]
                public void AddLessThanRott()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(valueAdded);
                }

                [Test]
                public void ShouldSetLeftToRoot()
                    => binarySearchTree.Root.Left.Value.Should().Be(valueAdded);

                [Test]
                public void RootShouldBeOriginalValue()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);
            }

            [TestFixture]
            public class AddMultiple
            {
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 5;

                [OneTimeSetUp]
                public void AddMultipleValues()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(rootValue - 1);
                    binarySearchTree.Add(rootValue - 2);
                    binarySearchTree.Add(rootValue + 1);
                    binarySearchTree.Add(rootValue + 2);
                }

                [Test]
                public void RootShouldBeRootValue()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);

                [Test]
                public void RootLeftShouldBeRootMinusOne()
                    => binarySearchTree.Root.Left.Value.Should().Be(rootValue - 1);

                [Test]
                public void RootLeftLeftShouldBeRootMinusTwo()
                    => binarySearchTree.Root.Left.Left.Value.Should().Be(rootValue - 2);

                [Test]
                public void RootRightShouldBeRootPlusOne()
                    => binarySearchTree.Root.Right.Value.Should().Be(rootValue + 1);

                [Test]
                public void RootRightRightShouldBeRootPlusTwo()
                    => binarySearchTree.Root.Right.Right.Value.Should().Be(rootValue + 2);
            }
        }
    }
}
